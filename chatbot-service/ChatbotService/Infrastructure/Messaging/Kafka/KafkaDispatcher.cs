using Microsoft.Extensions.Logging;
using System.Text.Json;
using ChatbotService.Application.DTOs.KafkaPayload;
using ChatbotService.Application.Interfaces;
using System.Threading.Tasks;

namespace ChatbotService.Infrastructure.Messaging.Kafka
{
    public class KafkaDispatcher
    {
        private readonly ILogger<KafkaDispatcher> _logger;
        private readonly IUserStatusService _userStatusService;

        public KafkaDispatcher(ILogger<KafkaDispatcher> logger, IUserStatusService userStatusService)
        {
            _logger = logger;
            _userStatusService = userStatusService;
        }

        public async Task DispatchAsync(string @event, JsonElement payload, string txId)
        {
            _logger.LogInformation("Received event {Event}, TxId={TxId}", @event, txId);

            switch (@event)
            {
                case "UserLoggedIn":
                    {
                        var data = JsonSerializer.Deserialize<UserLoggedInPayload>(payload.GetRawText());
                        if (data == null) break;

                        _logger.LogInformation("User {UserId} logged in, role={Role}", data.UserId, data.Role);

                        await _userStatusService.UpdateUserSessionAsync(
                            data.UserId,
                            data.Role,
                            data.Jwt,
                            isOnline: true);
                        break;
                    }

                case "UserTokenRefreshed":
                    {
                        var data = JsonSerializer.Deserialize<UserTokenRefreshedPayload>(payload.GetRawText());
                        if (data == null) break;

                        _logger.LogInformation("User {UserId} token refreshed", data.UserId);

                        await _userStatusService.UpdateUserSessionAsync(
                            data.UserId,
                            data.Role,
                            data.AccessToken,
                            isOnline: true);
                        break;
                    }

                default:
                    _logger.LogWarning("Unhandled Kafka event: {Event}", @event);
                    break;
            }
        }
    }
}
