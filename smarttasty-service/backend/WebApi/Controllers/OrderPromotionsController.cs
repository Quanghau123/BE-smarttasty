using backend.Domain.Models.Requests.OrderPromotion;
using backend.Application.Interfaces;
using backend.Domain.Enums.Commons.Response;
using backend.Infrastructure.Helpers.Commons.Response;
using Microsoft.AspNetCore.Mvc;

namespace backend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderPromotionsController : ControllerBase
    {
        private readonly IOrderPromotionService _service;

        public OrderPromotionsController(IOrderPromotionService service)
        {
            _service = service;
        }

        private IActionResult CreateResult<T>(ApiResponse<T> res)
        {
            return StatusCode(MapErrorCodeToStatus(res.ErrCode), res);
        }

        private int MapErrorCodeToStatus(ErrorCode code) => code switch
        {
            ErrorCode.Success => 200,
            ErrorCode.NotFound => 404,
            ErrorCode.ValidationError => 400,
            _ => 500
        };

        [HttpPost]
        public async Task<IActionResult> CreateOrderPromotion([FromBody] CreateOrderPromotionRequest dto)
        {
            var res = await _service.CreateOrderPromotionAsync(dto);
            return CreateResult(res);
        }

        [HttpGet("promotion/{promotionId}")]
        public async Task<IActionResult> GetOrderPromotion(int promotionId)
        {
            var res = await _service.GetByPromotionIdAsync(promotionId);
            return CreateResult(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderPromotion(int id)
        {
            var res = await _service.DeleteOrderPromotionAsync(id);
            return CreateResult(res);
        }
    }
}
