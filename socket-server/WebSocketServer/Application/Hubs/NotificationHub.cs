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
        private readonly HttpClient _httpClient;

        public NotificationHub(ILogger<NotificationHub> logger, IHttpClientFactory httpFactory)
        {
            _logger = logger;
            _httpClient = httpFactory.CreateClient("NotificationService");
        }

        public override async Task OnConnectedAsync()
        {
            var userId = Context.UserIdentifier;
            _logger.LogInformation("User connected: {ConnectionId}, UserId={UserId}", Context.ConnectionId, userId);

            try
            {
                var response = await _httpClient.GetFromJsonAsync<NotificationPayload[]>($"api/notifications/offline/pop/{userId}");
                if (response != null && !string.IsNullOrEmpty(userId))
                {
                    var tasks = response.Select(notif => Clients.User(userId)
                        .SendAsync("ReceiveNotification", notif.Title, notif.Message)
                        .ContinueWith(t =>
                        {
                            if (t.IsFaulted)
                                _logger.LogError(t.Exception, "Failed to send notification to {UserId}", userId);
                            else
                                _logger.LogInformation("Sent offline notification to {UserId}: {Title}", userId, notif.Title);
                        })
                    );

                    await Task.WhenAll(tasks);
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

        //Thêm endpoint để FE join room
        public async Task JoinRestaurantRoom(string restaurantId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, restaurantId);
            _logger.LogInformation("User {ConnectionId} joined restaurant room {RestaurantId}", Context.ConnectionId, restaurantId);
        }
    }
}
