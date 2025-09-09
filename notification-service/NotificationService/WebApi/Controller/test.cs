//using Microsoft.AspNetCore.Mvc;
//using System.Threading.Tasks;
//using NotificationService.Application.Requests.Shared;
//using NotificationService.Application.Services;
//namespace NotificationService.WebApi.Controller
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class NotificationController : ControllerBase
//    {
//        private readonly EmailService _emailService;

//        public NotificationController(EmailService emailService)
//        {
//            _emailService = emailService;
//        }

//        // POST: api/notification/send-email
//        [HttpPost("send-email")]
//        public async Task<IActionResult> SendEmail([FromBody] EmailReq req)
//        {
//            if (req == null || string.IsNullOrWhiteSpace(req.Email) || string.IsNullOrWhiteSpace(req.Subject))
//            {
//                return BadRequest(new { message = "Invalid email request" });
//            }

//            await _emailService.SendEmailAsync(req, Guid.NewGuid().ToString());
//            return Ok(new { message = "Email sent (if config is correct)" });
//        }

//    }
//}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NotificationService.Application.Requests.Shared;
using NotificationService.Application.Services;
namespace NotificationService.WebAPI.Controllers
{
    [ApiController]
    [Route("api/notification")]
    public class NotificationController : ControllerBase
    {
        private readonly SocketClusterService _socketService;
        private readonly ILogger<NotificationController> _logger;

        public NotificationController(SocketClusterService socketService, ILogger<NotificationController> logger)
        {
            _socketService = socketService;
            _logger = logger;
        }

        /// <summary>
        /// Test connect WebSocket
        /// </summary>
        [HttpGet("connect")]
        public async Task<IActionResult> Connect()
        {
            await _socketService.ConnectAsync();
            return Ok("Connected to SocketCluster");
        }

        /// <summary>
        /// Send notification ngay lập tức
        /// </summary>
        [HttpPost("send")]
        public async Task<IActionResult> SendNotification([FromBody] ScReq req)
        {
            var txId = Guid.NewGuid().ToString();
            await _socketService.SendNotificationAsync(req, txId);
            return Ok(new { TxId = txId, Message = "Notification sent immediately" });
        }

        /// <summary>
        /// Send notification theo lịch (schedule timestamp, ms từ epoch)
        /// </summary>
        [HttpPost("send-scheduled")]
        public async Task<IActionResult> SendScheduled([FromBody] ScheduledReq req)
        {
            var txId = Guid.NewGuid().ToString();
            await _socketService.SendNotificationAsync(req.ScReq, txId, req.ScheduleTime);
            return Ok(new { TxId = txId, Message = "Notification scheduled" });
        }
    }

    /// <summary>
    /// Wrapper để Postman truyền JSON schedule
    /// </summary>
    public class ScheduledReq
    {
        public ScReq ScReq { get; set; } = new();
        public long ScheduleTime { get; set; } // timestamp in milliseconds
    }
}

// using Microsoft.AspNetCore.Mvc;
// using NotificationService.Application.Services;
// using NotificationService.Application.DTOs.Notification;
// namespace NotificationService.WebApi.Controller
// {
//     [ApiController]
//     [Route("api/[controller]")]
//     public class TestController : ControllerBase
//     {
//         private readonly PushService _pushService;

//         public TestController(PushService pushService)
//         {
//             _pushService = pushService;
//         }

//         [HttpPost("send-user")]
//         public async Task<IActionResult> SendNotificationToUser([FromBody] NotificationPayload payload)
//         {
//             if (payload == null || payload.ReceiverIds.Count == 0)
//                 return BadRequest("ReceiverIds cannot be empty");

//             // Chuyển Dictionary<string,string> sang Dictionary<string, object>
//             var dataDictObject = (payload.Data ?? new Dictionary<string, string>())
//                                  .ToDictionary(k => k.Key, v => (object)v.Value);

//             // Gọi PushService
//             foreach (var userIdStr in payload.ReceiverIds)
//             {
//                 if (!int.TryParse(userIdStr, out int userId))
//                     continue;

//                 await _pushService.SendNotificationToUser(
//                     Guid.NewGuid().ToString(),
//                     userId,
//                     payload.Title,
//                     payload.Body,
//                     dataDictObject
//                 );
//             }

//             return Ok("Notification sent");
//         }

//         [HttpPost("send-all")]
//         public async Task<IActionResult> SendNotificationToAll([FromBody] NotificationPayload payload)
//         {
//             var dataDictObject = (payload.Data ?? new Dictionary<string, string>())
//                                  .ToDictionary(k => k.Key, v => (object)v.Value);

//             await _pushService.SendNotificationToAll(
//                 Guid.NewGuid().ToString(),
//                 payload.Title,
//                 payload.Body,
//                 dataDictObject
//             );

//             return Ok("Broadcast notification sent");
//         }
//     }
// }
