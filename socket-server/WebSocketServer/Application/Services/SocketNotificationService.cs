using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using WebSocketServer.Application.DTOs.KafkaPayload;
using WebSocketServer.Application.Hubs;
using System.Threading.Tasks;

namespace WebSocketServer.Application.Services
{
    public class SocketNotificationService
    {
        private readonly ILogger<SocketNotificationService> _logger;
        private readonly IHubContext<NotificationHub> _hub;

        public SocketNotificationService(
            ILogger<SocketNotificationService> logger,
            IHubContext<NotificationHub> hub)
        {
            _logger = logger;
            _hub = hub;
        }

        // Push notification trực tiếp từ Kafka tới client
        public async Task PushRealtimeNotificationAsync(NotificationPayload payload)
        {
            foreach (var userId in payload.TargetUserIds)
            {
                _logger.LogInformation("Pushing realtime notification to {UserId}: {Title}", userId, payload.Title);
                await _hub.Clients.User(userId)
                          .SendAsync("ReceiveNotification", payload.Title, payload.Message);
            }
        }
    }
}
