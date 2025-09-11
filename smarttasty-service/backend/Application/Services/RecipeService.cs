using AutoMapper;
using backend.Domain.Models;
using backend.Infrastructure.Data;
using backend.Application.DTOs.Recipe;
using backend.Application.Interfaces;
using backend.Application.Interfaces.Commons;
using backend.Infrastructure.Helpers;
using backend.Domain.Enums.Commons.Response;
using backend.Infrastructure.Helpers.Commons.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Application.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly ApplicationDbContext _context;
        private readonly IPhotoService _photoService;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContext;
        private readonly IImageHelper _imageHelper;

        public RecipeService(
            ApplicationDbContext context,
            IPhotoService photoService,
            IMapper mapper,
            IUserContextService userContext,
            IImageHelper imageHelper)
        {
            _context = context;
            _photoService = photoService;
            _mapper = mapper;
            _userContext = userContext;
            _imageHelper = imageHelper;
        }

        public async Task<ApiResponse<RecipeDto?>> CreateRecipeAsync(Recipe recipe, IFormFile? file)
        {
            if (file == null)
            {
                return new ApiResponse<RecipeDto?>
                {
                    ErrCode = ErrorCode.ValidationError,
                    ErrMessage = "File is required",
                    Data = null
                };
            }

            var uploadedPublicId = await _photoService.UploadPhotoAsync(file, "recipes");
            if (uploadedPublicId == null)
            {
                return new ApiResponse<RecipeDto?>
                {
                    ErrCode = ErrorCode.ServerError,
                    ErrMessage = "Upload failed",
                    Data = null
                };
            }

            recipe.Image = uploadedPublicId;

            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();

            var createdRecipe = await _context.Recipes
                .Include(d => d.User)
                .FirstOrDefaultAsync(d => d.Id == recipe.Id);

            var data = createdRecipe == null ? null : _mapper.Map<RecipeDto>(createdRecipe);
            if (data != null)
            {
                data.ImageUrl = _imageHelper.GetImageUrl(data.Image);
            }

            return new ApiResponse<RecipeDto?>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "OK",
                Data = data
            };
        }

        public async Task<ApiResponse<List<RecipeDto>>> GetRecipeByUserIdAsync(int userId)
        {
            var recipes = await _context.Recipes
                .Include(d => d.User)
                .Where(d => d.UserId == userId)
                .ToListAsync();

            var recipeDtos = _mapper.Map<List<RecipeDto>>(recipes);

            foreach (var dto in recipeDtos)
            {
                dto.ImageUrl = _imageHelper.GetImageUrl(dto.Image);
            }

            return new ApiResponse<List<RecipeDto>>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "OK",
                Data = recipeDtos
            };
        }

        public async Task<ApiResponse<RecipeDto?>> UpdateRecipeAsync(int id, Recipe updatedRecipe, IFormFile? file)
        {
            var recipe = await _context.Recipes
                .Include(d => d.User)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (recipe == null)
            {
                return new ApiResponse<RecipeDto?>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "Recipe not found",
                    Data = null
                };
            }

            recipe.Title = updatedRecipe.Title;
            recipe.Category = updatedRecipe.Category;
            recipe.Description = updatedRecipe.Description;
            recipe.Ingredients = updatedRecipe.Ingredients;
            recipe.Steps = updatedRecipe.Steps;

            if (file != null)
            {
                if (!string.IsNullOrEmpty(recipe.Image))
                    await _photoService.DeletePhotoAsync(recipe.Image);

                var uploadedPublicId = await _photoService.UploadPhotoAsync(file, "recipes");
                if (uploadedPublicId == null)
                {
                    return new ApiResponse<RecipeDto?>
                    {
                        ErrCode = ErrorCode.ServerError,
                        ErrMessage = "Upload failed",
                        Data = null
                    };
                }
                recipe.Image = uploadedPublicId;
            }

            await _context.SaveChangesAsync();

            var dto = _mapper.Map<RecipeDto>(recipe);
            dto.ImageUrl = _imageHelper.GetImageUrl(dto.Image);

            return new ApiResponse<RecipeDto?>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "OK",
                Data = dto
            };
        }

        public async Task<ApiResponse<object>> DeleteRecipeAsync(int id)
        {
            var recipe = await _context.Recipes
                .Include(d => d.User)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (recipe == null)
            {
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "Recipe not found",
                    Data = null
                };
            }

            if (!string.IsNullOrEmpty(recipe.Image))
            {
                var result = await _photoService.DeletePhotoAsync(recipe.Image);
                if (!result)
                {
                    return new ApiResponse<object>
                    {
                        ErrCode = ErrorCode.ServerError,
                        ErrMessage = "Failed to delete photo",
                        Data = null
                    };
                }
            }

            _context.Recipes.Remove(recipe);
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