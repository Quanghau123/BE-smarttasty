using Microsoft.Extensions.Logging;
using System.Text.Json;
using NotificationService.Application.Interfaces.Services;
using NotificationService.Application.DTOs.KafkaPayload;
using System.Threading.Tasks;

namespace NotificationService.Infrastructure.Messaging.Kafka
{
    public class KafkaDispatcher
    {
        private readonly ILogger<KafkaDispatcher> _logger;
        private readonly INotificationHandler _notificationHandler;
        private readonly IUserStatusService _userStatusService;

        public KafkaDispatcher(ILogger<KafkaDispatcher> logger, INotificationHandler notificationHandler, IUserStatusService userStatusService)
        {
            _logger = logger;
            _notificationHandler = notificationHandler;
            _userStatusService = userStatusService;
        }

        public async Task DispatchAsync(string @event, JsonElement payload, string txId)
        {
            _logger.LogInformation("Received event {Event}, TxId={TxId}, Payload={Payload}",
                @event, txId, payload.GetRawText());

            switch (@event)
            {
                case "UserLoggedIn":
                    try
                    {
                        var loginPayload = JsonSerializer.Deserialize<UserLoggedInPayload>(payload.GetRawText());
                        if (loginPayload != null)
                        {
                            _logger.LogInformation("Deserialized UserLoggedIn payload for UserId={UserId}, Timestamp={Timestamp}",
                                loginPayload.UserId, loginPayload.Timestamp);

                            await _userStatusService.MarkOnlineAsync(loginPayload.UserId, loginPayload.Timestamp);

                            _logger.LogInformation("User {UserId} marked online, TxId={TxId}", loginPayload.UserId, txId);
                        }
                        else
                        {
                            _logger.LogWarning("Failed to deserialize UserLoggedIn payload, TxId={TxId}", txId);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error handling UserLoggedIn event, TxId={TxId}", txId);
                    }
                    break;

                case "SendNotification":
                    try
                    {
                        var notifPayload = JsonSerializer.Deserialize<NotificationPayload>(payload.GetRawText());
                        if (notifPayload != null)
                        {
                            _logger.LogInformation("Deserialized SendNotification payload for TargetUsers={Targets}, Title={Title}",
                                string.Join(",", notifPayload.TargetUserIds), notifPayload.Title);

                            await _notificationHandler.HandleAsync(notifPayload, txId);

                            _logger.LogInformation("Notification handled successfully, TxId={TxId}", txId);
                        }
                        else
                        {
                            _logger.LogWarning("Failed to deserialize SendNotification payload, TxId={TxId}", txId);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error handling SendNotification event, TxId={TxId}", txId);
                    }
                    break;

                case "PasswordResetRequested":
                    try
                    {
                        var resetPayload = JsonSerializer.Deserialize<PasswordResetRequestedPayload>(payload.GetRawText());
                        if (resetPayload != null)
                        {
                            await _notificationHandler.HandlePasswordResetAsync(resetPayload, txId);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error handling PasswordResetRequested event, TxId={TxId}", txId);
                    }
                    break;

                case "reservation.created":
                    try
                    {
                        var reservationPayload = JsonSerializer.Deserialize<ReservationCreatedPayload>(payload.GetRawText());
                        if (reservationPayload != null)
                        {
                            await _notificationHandler.HandleReservationCreatedAsync(reservationPayload, txId);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error handling ReservationCreated event, TxId={TxId}", txId);
                    }
                    break;
                case "reservation.status_updated":
                    try
                    {
                        var statusPayload = JsonSerializer.Deserialize<ReservationStatusUpdatedPayload>(payload.GetRawText());
                        if (statusPayload != null)
                        {
                            await _notificationHandler.HandleReservationStatusUpdatedAsync(statusPayload, txId);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error handling reservation.status_updated event, TxId={TxId}", txId);
                    }
                    break;

                case "reservation.canceled_by_user":
                    try
                    {
                        var cancelPayload = JsonSerializer.Deserialize<ReservationCanceledByUserPayload>(payload.GetRawText());
                        if (cancelPayload != null)
                        {
                            await _notificationHandler.HandleReservationCanceledByUserAsync(cancelPayload, txId);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error handling reservation.canceled_by_user event, TxId={TxId}", txId);
                    }
                    break;

                case "reservation.canceled_by_business":
                    try
                    {
                        var cancelPayload = JsonSerializer.Deserialize<ReservationCanceledByBusinessPayload>(payload.GetRawText());
                        if (cancelPayload != null)
                        {
                            await _notificationHandler.HandleReservationCanceledByBusinessAsync(cancelPayload, txId);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error handling reservation.canceled_by_business event, TxId={TxId}", txId);
                    }
                    break;

                default:
                    _logger.LogWarning("Unknown event: {Event}, TxId={TxId}", @event, txId);
                    break;
            }
        }
    }
}