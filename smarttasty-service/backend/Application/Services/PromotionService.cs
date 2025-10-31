using AutoMapper;
using backend.Infrastructure.Data;
using backend.Application.Interfaces;
using backend.Application.Interfaces.Commons;
using backend.Domain.Models;
using backend.Application.DTOs.Promotion;
using backend.Domain.Models.Requests.Promotion;
using backend.Domain.Enums.Commons.Response;
using backend.Infrastructure.Helpers.Commons.Response;
using Microsoft.EntityFrameworkCore;

namespace backend.Application.Services
{
    public class PromotionService : IPromotionService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContext;

        public PromotionService(ApplicationDbContext context, IMapper mapper, IUserContextService userContext)
        {
            _context = context;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<ApiResponse<PromotionDto?>> CreatePromotionAsync(CreatePromotionRequest dto)
        {
            if (_userContext.Role != "business")
                return new ApiResponse<PromotionDto?>
                {
                    ErrCode = ErrorCode.Forbidden,
                    ErrMessage = "User is not authorized to create promotions",
                    Data = null
                };

            var restaurant = await _context.Restaurants.FirstOrDefaultAsync(r => r.Id == dto.RestaurantId);
            if (restaurant == null)
                return new ApiResponse<PromotionDto?>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "Restaurant not found",
                    Data = null
                };

            if (restaurant.OwnerId != _userContext.UserId)
                return new ApiResponse<PromotionDto?>
                {
                    ErrCode = ErrorCode.Forbidden,
                    ErrMessage = "User does not own the restaurant",
                    Data = null
                };

            var promotion = new Promotion
            {
                RestaurantId = dto.RestaurantId,
                Title = dto.Title,
                Description = dto.Description,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                DiscountType = dto.DiscountType,
                DiscountValue = dto.DiscountValue,
                TargetType = dto.TargetType
            };

            _context.Promotions.Add(promotion);
            await _context.SaveChangesAsync();

            await _context.Entry(promotion).Reference(p => p.Restaurant).LoadAsync();

            return new ApiResponse<PromotionDto?>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Created successfully",
                Data = _mapper.Map<PromotionDto>(promotion)
            };
        }

        public async Task<ApiResponse<List<PromotionDto>>> GetPromotionsByRestaurantIdAsync(int restaurantId)
        {
            var promos = await _context.Promotions
                .Where(p => p.RestaurantId == restaurantId)
                .Include(p => p.Restaurant)
                .ToListAsync();

            var data = _mapper.Map<List<PromotionDto>>(promos);

            return new ApiResponse<List<PromotionDto>>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "OK",
                Data = data
            };
        }

        public async Task<ApiResponse<PromotionDto?>> GetPromotionByIdAsync(int id)
        {
            var promo = await _context.Promotions
                .Include(p => p.Restaurant)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (promo == null)
                return new ApiResponse<PromotionDto?>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "Promotion not found",
                    Data = null
                };

            return new ApiResponse<PromotionDto?>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "OK",
                Data = _mapper.Map<PromotionDto>(promo)
            };
        }

        public async Task<ApiResponse<List<PromotionDto>>> GetAllPromotionsAsync()
        {
            var promos = await _context.Promotions
                .Include(p => p.Restaurant)
                .OrderByDescending(p => p.StartDate)
                .ToListAsync();

            var data = _mapper.Map<List<PromotionDto>>(promos);

            return new ApiResponse<List<PromotionDto>>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "OK",
                Data = data
            };
        }

        public async Task<ApiResponse<PromotionDto?>> UpdatePromotionAsync(int id, Promotion updated)
        {
            if (_userContext.Role != "business")
                return new ApiResponse<PromotionDto?>
                {
                    ErrCode = ErrorCode.Forbidden,
                    ErrMessage = "User is not authorized to update promotions",
                    Data = null
                };

            var promo = await _context.Promotions
                .Include(p => p.Restaurant)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (promo == null)
                return new ApiResponse<PromotionDto?>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "Promotion not found",
                    Data = null
                };

            if (promo?.Restaurant?.OwnerId != _userContext.UserId)
                return new ApiResponse<PromotionDto?>
                {
                    ErrCode = ErrorCode.Forbidden,
                    ErrMessage = "User does not own the restaurant",
                    Data = null
                };

            promo.Title = updated.Title;
            promo.Description = updated.Description;
            promo.StartDate = updated.StartDate;
            promo.EndDate = updated.EndDate;
            promo.DiscountType = updated.DiscountType;
            promo.DiscountValue = updated.DiscountValue;
            promo.TargetType = updated.TargetType;

            await _context.SaveChangesAsync();

            return new ApiResponse<PromotionDto?>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Updated successfully",
                Data = _mapper.Map<PromotionDto>(promo)
            };
        }

        public async Task<ApiResponse<object>> DeletePromotionAsync(int id)
        {
            if (_userContext.Role != "business")
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.Forbidden,
                    ErrMessage = "User is not authorized to delete promotions",
                    Data = null
                };

            var promo = await _context.Promotions
                .Include(p => p.Restaurant)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (promo == null)
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "Promotion not found",
                    Data = null
                };

            if (promo?.Restaurant?.OwnerId != _userContext.UserId)
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.Forbidden,
                    ErrMessage = "User does not own the restaurant",
                    Data = null
                };

            _context.Promotions.Remove(promo);
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
