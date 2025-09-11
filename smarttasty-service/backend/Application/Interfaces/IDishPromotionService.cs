using backend.Application.DTOs.DishPromotion;
using backend.Domain.Models.Requests.DishPromotion;
using backend.Infrastructure.Helpers.Commons.Response;

namespace backend.Application.Interfaces
{
    public interface IDishPromotionService
    {
        Task<ApiResponse<List<DishPromotionDto>>> GetAllAsync();
        Task<ApiResponse<DishPromotionDto?>> GetByIdAsync(int id);
        Task<ApiResponse<DishPromotionDto?>> CreateAsync(CreateDishPromotionRequest request);
        Task<ApiResponse<DishPromotionDto?>> UpdateAsync(int id, CreateDishPromotionRequest request);
        Task<ApiResponse<object>> DeleteAsync(int id);
    }
}
