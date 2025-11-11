using AutoMapper;
using backend.Infrastructure.Data;
using backend.Application.Interfaces;
using backend.Domain.Models;
using backend.Application.DTOs.OrderPromotion;
using backend.Domain.Models.Requests.OrderPromotion;
using backend.Domain.Enums.Commons.Response;
using backend.Infrastructure.Helpers.Commons.Response;
using Microsoft.EntityFrameworkCore;

namespace backend.Application.Services
{
    public class OrderPromotionService : IOrderPromotionService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public OrderPromotionService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ApiResponse<OrderPromotionDto?>> CreateOrderPromotionAsync(CreateOrderPromotionRequest dto)
        {
            var promo = await _context.Promotions.FindAsync(dto.PromotionId);
            if (promo == null)
            {
                return new ApiResponse<OrderPromotionDto?>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "Promotion not found",
                    Data = null
                };
            }

            var op = new OrderPromotion
            {
                PromotionId = dto.PromotionId,
                MinOrderValue = dto.MinOrderValue,
                RestaurantId = dto.RestaurantId,
                TargetUserId = dto.TargetUserId,
                IsGlobal = dto.IsGlobal
            };

            _context.OrderPromotions.Add(op);
            await _context.SaveChangesAsync();

            await _context.Entry(op).Reference(o => o.Promotion).LoadAsync();
            if (op.RestaurantId != null)
                await _context.Entry(op).Reference(o => o.Restaurant).LoadAsync();

            return new ApiResponse<OrderPromotionDto?>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Created successfully",
                Data = _mapper.Map<OrderPromotionDto>(op)
            };

        }

        public async Task<ApiResponse<OrderPromotionDto?>> GetByPromotionIdAsync(int promotionId)
        {
            var op = await _context.OrderPromotions
                .Include(o => o.Promotion)
                .Include(o => o.Restaurant)
                .FirstOrDefaultAsync(o => o.PromotionId == promotionId);

            if (op == null)
            {
                return new ApiResponse<OrderPromotionDto?>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "OrderPromotion not found",
                    Data = null
                };
            }

            return new ApiResponse<OrderPromotionDto?>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "OK",
                Data = _mapper.Map<OrderPromotionDto>(op)
            };
        }

        public async Task<ApiResponse<List<OrderPromotionDto>>> GetOrderPromotionsForUserAsync(int? userId = null, int? restaurantId = null)
        {
            var promotions = await _context.OrderPromotions
                .Include(op => op.Promotion)
                .Include(op => op.Restaurant)
                .Where(op =>
                    op.IsGlobal || (userId != null && op.TargetUserId == userId))
                .Where(op =>
                    restaurantId == null || op.RestaurantId == restaurantId)
                .ToListAsync();

            return new ApiResponse<List<OrderPromotionDto>>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "OK",
                Data = _mapper.Map<List<OrderPromotionDto>>(promotions)
            };
        }

        public async Task<ApiResponse<object>> DeleteOrderPromotionAsync(int id)
        {
            var op = await _context.OrderPromotions.FindAsync(id);
            if (op == null)
            {
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "OrderPromotion not found",
                    Data = null
                };
            }

            _context.OrderPromotions.Remove(op);
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
