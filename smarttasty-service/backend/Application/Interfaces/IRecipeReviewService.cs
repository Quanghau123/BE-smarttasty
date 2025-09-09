using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Application.DTOs.RecipeReview;
using backend.Domain.Models.Requests.RecipeReview;
using backend.Domain.Enums.Commons.Response;
using backend.Infrastructure.Helpers.Commons.Response;

namespace backend.Application.Interfaces
{
    public interface IRecipeReviewService
    {
        Task<ApiResponse<RecipeReviewDTO>> CreateRecipeReviewAsync(CreateRecipeReviewRequest request);
        Task<ApiResponse<List<RecipeReviewDTO>>> GetAllAsync();
        Task<ApiResponse<RecipeReviewDTO?>> GetByIdAsync(int id);
        Task<ApiResponse<List<RecipeReviewDTO>>> SearchAsync(string keyword);
        Task<ApiResponse<object>> DeleteAsync(int id);
    }
}
