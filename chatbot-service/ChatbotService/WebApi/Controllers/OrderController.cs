using Microsoft.AspNetCore.Mvc;
using ChatbotService.Application.Services;
using ChatbotService.Application.DTOs;
using System.Threading.Tasks;

namespace ChatbotService.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatControllerJson : ControllerBase
    {
        private readonly N8nWebhookService _n8nWebhook;

        public ChatControllerJson(N8nWebhookService n8nWebhook)
        {
            _n8nWebhook = n8nWebhook;
        }

        [HttpPost("send-form")]
        public async Task<IActionResult> SendMessage([FromForm] ChatMessageFormDto message)
        {
            var botReply = await _n8nWebhook.SendChatMessageAsync(
                message.AccessToken, // FE chỉ gửi token
                message.Text,
                message.Image
            );

            return Ok(new
            {
                user = message.Text,
                bot = botReply
            });
        }
    }
}
