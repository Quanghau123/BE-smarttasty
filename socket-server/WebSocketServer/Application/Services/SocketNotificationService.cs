using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using WebSocketServer.Application.DTOs.KafkaPayload;
using WebSocketServer.Application.Hubs;

namespace WebSocketServer.Application.Services
{
    public class SocketNotificationService
    {
        private readonly ILogger<SocketNotificationService> _logger;
        private readonly IHubContext<NotificationHub> _hub;

        public SocketNotificationService(ILogger<SocketNotificationService> logger, IHubContext<NotificationHub> hub)
        {
            _logger = logger;
            _hub = hub;
        }

        // Push notification trực tiếp từ Kafka tới client
        public async Task PushRealtimeNotificationAsync(NotificationPayload payload)
        {
            foreach (var userId in payload.TargetUserIds)
            {
                _logger.LogInformation("[RealtimeNotification] Sending to UserId={UserId}, Title={Title}", userId, payload.Title);
                await _hub.Clients.User(userId).SendAsync("ReceiveNotification", payload.Title, payload.Message)
                    .ContinueWith(t =>
                    {
                        if (t.IsFaulted)
                            _logger.LogError(t.Exception, "[RealtimeNotification] Failed to send to UserId={UserId}", userId);
                        else
                            _logger.LogInformation("[RealtimeNotification] Sent to UserId={UserId}, Title={Title}", userId, payload.Title);
                    });
            }
        }

        // Push cập nhật rating của nhà hàng
        public async Task PushRestaurantRatingUpdateAsync(RatingUpdatedPayload payload)
        {
            var message = new { type = "restaurant_rating_update", data = payload };
            await BroadcastToRestaurantRoomAsync(payload.RestaurantId.ToString(), message);
        }

        private async Task BroadcastToRestaurantRoomAsync(string restaurantId, object message)
        {
            _logger.LogInformation("[RoomBroadcast] Broadcasting to restaurant room {RoomName}", restaurantId);
            await _hub.Clients.Group(restaurantId).SendAsync("ReceiveRestaurantUpdate", message);
        }
    }
}
