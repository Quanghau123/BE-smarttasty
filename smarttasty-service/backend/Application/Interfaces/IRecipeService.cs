using backend.Application.DTOs.Recipe;
using backend.Domain.Models;
using backend.Domain.Enums.Commons.Response;
using backend.Infrastructure.Helpers.Commons.Response;

namespace backend.Application.Interfaces
{
    public interface IRecipeService
    {
        Task<ApiResponse<RecipeDto?>> CreateRecipeAsync(Recipe recipe, IFormFile? file);
        Task<ApiResponse<List<RecipeDto>>> GetRecipeByUserIdAsync(int userId);
        Task<ApiResponse<RecipeDto?>> UpdateRecipeAsync(int id, Recipe updatedRecipe, IFormFile? file);
        Task<ApiResponse<object>> DeleteRecipeAsync(int id);
    }
}