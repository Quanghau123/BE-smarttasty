using backend.Domain.Enums;
using backend.Application.Interfaces;
using backend.Application.Interfaces.Commons;
using backend.Domain.Models;
using backend.Domain.Models.Requests.Restaurant;
using backend.Domain.Models.Requests.Filters;
using backend.Infrastructure.Helpers.Commons.Response;
using backend.Domain.Enums.Commons.Response;
using backend.Application.DTOs.Restaurant;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IUserContextService _userContext;

        public RestaurantController(
            IRestaurantService restaurantService,
            IUserContextService userContext)
        {
            _restaurantService = restaurantService;
            _userContext = userContext;
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

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PagedRequest filter)
        {
            var result = await _restaurantService.GetAllRestaurantsAsync(filter);
            return CreateResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) =>
            CreateResult(await _restaurantService.GetRestaurantByIdAsync(id));

        [Authorize(Roles = "business")]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateRestaurantRequest request)
        {
            request.OwnerId = _userContext.UserId;
            return CreateResult(await _restaurantService.CreateNewRestaurantAsync(request));
        }

        [Authorize(Roles = "admin,business")]
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateRestaurantRequest request)
        {
            return CreateResult(await _restaurantService.UpdateRestaurantAsync(request));
        }

        [Authorize(Roles = "admin,business")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) =>
            CreateResult(await _restaurantService.DeleteRestaurantAsync(id));

        [Authorize(Roles = "business")]
        [HttpGet("owner")]
        public async Task<IActionResult> GetByOwner()
        {
            var ownerId = _userContext.UserId;
            return CreateResult(await _restaurantService.GetRestaurantsByOwnerIdAsync(ownerId));
        }

        [Authorize(Roles = "admin")]
        [HttpGet("search-owners")]
        public async Task<IActionResult> SearchRestaurantsByOwnerInfo([FromQuery] string keyword)
        {
            var result = await _restaurantService.SearchRestaurantsByOwnerKeywordAsync(keyword);
            return CreateResult(result);
        }

        [HttpGet("category/{category}")]
        public async Task<IActionResult> GetByCategory(string category)
        {
            if (!Enum.TryParse(typeof(RestaurantCategory), category, ignoreCase: true, out var parsed))
            {
                return BadRequest(new ApiResponse<object>
                {
                    ErrCode = ErrorCode.ValidationError,
                    ErrMessage = "Category không hợp lệ"
                });
            }

            return CreateResult(await _restaurantService.GetRestaurantsByCategoryAsync((RestaurantCategory)parsed));
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string q)
        {
            var result = await _restaurantService.SearchRestaurantsAsync(q);
            return Ok(result);
        }

        [HttpGet("search/suggestions")]
        public async Task<IActionResult> GetSuggestions([FromQuery] string q)
                  => CreateResult(new ApiResponse<List<string>>
                  {
                      ErrCode = ErrorCode.Success,
                      Data = await _restaurantService.GetSuggestionsAsync(q)
                  });

        [Authorize(Roles = "admin")]
        [HttpPatch("{id}/status")]
        public async Task<IActionResult> ChangeStatus(int id, [FromQuery] RestaurantStatus status)
        {
            if (!Enum.IsDefined(typeof(RestaurantStatus), status))
            {
                return BadRequest(new ApiResponse<object>
                {
                    ErrCode = ErrorCode.ValidationError,
                    ErrMessage = "Invalid status"
                });
            }
            return CreateResult(await _restaurantService.ChangeRestaurantStatusAsync(id, status));
        }

        [HttpGet("nearby")]
        public async Task<IActionResult> GetNearbyRestaurants([FromQuery] double lat, [FromQuery] double lng)
                    => CreateResult(new ApiResponse<List<RestaurantDto>>
                    {
                        ErrCode = ErrorCode.Success,
                        Data = await _restaurantService.GetNearbyRestaurantsAsync(lat, lng)
                    });
    }
}
