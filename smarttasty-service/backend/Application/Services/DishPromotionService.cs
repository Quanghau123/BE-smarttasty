using AutoMapper;
using backend.Infrastructure.Data;
using backend.Application.Interfaces;
using backend.Domain.Models;
using backend.Application.DTOs.DishPromotion;
using backend.Domain.Models.Requests.DishPromotion;
using backend.Domain.Enums.Commons.Response;
using backend.Infrastructure.Helpers.Commons.Response;
using backend.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace backend.Application.Services
{
    public class DishPromotionService : IDishPromotionService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DishPromotionService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<DishPromotionDto>>> GetAllAsync()
        {
            var list = await _context.DishPromotions
                .Include(dp => dp.Dish)
                .Include(dp => dp.Promotion)
                .ToListAsync();

            var dtos = _mapper.Map<List<DishPromotionDto>>(list);

            return new ApiResponse<List<DishPromotionDto>>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "OK",
                Data = dtos
            };
        }

        public async Task<ApiResponse<DishPromotionDto?>> GetByIdAsync(int id)
        {
            var dp = await _context.DishPromotions
                .Include(d => d.Dish)
                .Include(p => p.Promotion)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (dp == null)
                return new ApiResponse<DishPromotionDto?>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "DishPromotion not found",
                    Data = null
                };

            return new ApiResponse<DishPromotionDto?>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "OK",
                Data = _mapper.Map<DishPromotionDto>(dp)
            };
        }

        public async Task<ApiResponse<DishPromotionDto?>> ApplyDishPromotionsAsync(CreateDishPromotionRequest request)
        {
            var promo = await _context.Promotions.FindAsync(request.PromotionId);
            if (promo == null)
                return new ApiResponse<DishPromotionDto?>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "Promotion not found",
                    Data = null
                };

            var dish = await _context.Dishes.FindAsync(request.DishId);
            if (dish == null)
                return new ApiResponse<DishPromotionDto?>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "Dish not found",
                    Data = null
                };

            var dp = _mapper.Map<DishPromotion>(request);

            // Tính giá áp dụng
            dp.OriginalPrice = (float)dish.Price;
            dp.AppliedPrice = CalculateDiscountedPrice(dish.Price, promo);

            _context.DishPromotions.Add(dp);
            await _context.SaveChangesAsync();

            var dpWithRelations = await _context.DishPromotions
                .Include(x => x.Dish)
                .Include(x => x.Promotion)
                .FirstOrDefaultAsync(x => x.Id == dp.Id);

            return new ApiResponse<DishPromotionDto?>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Created successfully",
                Data = _mapper.Map<DishPromotionDto>(dpWithRelations!)
            };
        }

        public async Task<ApiResponse<DishPromotionDto?>> UpdateAsync(int id, CreateDishPromotionRequest request)
        {
            var dp = await _context.DishPromotions
                .Include(x => x.Dish)
                .Include(x => x.Promotion)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (dp == null)
                return new ApiResponse<DishPromotionDto?>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "DishPromotion not found",
                    Data = null
                };

            var promo = await _context.Promotions.FindAsync(request.PromotionId);
            var dish = await _context.Dishes.FindAsync(request.DishId);

            if (promo == null || dish == null)
                return new ApiResponse<DishPromotionDto?>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "Dish or Promotion not found",
                    Data = null
                };

            dp.DishId = request.DishId;
            dp.PromotionId = request.PromotionId;

            // Cập nhật giá
            dp.OriginalPrice = (float)dish.Price;
            dp.AppliedPrice = CalculateDiscountedPrice(dish.Price, promo);

            await _context.SaveChangesAsync();

            return new ApiResponse<DishPromotionDto?>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Updated successfully",
                Data = _mapper.Map<DishPromotionDto>(dp)
            };
        }

        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            var dp = await _context.DishPromotions.FindAsync(id);
            if (dp == null)
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "DishPromotion not found",
                    Data = null
                };

            _context.DishPromotions.Remove(dp);
            await _context.SaveChangesAsync();

            return new ApiResponse<object>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Deleted successfully",
                Data = null
            };
        }

        private float CalculateDiscountedPrice(float originalPrice, Promotion promo)
        {
            float discounted = originalPrice;

            if (promo.DiscountType == DiscountType.percent)
                discounted -= discounted * promo.DiscountValue / 100f;
            else
                discounted -= promo.DiscountValue;

            return Math.Max(0, discounted);
        }
    }
}
