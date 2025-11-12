using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using backend.Application.Interfaces;
using backend.Domain.Models.Requests.Favorite;
using backend.Domain.Enums.Commons.Response;
using backend.Infrastructure.Helpers.Commons.Response;
using Microsoft.AspNetCore.Authorization;
using CloudinaryDotNet.Actions;

namespace backend.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteService _favoriteService;

        public FavoriteController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
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

        [Authorize(Roles = "user,admin,business,staff")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateFavoriteRequest request)
        {
            var res = await _favoriteService.CreateFavoriteAsync(request);
            return CreateResult(res);
        }

        [Authorize(Roles = "user,admin,business,staff")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _favoriteService.DeleteAsync(id);
            return CreateResult(res);
        }

        [Authorize(Roles = "user,admin,business,staff")]
        [HttpGet("restaurant/{restaurantId}")]
        public async Task<IActionResult> GetByRestaurant(int restaurantId)
        {
            var res = await _favoriteService.GetFavoritesByRestaurantAsync(restaurantId);
            return CreateResult(res);
        }

    }
}