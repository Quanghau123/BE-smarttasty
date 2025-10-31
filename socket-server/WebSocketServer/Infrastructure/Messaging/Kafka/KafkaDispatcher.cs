using Microsoft.Extensions.Logging;
using System.Text.Json;
using WebSocketServer.Application.DTOs.KafkaPayload;
using WebSocketServer.Application.Services;
using System.Threading.Tasks;

namespace WebSocketServer.Infrastructure.Messaging.Kafka
{
    public class KafkaDispatcher
    {
        private readonly ILogger<KafkaDispatcher> _logger;
        private readonly SocketNotificationService _socketService;

        public KafkaDispatcher(ILogger<KafkaDispatcher> logger, SocketNotificationService socketService)
        {
            _logger = logger;
            _socketService = socketService;
        }

        public async Task DispatchAsync(string @event, JsonElement payload, string txId)
        {
            _logger.LogInformation("Received event {Event}, TxId={TxId}", @event, txId);

            switch (@event)
            {
                case "RealtimeNotification":
                    var notifPayload = JsonSerializer.Deserialize<NotificationPayload>(payload.GetRawText());
                    if (notifPayload != null)
                        await _socketService.PushRealtimeNotificationAsync(notifPayload);
                    break;

                case "restaurant.rating.updated":
                    var ratingPayload = JsonSerializer.Deserialize<RatingUpdatedPayload>(payload.GetRawText());
                    if (ratingPayload != null)
                        await _socketService.PushRestaurantRatingUpdateAsync(ratingPayload);
                    break;

                default:
                    _logger.LogWarning("Unknown event: {Event}, TxId={TxId}", @event, txId);
                    break;
            }
        }
    }
}
