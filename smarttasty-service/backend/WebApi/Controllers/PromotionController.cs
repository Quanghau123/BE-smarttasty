using backend.Application.DTOs.Promotion;
using backend.Domain.Models.Requests.Promotion;
using backend.Application.Interfaces;
using backend.Domain.Models;
using backend.Domain.Enums.Commons.Response;
using backend.Infrastructure.Helpers.Commons.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace backend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionsController : ControllerBase
    {
        private readonly IPromotionService _promotionService;

        public PromotionsController(IPromotionService promotionService)
        {
            _promotionService = promotionService;
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

        [HttpGet("restaurant/{restaurantId}")]
        public async Task<IActionResult> GetPromotionsByRestaurantId(int restaurantId)
        {
            var res = await _promotionService.GetPromotionsByRestaurantIdAsync(restaurantId);
            return CreateResult(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPromotion(int id)
        {
            var res = await _promotionService.GetPromotionByIdAsync(id);
            return CreateResult(res);
        }

        [Authorize(Roles = "business")]
        [HttpPost]
        public async Task<IActionResult> CreatePromotion([FromBody] CreatePromotionRequest dto)
        {
            dto.StartDate = DateTime.SpecifyKind(dto.StartDate, DateTimeKind.Utc);
            dto.EndDate = DateTime.SpecifyKind(dto.EndDate, DateTimeKind.Utc);

            var res = await _promotionService.CreatePromotionAsync(dto);
            return CreateResult(res);
        }

        [Authorize(Roles = "business")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePromotion(int id, [FromBody] Promotion updatedPromotion)
        {
            var res = await _promotionService.UpdatePromotionAsync(id, updatedPromotion);
            return CreateResult(res);
        }

        [Authorize(Roles = "business")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePromotion(int id)
        {
            var res = await _promotionService.DeletePromotionAsync(id);
            return CreateResult(res);
        }
    }
}
