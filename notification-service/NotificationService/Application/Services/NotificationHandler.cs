using NotificationService.Application.DTOs.KafkaPayload;
using NotificationService.Application.Interfaces.Services;
using NotificationService.Application.Interfaces.Repositories;
using NotificationService.Application.DTOs.Kafka;
using NotificationService.Infrastructure.Messaging.Kafka;
using Microsoft.Extensions.Logging;

namespace NotificationService.Application.Services
{
    public class NotificationHandler : INotificationHandler
    {
        private readonly ILogger<NotificationHandler> _logger;
        private readonly IUserStatusService _userStatus;
        private readonly IOfflineNotificationRepository _offlineRepo;
        private readonly KafkaProducerService _kafkaProducer;

        public NotificationHandler(
            ILogger<NotificationHandler> logger,
            IUserStatusService userStatus,
            IOfflineNotificationRepository offlineRepo,
            KafkaProducerService kafkaProducer)
        {
            _logger = logger;
            _userStatus = userStatus;
            _offlineRepo = offlineRepo;
            _kafkaProducer = kafkaProducer;
        }

        public async Task HandleAsync(NotificationPayload payload, string txId)
        {
            foreach (var receiverId in payload.TargetUserIds)
            {
                var isOnline = await _userStatus.IsOnlineAsync(receiverId);

                if (isOnline)
                {
                    _logger.LogInformation("📩 Sent realtime notification to {UserId}: {Title} {Message}",
                        receiverId, payload.Title, payload.Message);
                    // TODO: push qua WebSocket/SignalR
                    var envelope = new KafkaEnvelope<NotificationPayload>
                    {
                        TxId = txId,
                        Target = receiverId,
                        Event = "RealtimeNotification",
                        Payload = payload
                    };

                    // Gửi qua KafkaProducerService
                    await _kafkaProducer.SendMessageAsync(envelope, "realtime-notification");
                }
                else
                {
                    _logger.LogInformation("💤 User {UserId} offline, save to MongoDB queue: {Title} {Message}",
                        receiverId, payload.Title, payload.Message);
                    await _offlineRepo.SaveAsync(receiverId, payload);
                }
            }
        }
    }
}
