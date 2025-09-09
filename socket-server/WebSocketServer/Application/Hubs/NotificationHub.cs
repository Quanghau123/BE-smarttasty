using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebSocketServer.Application.DTOs.KafkaPayload;

namespace WebSocketServer.Application.Hubs
{
    public class NotificationHub : Hub
    {
        private readonly ILogger<NotificationHub> _logger;
        private readonly HttpClient _httpClient; // Gọi Notification-service API

        public NotificationHub(ILogger<NotificationHub> logger, IHttpClientFactory httpFactory)
        {
            _logger = logger;
            _httpClient = httpFactory.CreateClient("NotificationService");
        }

        public override async Task OnConnectedAsync()
        {
            var userId = Context.UserIdentifier;
            _logger.LogInformation("User connected: {ConnectionId}, UserId={UserId}", Context.ConnectionId, userId);

            // Gọi Notification-service API lấy offline notification
            try
            {
                var response = await _httpClient.GetFromJsonAsync<NotificationPayload[]>($"api/notifications/offline/pop/{userId}");
                if (response != null)
                {
                    foreach (var notif in response)
                    {
                        if (!string.IsNullOrEmpty(userId))
                        {
                            await Clients.User(userId)
                                .SendAsync("ReceiveNotification", notif.Title, notif.Message);

                            _logger.LogInformation("Sent offline notification to {UserId}: {Title}", userId, notif.Title);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error fetching offline notifications for {UserId}", userId);
            }

            await base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(System.Exception? exception)
        {
            _logger.LogInformation("User disconnected: {ConnectionId}", Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
