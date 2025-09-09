using Microsoft.AspNetCore.Mvc;

namespace WebSocketServer.Controllers
{
    [ApiController]
    [Route("api/health")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok(new { status = "WebSocket server running" });
    }
}
