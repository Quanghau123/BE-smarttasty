using backend.Application.Interfaces;
using backend.Domain.Models;
using backend.Domain.Enums.Commons.Response;
using backend.Infrastructure.Helpers.Commons.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace backend.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipesController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        private IActionResult CreateResult<T>(ApiResponse<T> res)
        {
            return StatusCode(MapErrorCodeToStatus(res.ErrCode), res);
        }

        private int MapErrorCodeToStatus(ErrorCode code) => code switch
        {
            ErrorCode.Success => 200,
            ErrorCode.ValidationError => 400,
            ErrorCode.NotFound => 404,
            ErrorCode.Unauthorized => 401,
            ErrorCode.Forbidden => 403,
            ErrorCode.ServerError => 500,
            _ => 500
        };

        [HttpPost]
        public async Task<IActionResult> CreateRecipe([FromForm] Recipe recipe, IFormFile? file)
        {
            var res = await _recipeService.CreateRecipeAsync(recipe, file);
            return CreateResult(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _recipeService.GetAllRecipesAsync();
            return StatusCode(result.ErrCode == ErrorCode.Success ? 200 : 400, result);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetRecipesByUser(int userId)
        {
            var res = await _recipeService.GetRecipeByUserIdAsync(userId);
            return CreateResult(res);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecipe(int id, [FromForm] Recipe updatedRecipe, IFormFile? file)
        {
            var res = await _recipeService.UpdateRecipeAsync(id, updatedRecipe, file);
            return CreateResult(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            var res = await _recipeService.DeleteRecipeAsync(id);
            return CreateResult(res);
        }
    }

}