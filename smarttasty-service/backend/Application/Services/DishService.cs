using AutoMapper;
using backend.Domain.Models;
using backend.Infrastructure.Data;
using backend.Application.DTOs;
using backend.Application.Interfaces;
using backend.Application.Interfaces.Commons;
using backend.Infrastructure.Helpers;
using backend.Domain.Enums.Commons.Response;
using backend.Infrastructure.Helpers.Commons.Response;
using backend.Application.DTOs.Dish;
using backend.Application.DTOs.Commons;
using backend.Domain.Models.Requests.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Application.Services
{
    public class DishService : IDishService
    {
        private readonly ApplicationDbContext _context;
        private readonly IPhotoService _photoService;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContext;
        private readonly IImageHelper _imageHelper;
        private readonly IPaginationService _paginationService;

        public DishService(
            ApplicationDbContext context,
            IPhotoService photoService,
            IMapper mapper,
            IUserContextService userContext,
            IImageHelper imageHelper,
            IPaginationService paginationService)
        {
            _context = context;
            _photoService = photoService;
            _mapper = mapper;
            _userContext = userContext;
            _imageHelper = imageHelper;
            _paginationService = paginationService;
        }

        public async Task<ApiResponse<DishDto?>> CreateDishAsync(Dish dish, IFormFile? file)
        {
            if (_userContext.Role != "business")
                return new ApiResponse<DishDto?>
                {
                    ErrCode = ErrorCode.Forbidden,
                    ErrMessage = "Unauthorized role",
                    Data = null
                };

            var restaurant = await _context.Restaurants.FirstOrDefaultAsync(r => r.Id == dish.RestaurantId);
            if (restaurant == null || restaurant.OwnerId != _userContext.UserId)
                return new ApiResponse<DishDto?>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "Restaurant not found or unauthorized",
                    Data = null
                };

            if (file != null)
            {
                var uploadedPublicId = await _photoService.UploadPhotoAsync(file, "dishes");
                if (uploadedPublicId == null)
                    return new ApiResponse<DishDto?>
                    {
                        ErrCode = ErrorCode.ServerError,
                        ErrMessage = "Failed to upload image",
                        Data = null
                    };
                dish.Image = uploadedPublicId;
            }
            else
            {
                return new ApiResponse<DishDto?>
                {
                    ErrCode = ErrorCode.ValidationError,
                    ErrMessage = "Image file is required",
                    Data = null
                };
            }

            _context.Dishes.Add(dish);
            await _context.SaveChangesAsync();

            var createdDish = await _context.Dishes
                .Include(d => d.Restaurant)
                .FirstOrDefaultAsync(d => d.Id == dish.Id);

            var dishDto = createdDish == null ? null : _mapper.Map<DishDto>(createdDish);

            return new ApiResponse<DishDto?>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "OK",
                Data = dishDto
            };
        }

        public async Task<ApiResponse<PagedDto<DishDto>>> GetDishByRestaurantIdAsync(
          int restaurantId,
          PagedRequest filter
      )
        {
            var query = _context.Dishes
                .Include(d => d.Restaurant)
                .Where(d => d.RestaurantId == restaurantId)
                .AsQueryable();

            var pagedResult = await _paginationService.GetPagedResultAsync(query, filter);

            var dishDtos = _mapper.Map<List<DishDto>>(pagedResult.Data);

            foreach (var dto in dishDtos)
            {
                dto.ImageUrl = _imageHelper.GetImageUrl(dto.Image);
            }

            // Trả về PagedDto chứa DTO list
            var finalPaged = new PagedDto<DishDto>(
                dishDtos,
                pagedResult.TotalRecords,
                pagedResult.PageNumber,
                pagedResult.PageSize
            );

            return new ApiResponse<PagedDto<DishDto>>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "OK",
                Data = finalPaged
            };
        }

        public async Task<ApiResponse<DishDto?>> UpdateDishAsync(int id, Dish updatedDish, IFormFile? file)
        {
            var dish = await _context.Dishes
                .Include(d => d.Restaurant)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (dish == null) return new ApiResponse<DishDto?>
            {
                ErrCode = ErrorCode.NotFound,
                ErrMessage = "Dish not found",
                Data = null
            };

            if (_userContext.Role != "business" || dish?.Restaurant?.OwnerId != _userContext.UserId)
                return new ApiResponse<DishDto?>
                {
                    ErrCode = ErrorCode.Forbidden,
                    ErrMessage = "Unauthorized",
                    Data = null
                };

            dish.Name = updatedDish.Name;
            dish.Category = updatedDish.Category;
            dish.Description = updatedDish.Description;
            dish.Price = updatedDish.Price;
            dish.IsActive = updatedDish.IsActive;
            dish.RestaurantId = updatedDish.RestaurantId;

            if (file != null)
            {
                if (!string.IsNullOrEmpty(dish.Image))
                    await _photoService.DeletePhotoAsync(dish.Image);

                var uploadedPublicId = await _photoService.UploadPhotoAsync(file, "dishes");
                if (uploadedPublicId == null) return new ApiResponse<DishDto?>
                {
                    ErrCode = ErrorCode.ServerError,
                    ErrMessage = "Failed to upload image",
                    Data = null
                };
                dish.Image = uploadedPublicId;
            }

            await _context.SaveChangesAsync();

            var dishDto = _mapper.Map<DishDto>(dish);

            return new ApiResponse<DishDto?>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "OK",
                Data = dishDto
            };
        }

        public async Task<ApiResponse<object>> DeleteDishAsync(int id)
        {
            var dish = await _context.Dishes
                .Include(d => d.Restaurant)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (dish == null)
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "Dish not found",
                    Data = null
                };

            if (_userContext.Role != "business" || dish?.Restaurant?.OwnerId != _userContext.UserId)
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.Forbidden,
                    ErrMessage = "Unauthorized",
                    Data = null
                };

            if (!string.IsNullOrEmpty(dish.Image))
            {
                var result = await _photoService.DeletePhotoAsync(dish.Image);
                if (!result)
                    return new ApiResponse<object>
                    {
                        ErrCode = ErrorCode.ServerError,
                        ErrMessage = "Failed to delete image",
                        Data = null
                    };
            }

            _context.Dishes.Remove(dish);
            await _context.SaveChangesAsync();
            return new ApiResponse<object>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Deleted successfully",
                Data = null
            };
        }
    }
}
