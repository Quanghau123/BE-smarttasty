using backend.Domain.Models;
using backend.Application.DTOs.Promotion;
using backend.Domain.Models.Requests.Promotion;
using backend.Domain.Enums.Commons.Response;
using backend.Infrastructure.Helpers.Commons.Response;
using Microsoft.AspNetCore.Http;

namespace backend.Application.Interfaces
{
    public interface IPromotionService
    {
        // accept optional image file for promotion
        Task<ApiResponse<PromotionDto?>> CreatePromotionAsync(CreatePromotionRequest dto, IFormFile? file);
        Task<ApiResponse<List<PromotionDto>>> GetPromotionsByRestaurantIdAsync(int restaurantId);
        Task<ApiResponse<PromotionDto?>> GetPromotionByIdAsync(int id);
        Task<ApiResponse<List<PromotionDto>>> GetAllPromotionsAsync();
        // accept optional image file when updating
        Task<ApiResponse<PromotionDto?>> UpdatePromotionAsync(int id, Promotion updated, IFormFile? file);
        Task<ApiResponse<object>> DeletePromotionAsync(int id);
        Task RemoveExpiredPromotionsAsync();
    }
}
