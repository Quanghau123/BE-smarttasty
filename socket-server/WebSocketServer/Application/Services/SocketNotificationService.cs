using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WebSocketServer.Application.DTOs.KafkaPayload;
using WebSocketServer.Application.Hubs;

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
            var tasks = payload.TargetUserIds.Select(userId =>
    _hub.Clients.User(userId)
        .SendAsync("ReceiveNotification", payload.Title, payload.Message)
);

            await Task.WhenAll(tasks);

        }

        // Push cập nhật rating của nhà hàng
        public async Task PushRestaurantRatingUpdateAsync(RatingUpdatedPayload payload)
        {
            var message = new
            {
                type = "restaurant_rating_update",
                data = payload
            };

            await BroadcastToRestaurantRoomAsync(payload.RestaurantId.ToString(), message);
        }

        private async Task BroadcastToRestaurantRoomAsync(string restaurantId, object message)
        {
            _logger.LogInformation("Broadcasting rating update to restaurant {RestaurantId}", restaurantId);
            await _hub.Clients.Group(restaurantId).SendAsync("ReceiveRestaurantUpdate", message);
        }
    }
}
