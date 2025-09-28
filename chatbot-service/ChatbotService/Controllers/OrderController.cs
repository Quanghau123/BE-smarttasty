using Microsoft.AspNetCore.Mvc;
using ChatbotService.Services;

namespace ChatbotService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly N8nWebhookService _n8nWebhook;

        public OrderController(N8nWebhookService n8nWebhook)
        {
            _n8nWebhook = n8nWebhook;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderDto order)
        {
            await _n8nWebhook.SendOrderCreatedAsync(order.Id, order.Amount);
            return Ok(new { message = "Order created & sent to n8n" });
        }
    }

    public class OrderDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
    }
}
