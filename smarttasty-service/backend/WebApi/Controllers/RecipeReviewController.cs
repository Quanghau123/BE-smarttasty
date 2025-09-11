using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using backend.Application.DTOs.RecipeReview;
using backend.Application.Interfaces;
using backend.Domain.Models.Requests.RecipeReview;
using backend.Domain.Enums.Commons.Response;
using backend.Infrastructure.Helpers.Commons.Response;

namespace backend.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeReviewController : ControllerBase
    {
        private readonly IRecipeReviewService _recipeReviewService;

        public RecipeReviewController(IRecipeReviewService recipeReviewService)
        {
            _recipeReviewService = recipeReviewService;
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
        public async Task<IActionResult> Create([FromBody] CreateRecipeReviewRequest request)
        {
            var res = await _recipeReviewService.CreateRecipeReviewAsync(request);
            return CreateResult(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await _recipeReviewService.GetAllAsync();
            return CreateResult(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _recipeReviewService.GetByIdAsync(id);
            return CreateResult(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _recipeReviewService.DeleteAsync(id);
            return CreateResult(res);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            var res = await _recipeReviewService.SearchAsync(keyword);
            return CreateResult(res);
        }
    }
}
