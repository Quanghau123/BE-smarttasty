using NotificationService.Application.DTOs.KafkaPayload;
using NotificationService.Application.Interfaces.Services;
using NotificationService.Application.Interfaces.Repositories;
using NotificationService.Application.DTOs.Kafka;
using NotificationService.Infrastructure.Messaging.Kafka;
using Microsoft.Extensions.Logging;
using NotificationService.Application.Requests.Shared;

namespace NotificationService.Application.Services
{
    public class NotificationHandler : INotificationHandler
    {
        private readonly ILogger<NotificationHandler> _logger;
        private readonly IUserStatusService _userStatus;
        private readonly IOfflineNotificationRepository _offlineRepo;
        private readonly KafkaProducerService _kafkaProducer;
        private readonly EmailService _emailService;

        public NotificationHandler(
      ILogger<NotificationHandler> logger,
      IUserStatusService userStatus,
      IOfflineNotificationRepository offlineRepo,
      KafkaProducerService kafkaProducer,
      EmailService emailService)
        {
            _logger = logger;
            _userStatus = userStatus;
            _offlineRepo = offlineRepo;
            _kafkaProducer = kafkaProducer;
            _emailService = emailService; // <-- assign
        }

        public async Task HandleAsync(NotificationPayload payload, string txId)
        {
            if (payload?.TargetUserIds == null || !payload.TargetUserIds.Any())
            {
                _logger.LogWarning("HandleAsync called with empty targets, TxId={TxId}", txId);
                return;
            }

            var tasks = new List<Task>();

            foreach (var receiverId in payload.TargetUserIds)
            {
                tasks.Add(Task.Run(async () =>
                {
                    try
                    {
                        var isOnline = await _userStatus.IsOnlineAsync(receiverId);

                        if (isOnline)
                        {
                            _logger.LogInformation("📩 Sent realtime notification to {UserId}: {Title} {Message}",
                                receiverId, payload.Title, payload.Message);

                            var envelope = new KafkaEnvelope<NotificationPayload>
                            {
                                TxId = txId,
                                Target = receiverId,
                                Event = "RealtimeNotification",
                                Payload = payload
                            };

                            try
                            {
                                await _kafkaProducer.SendMessageAsync(envelope, "realtime-notification");
                            }
                            catch (Exception ex)
                            {
                                _logger.LogError(ex, "Failed to produce realtime notification for {UserId} TxId={TxId}", receiverId, txId);
                                // optionally fallback to offline store
                                await _offlineRepo.SaveAsync(receiverId, payload);
                            }
                        }
                        else
                        {
                            _logger.LogInformation("💤 User {UserId} offline, save to MongoDB queue: {Title} {Message}",
                                receiverId, payload.Title, payload.Message);
                            try
                            {
                                await _offlineRepo.SaveAsync(receiverId, payload);
                            }
                            catch (Exception ex)
                            {
                                _logger.LogError(ex, "Failed to save offline notification for {UserId} TxId={TxId}", receiverId, txId);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error handling notification for receiver {Receiver} TxId={TxId}", receiverId, txId);
                    }
                }));
            }

            await Task.WhenAll(tasks);
        }

        public async Task HandlePasswordResetAsync(PasswordResetRequestedPayload payload, string txId)
        {
            _logger.LogInformation("Handling PasswordResetRequested for UserId={UserId} tx={TxId}", payload.UserId, txId);

            var emailReq = new EmailReq
            {
                Email = payload.Email,
                Subject = "Đặt lại mật khẩu - SmartTasty",
                EmailTemplate = "UIMailPasswordReset.html",
                Params = new Dictionary<string, object>
                {
                    { "username", payload.Username },
                    { "resetLink", payload.ResetLink },
                    { "token", payload.Token },
                    { "expiresAt", payload.ExpiresAt.ToString("u") }
                }
            };

            try
            {
                await _emailService.SendEmailAsync(emailReq, txId);
                _logger.LogInformation("Password reset email sent for UserId={UserId} tx={TxId}", payload.UserId, txId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending password reset email for UserId={UserId} tx={TxId}", payload.UserId, txId);
            }
        }
    }
}
