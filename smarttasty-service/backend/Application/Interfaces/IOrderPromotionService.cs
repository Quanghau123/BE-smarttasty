using backend.Application.DTOs.OrderPromotion;
using backend.Domain.Models.Requests.OrderPromotion;
using backend.Domain.Enums.Commons.Response;
using backend.Infrastructure.Helpers.Commons.Response;

namespace backend.Application.Interfaces
{
    public interface IOrderPromotionService
    {
        Task<ApiResponse<OrderPromotionDto?>> CreateOrderPromotionAsync(CreateOrderPromotionRequest dto);
        Task<ApiResponse<OrderPromotionDto?>> GetByPromotionIdAsync(int promotionId);
        Task<ApiResponse<List<OrderPromotionDto>>> GetOrderPromotionsForUserAsync(int? userId = null, int? restaurantId = null);
        Task<ApiResponse<object>> DeleteOrderPromotionAsync(int id);
    }
}
