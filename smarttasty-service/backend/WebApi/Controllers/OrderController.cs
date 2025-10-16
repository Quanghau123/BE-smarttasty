using Microsoft.AspNetCore.Mvc;
using backend.Application.Interfaces;
using backend.Domain.Models.Requests.Order;
using backend.Domain.Enums.Commons.Response;
using backend.Infrastructure.Helpers.Commons.Response;
using backend.Domain.Enums;

namespace backend.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
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

        // ---------------- CRUD ----------------
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderRequest request)
        {
            var res = await _orderService.CreateOrderAsync(request);
            return CreateResult(res);
        }

        [HttpPost("{orderId}/items")]
        public async Task<IActionResult> AddItem(int orderId, [FromBody] AddItemRequest req)
        {
            if (req == null)
                return BadRequest(new ApiResponse<object> { ErrCode = ErrorCode.ValidationError, ErrMessage = "Request body is required." });

            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<object> { ErrCode = ErrorCode.ValidationError, ErrMessage = "Invalid request payload." });

            var result = await _orderService.AddItemOrderAsync(orderId, req.DishId, req.Quantity);

            return result.ErrCode switch
            {
                ErrorCode.Success => Ok(result),
                ErrorCode.ValidationError => BadRequest(result),
                ErrorCode.NotFound => NotFound(result),
                _ => StatusCode(500, result)
            };
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _orderService.GetByIdAsync(id);
            return CreateResult(res);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateOrderRequest request)
        {
            var res = await _orderService.UpdateOrderAsync(id, request);
            return CreateResult(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _orderService.DeleteOrderAsync(id);
            return CreateResult(res);
        }

        // ---------------- Update Status ----------------
        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateOrderStatus(int id, [FromQuery] OrderStatus newStatus)
        {
            var res = await _orderService.UpdateOrderStatusAsync(id, newStatus);
            return CreateResult(res);
        }

        [HttpPatch("{id}/delivery-status")]
        public async Task<IActionResult> UpdateDeliveryStatus(int id, [FromQuery] DeliveryStatus newStatus)
        {
            var res = await _orderService.UpdateDeliveryStatusAsync(id, newStatus);
            return CreateResult(res);
        }

        // ---------------- Queries ----------------
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUser(int userId)
        {
            var res = await _orderService.GetOrdersByUserAsync(userId);
            return CreateResult(res);
        }

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(OrderStatus status)
        {
            var res = await _orderService.GetOrdersByStatusAsync(status);
            return CreateResult(res);
        }
    }
}
