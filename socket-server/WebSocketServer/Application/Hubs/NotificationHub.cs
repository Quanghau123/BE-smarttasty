using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebSocketServer.Application.DTOs.KafkaPayload;
using System.Collections.Concurrent;

namespace WebSocketServer.Application.Hubs
{
    public class NotificationHub : Hub
    {
        private readonly ILogger<NotificationHub> _logger;
        private readonly HttpClient _httpClient;
        private static readonly ConcurrentDictionary<string, DateTime> _lastPing = new();
        private static readonly ConcurrentDictionary<string, ConcurrentBag<string>> _userConnections = new();

        public NotificationHub(ILogger<NotificationHub> logger, IHttpClientFactory httpFactory)
        {
            _logger = logger;
            _httpClient = httpFactory.CreateClient("NotificationService");
        }

        public override async Task OnConnectedAsync()
        {
            var userId = Context.UserIdentifier;
            _logger.LogInformation("User {UserId} connected, ConnectionId={ConnectionId}", userId, Context.ConnectionId);

            if (!string.IsNullOrEmpty(userId))
            {
                _userConnections.GetOrAdd(userId, _ => new ConcurrentBag<string>()).Add(Context.ConnectionId);

                try
                {
                    await _httpClient.PostAsJsonAsync($"api/userstatus/online/{userId}", new { timestamp = System.DateTime.UtcNow });
                }
                catch { }
            }

            // fetch offline notifications
            try
            {
                var response = await _httpClient.GetFromJsonAsync<NotificationPayload[]>($"api/notifications/offline/pop/{userId}");
                if (response != null)
                {
                    foreach (var notif in response)
                    {
                        _logger.LogInformation("[OfflineNotification] Sending to UserId={UserId}, Title={Title}", userId, notif.Title);
                        await Clients.User(userId).SendAsync("ReceiveNotification", notif.Title, notif.Message)
                            .ContinueWith(t =>
                            {
                                if (t.IsFaulted)
                                    _logger.LogError(t.Exception, "[OfflineNotification] Failed to send to UserId={UserId}", userId);
                                else
                                    _logger.LogInformation("[OfflineNotification] Sent to UserId={UserId}, Title={Title}", userId, notif.Title);
                            });
                    }
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "[OfflineNotification] Error fetching for UserId={UserId}", userId);
            }

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(System.Exception? exception)
        {
            var userId = Context.UserIdentifier;
            if (!string.IsNullOrEmpty(userId) && _userConnections.TryGetValue(userId, out var bag))
            {
                bag.TryTake(out var _);
                if (bag.IsEmpty)
                {
                    try
                    {
                        await _httpClient.DeleteAsync($"api/userstatus/offline/{userId}");
                    }
                    catch { }
                }
            }

            await base.OnDisconnectedAsync(exception);
        }

        public async Task PingHeartbeat()
        {
            var userId = Context.UserIdentifier;
            if (string.IsNullOrEmpty(userId)) return;

            var now = DateTime.UtcNow;
            lock (_lastPing)
            {
                if (_lastPing.TryGetValue(userId, out var last) && (now - last).TotalSeconds < 5) return;
                _lastPing[userId] = now;
            }

            try
            {
                await _httpClient.PostAsJsonAsync($"api/userstatus/online/{userId}", new { timestamp = now });
            }
            catch { }
        }

        public async Task JoinRestaurantRoom(string restaurantId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, restaurantId);
        }
    }
}
