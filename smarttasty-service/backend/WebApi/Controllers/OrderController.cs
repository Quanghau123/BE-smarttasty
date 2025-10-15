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

        // ---------------- Order Items ----------------
        [HttpPost("{id}/items")]
        public async Task<IActionResult> AddItem(int id, [FromQuery] int dishId, [FromQuery] int quantity)
        {
            var res = await _orderService.AddItemAsync(id, dishId, quantity);
            return CreateResult(res);
        }

        [HttpDelete("{orderId}/items/{orderItemId}")]
        public async Task<IActionResult> RemoveItem(int orderId, int orderItemId)
        {
            var res = await _orderService.RemoveItemAsync(orderId, orderItemId);
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
