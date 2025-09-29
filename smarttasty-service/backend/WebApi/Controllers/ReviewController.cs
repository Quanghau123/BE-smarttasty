using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using backend.Application.DTOs.Review;
using backend.Application.Interfaces;
using backend.Domain.Models.Requests.Review;
using backend.Infrastructure.Helpers.Commons.Response;
using backend.Domain.Enums.Commons.Response;

namespace backend.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
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
        public async Task<IActionResult> Create([FromBody] CreateReviewRequest request)
        {
            var res = await _reviewService.CreateReviewAsync(request);
            return CreateResult(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await _reviewService.GetAllAsync();
            return CreateResult(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _reviewService.GetByIdAsync(id);
            return CreateResult(res);
        }

        [HttpGet("restaurant/{id}")]
        public async Task<IActionResult> GetByRestaurantId(int id)
        {
            var res = await _reviewService.GetByRestaurantIdAsync(id);
            return CreateResult(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _reviewService.DeleteAsync(id);
            return CreateResult(res);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            var res = await _reviewService.SearchAsync(keyword);
            return CreateResult(res);
        }
    }
}
