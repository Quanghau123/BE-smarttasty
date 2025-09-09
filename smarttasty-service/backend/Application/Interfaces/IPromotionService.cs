using backend.Domain.Models;
using backend.Application.DTOs.Promotion;
using backend.Domain.Models.Requests.Promotion;
using backend.Domain.Enums.Commons.Response;
using backend.Infrastructure.Helpers.Commons.Response;

namespace backend.Application.Interfaces
{
    public interface IPromotionService
    {
        Task<ApiResponse<PromotionDto?>> CreatePromotionAsync(CreatePromotionRequest dto);
        Task<ApiResponse<List<PromotionDto>>> GetPromotionsByRestaurantIdAsync(int restaurantId);
        Task<ApiResponse<PromotionDto?>> GetPromotionByIdAsync(int id);
        Task<ApiResponse<PromotionDto?>> UpdatePromotionAsync(int id, Promotion updated);
        Task<ApiResponse<object>> DeletePromotionAsync(int id);
    }
}
