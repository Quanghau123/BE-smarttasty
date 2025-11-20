using backend.Application.Interfaces;
using backend.Domain.Models;
using backend.Domain.Enums.Commons.Response;
using backend.Infrastructure.Helpers.Commons.Response;
using backend.Domain.Models.Requests.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace backend.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DishesController : ControllerBase
    {
        private readonly IDishService _dishService;

        public DishesController(IDishService dishService)
        {
            _dishService = dishService;
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

        [Authorize(Roles = "business")]
        [HttpPost]
        public async Task<IActionResult> CreateDish([FromForm] Dish dish, IFormFile? file)
        {
            var res = await _dishService.CreateDishAsync(dish, file);
            return CreateResult(res);
        }

        [HttpGet("restaurant/{restaurantId}")]
        public async Task<IActionResult> GetDishesByRestaurant(int restaurantId, [FromQuery] PagedRequest filter)
        {
            var res = await _dishService.GetDishByRestaurantIdAsync(restaurantId, filter);
            return CreateResult(res);
        }

        [Authorize(Roles = "business")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDish(int id, [FromForm] Dish updatedDish, IFormFile? file)
        {
            var res = await _dishService.UpdateDishAsync(id, updatedDish, file);
            return CreateResult(res);
        }

        [Authorize(Roles = "business")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDish(int id)
        {
            var res = await _dishService.DeleteDishAsync(id);
            return CreateResult(res);
        }
    }
}
