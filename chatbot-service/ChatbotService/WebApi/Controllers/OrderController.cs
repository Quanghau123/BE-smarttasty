using Microsoft.AspNetCore.Mvc;
using ChatbotService.Application.Services;
using System.Threading.Tasks;

namespace ChatbotService.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly N8nWebhookService _n8nWebhook;

        public ChatController(N8nWebhookService n8nWebhook)
        {
            _n8nWebhook = n8nWebhook;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromForm] ChatMessageDto message)
        {
            // Gửi dữ liệu đến n8n và chờ phản hồi
            var botReply = await _n8nWebhook.SendChatMessageAsync(
                message.SessionId,
                message.Text,
                message.ImgText,
                message.ImgPhoto
            );

            return Ok(new
            {
                user = message.Text,
                bot = botReply
            });
        }
    }

    public class ChatMessageDto
    {
        public string SessionId { get; set; } = "";
        public string Text { get; set; } = "";
        public string? ImgText { get; set; }
        public IFormFile? ImgPhoto { get; set; }
    }
}
