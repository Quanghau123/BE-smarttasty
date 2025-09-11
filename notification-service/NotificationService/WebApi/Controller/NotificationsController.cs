using Microsoft.AspNetCore.Mvc;
using NotificationService.Application.DTOs.KafkaPayload;
using NotificationService.Application.Interfaces.Services;

namespace NotificationService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationsController : ControllerBase
    {
        private readonly IOfflineNotificationService _offlineService;
        private readonly ILogger<NotificationsController> _logger;

        public NotificationsController(IOfflineNotificationService offlineService, ILogger<NotificationsController> logger)
        {
            _offlineService = offlineService;
            _logger = logger;
        }

        [HttpGet("offline/{userId}")]
        public async Task<ActionResult<IEnumerable<NotificationPayload>>> GetOfflineNotifications(string userId)
        {
            _logger.LogInformation("Querying offline for userId={UserId}", userId);
            var notifications = await _offlineService.GetOfflineNotificationsAsync(userId);
            return Ok(notifications);
        }

        [HttpGet("offline/pop/{userId}")]
        public async Task<ActionResult<IEnumerable<NotificationPayload>>> PopOfflineNotifications(string userId)
        {
            var notifications = await _offlineService.PopOfflineNotificationsAsync(userId);
            return Ok(notifications);
        }

        [HttpDelete("offline/{userId}/{notificationId}")]
        public async Task<IActionResult> DeleteOfflineNotification(string userId, string notificationId)
        {
            await _offlineService.DeleteOfflineNotificationAsync(userId, notificationId);
            return NoContent();
        }
    }
}
