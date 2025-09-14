using AutoMapper;
using backend.Infrastructure.Data;
using backend.Application.DTOs.Restaurant;
using backend.Domain.Enums;
using backend.Infrastructure.Helpers;
using backend.Application.Interfaces;
using backend.Application.Interfaces.Commons;
using backend.Domain.Models;
using backend.Domain.Models.Requests.Restaurant;
using backend.Domain.Models.Requests.Filters;
using backend.Infrastructure.Helpers.Commons.Response;
using backend.Domain.Enums.Commons.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace backend.Application.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserContextService _userContext;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;
        private readonly IImageHelper _imageHelper;
        private readonly IPaginationService _paginationService;

        public RestaurantService(ApplicationDbContext context, IUserContextService userContext, IMapper mapper, IPhotoService photoService, IImageHelper imageHelper, IPaginationService paginationService)
        {
            _context = context;
            _userContext = userContext;
            _mapper = mapper;
            _photoService = photoService;
            _imageHelper = imageHelper;
            _paginationService = paginationService;
        }

        public async Task<ApiResponse<object>> GetAllRestaurantsAsync(PagedRequest filter)
        {
            var query = _context.Restaurants
                .Include(r => r.Owner)
                .AsQueryable();

            var pagedResult = await _paginationService.GetPagedResultAsync(query, filter);

            var dtos = _mapper.Map<List<RestaurantDto>>(pagedResult.Data);

            foreach (var dto in dtos)
            {
                dto.ImageUrl = _imageHelper.GetImageUrl(dto.ImagePublicId);
            }

            return new ApiResponse<object>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "OK",
                Data = new
                {
                    items = dtos,
                    totalRecords = pagedResult.TotalRecords,
                    pageNumber = pagedResult.PageNumber,
                    pageSize = pagedResult.PageSize
                }
            };
        }

        public async Task<ApiResponse<object>> GetRestaurantByIdAsync(int id)
        {
            var restaurant = await _context.Restaurants.Include(r => r.Owner).FirstOrDefaultAsync(r => r.Id == id);
            if (restaurant == null)
                return new ApiResponse<object> { ErrCode = ErrorCode.NotFound, ErrMessage = "Restaurant not found" };

            var dto = _mapper.Map<RestaurantDto>(restaurant);
            dto.ImageUrl = _imageHelper.GetImageUrl(restaurant.ImagePublicId ?? "");

            return new ApiResponse<object>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "OK",
                Data = dto
            };
        }

        public async Task<ApiResponse<RestaurantDto>> CreateNewRestaurantAsync(CreateRestaurantRequest request)
        {
            if (_userContext.Role != "business")
                return new ApiResponse<RestaurantDto> { ErrCode = ErrorCode.Forbidden, ErrMessage = "Permission denied" };

            if (request.ImageFile == null)
                return new ApiResponse<RestaurantDto> { ErrCode = ErrorCode.ValidationError, ErrMessage = "Image is required" };

            var publicId = await _photoService.UploadPhotoAsync(request.ImageFile, "restaurants");
            if (publicId == null)
                return new ApiResponse<RestaurantDto> { ErrCode = ErrorCode.ServerError, ErrMessage = "Image upload failed" };

            var restaurant = _mapper.Map<Restaurant>(request);
            restaurant.OwnerId = _userContext.UserId;
            restaurant.ImagePublicId = publicId;

            _context.Restaurants.Add(restaurant);
            await _context.SaveChangesAsync();

            var created = await _context.Restaurants
                .Include(r => r.Owner)
                .FirstOrDefaultAsync(r => r.Id == restaurant.Id);

            if (created == null)
                return new ApiResponse<RestaurantDto> { ErrCode = ErrorCode.ServerError, ErrMessage = "Restaurant creation failed" };

            var dto = _mapper.Map<RestaurantDto>(created);
            dto.ImageUrl = _imageHelper.GetImageUrl(dto.ImagePublicId);

            return new ApiResponse<RestaurantDto> { ErrCode = ErrorCode.Success, ErrMessage = "Created", Data = dto };
        }

        public async Task<ApiResponse<RestaurantDto>> UpdateRestaurantAsync(UpdateRestaurantRequest request)
        {
            var restaurant = await _context.Restaurants
                .Include(r => r.Owner)
                .FirstOrDefaultAsync(r => r.Id == request.Id);

            if (restaurant == null)
                return new ApiResponse<RestaurantDto> { ErrCode = ErrorCode.NotFound, ErrMessage = "Restaurant not found" };

            if (_userContext.Role == "business" && restaurant.OwnerId != _userContext.UserId)
                return new ApiResponse<RestaurantDto> { ErrCode = ErrorCode.Forbidden, ErrMessage = "You are not the owner" };

            _mapper.Map(request, restaurant);

            if (request.ImageFile != null)
            {
                var uploadedPublicId = await _photoService.UploadPhotoAsync(request.ImageFile, "restaurants");
                if (uploadedPublicId == null)
                    return new ApiResponse<RestaurantDto> { ErrCode = ErrorCode.ServerError, ErrMessage = "Image upload failed" };

                if (!string.IsNullOrEmpty(restaurant.ImagePublicId))
                    await _photoService.DeletePhotoAsync(restaurant.ImagePublicId);

                restaurant.ImagePublicId = uploadedPublicId;
            }

            await _context.SaveChangesAsync();

            var dto = _mapper.Map<RestaurantDto>(restaurant);
            dto.ImageUrl = _imageHelper.GetImageUrl(dto.ImagePublicId);

            return new ApiResponse<RestaurantDto> { ErrCode = ErrorCode.Success, ErrMessage = "Updated", Data = dto };
        }

        public async Task<ApiResponse<object>> DeleteRestaurantAsync(int id)
        {
            var restaurant = await _context.Restaurants.FirstOrDefaultAsync(r => r.Id == id);
            if (restaurant == null)
                return new ApiResponse<object> { ErrCode = ErrorCode.NotFound, ErrMessage = "Restaurant not found" };

            if (_userContext.Role == "business" && restaurant.OwnerId != _userContext.UserId)
                return new ApiResponse<object> { ErrCode = ErrorCode.Forbidden, ErrMessage = "You are not the owner" };

            if (!string.IsNullOrEmpty(restaurant.ImagePublicId))
            {
                await _photoService.DeletePhotoAsync(restaurant.ImagePublicId);
            }

            _context.Restaurants.Remove(restaurant);
            await _context.SaveChangesAsync();

            return new ApiResponse<object> { ErrCode = ErrorCode.Success, ErrMessage = "Deleted", Data = null };
        }

        public async Task<ApiResponse<List<RestaurantDto>>> GetRestaurantsByOwnerIdAsync(int ownerId)
        {
            var restaurants = await _context.Restaurants.Include(r => r.Owner).Where(r => r.OwnerId == ownerId).ToListAsync();
            var dtos = _mapper.Map<List<RestaurantDto>>(restaurants);
            return new ApiResponse<List<RestaurantDto>> { ErrCode = ErrorCode.Success, ErrMessage = "OK", Data = dtos };
        }

        public async Task<ApiResponse<List<RestaurantDto>>> SearchRestaurantsByOwnerKeywordAsync(string keyword)
        {
            var restaurants = await _context.Restaurants
                .Include(r => r.Owner)
                .Where(r =>
                    r.Owner.Email.Contains(keyword) ||
                    r.Owner.UserName.Contains(keyword) ||
                    r.Owner.Phone.Contains(keyword))
                .ToListAsync();

            var dtos = _mapper.Map<List<RestaurantDto>>(restaurants);
            return new ApiResponse<List<RestaurantDto>> { ErrCode = ErrorCode.Success, ErrMessage = "OK", Data = dtos };
        }

        public async Task<ApiResponse<List<RestaurantDto>>> GetRestaurantsByCategoryAsync(RestaurantCategory category)
        {
            var restaurants = await _context.Restaurants.Include(r => r.Owner).Where(r => r.Category == category).ToListAsync();
            var dtos = _mapper.Map<List<RestaurantDto>>(restaurants);
            return new ApiResponse<List<RestaurantDto>> { ErrCode = ErrorCode.Success, ErrMessage = "OK", Data = dtos };
        }

        public async Task<ApiResponse<List<RestaurantDto>>> SearchRestaurantsAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return new ApiResponse<List<RestaurantDto>> { ErrCode = ErrorCode.ValidationError, ErrMessage = "Empty query" };

            var queryNormalized = TextHelper.RemoveDiacritics(query.ToLower());
            var keywords = queryNormalized.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var allRestaurants = await _context.Restaurants.Include(r => r.Owner).ToListAsync();

            var matched = allRestaurants.Where(r =>
            {
                var name = TextHelper.RemoveDiacritics(r.Name.ToLower());
                var address = TextHelper.RemoveDiacritics(r.Address.ToLower());

                bool containsAny = keywords.Any(k => name.Contains(k) || address.Contains(k));

                bool fuzzyMatch = keywords.Any(k =>
                    TextHelper.LevenshteinDistance(name, k) <= 2 ||
                    TextHelper.LevenshteinDistance(address, k) <= 2
                );

                return containsAny || fuzzyMatch;
            }).ToList();

            var dtos = _mapper.Map<List<RestaurantDto>>(matched);
            return new ApiResponse<List<RestaurantDto>> { ErrCode = ErrorCode.Success, ErrMessage = "OK", Data = dtos };
        }

        public async Task<List<string>> GetSuggestionsAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return new List<string>();

            var queryNormalized = TextHelper.RemoveDiacritics(query.ToLower());

            var restaurantNames = await _context.Restaurants
                .Select(r => r.Name)
                .Distinct()
                .ToListAsync();

            var suggestions = restaurantNames
                .Where(name => TextHelper.RemoveDiacritics(name.ToLower()).Contains(queryNormalized))
                .Take(10)
                .ToList();

            return suggestions;
        }

        public async Task<ApiResponse<object>> ChangeRestaurantStatusAsync(int restaurantId, RestaurantStatus status)
        {
            var restaurant = await _context.Restaurants.Include(r => r.Owner).FirstOrDefaultAsync(r => r.Id == restaurantId);
            if (restaurant == null)
                return new ApiResponse<object> { ErrCode = ErrorCode.NotFound, ErrMessage = "Restaurant not found" };

            restaurant.Status = status;
            _context.Restaurants.Update(restaurant);
            await _context.SaveChangesAsync();

            return new ApiResponse<object> { ErrCode = ErrorCode.Success, ErrMessage = "Status updated", Data = _mapper.Map<RestaurantDto>(restaurant) };
        }

        public async Task<List<RestaurantDto>> GetNearbyRestaurantsAsync(double userLat, double userLng, double radiusKm = 5)
        {
            var all = await _context.Restaurants.Include(r => r.Owner).ToListAsync();

            var nearby = all
                .Select(r => new
                {
                    Restaurant = r,
                    Distance = CalculateDistance(userLat, userLng, r.Latitude, r.Longitude)
                })
                .Where(x => x.Distance <= radiusKm)
                .OrderBy(x => x.Distance)
                .Select(x =>
                {
                    var dto = _mapper.Map<RestaurantDto>(x.Restaurant);
                    dto.DistanceKm = Math.Round(x.Distance, 2);
                    dto.ImageUrl = _imageHelper.GetImageUrl(dto.ImagePublicId);
                    return dto;
                })
                .ToList();

            return nearby;
        }

        private double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            double R = 6371;
            var dLat = ToRadians(lat2 - lat1);
            var dLon = ToRadians(lon2 - lon1);
            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) *
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c;
        }

        private double ToRadians(double deg) => deg * (Math.PI / 180);
    }
}