using backend.Application.DTOs.Recipe;
using backend.Domain.Models;
using backend.Domain.Enums.Commons.Response;
using backend.Infrastructure.Helpers.Commons.Response;
using backend.Application.DTOs.Commons;
using backend.Domain.Models.Requests.Filters;

namespace backend.Application.Interfaces
{
    public interface IRecipeService
    {
        Task<ApiResponse<RecipeDto?>> CreateRecipeAsync(Recipe recipe, IFormFile? file);
        Task<ApiResponse<PagedDto<RecipeDto>>> GetAllRecipesAsync(PagedRequest filter);
        Task<ApiResponse<PagedDto<RecipeDto>>> GetRecipeByUserIdAsync(int userId, PagedRequest filter);
        Task<ApiResponse<RecipeDto?>> UpdateRecipeAsync(int id, Recipe updatedRecipe, IFormFile? file);
        Task<ApiResponse<object>> DeleteRecipeAsync(int id);
    }
}