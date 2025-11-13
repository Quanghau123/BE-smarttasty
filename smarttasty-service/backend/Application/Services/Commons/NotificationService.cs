using backend.Application.DTOs.Kafka;
using backend.Application.DTOs.KafkaPayload;
using backend.Application.Interfaces.Commons;
using backend.Infrastructure.Messaging.Kafka;
using backend.Domain.Enums;

namespace backend.Application.Services.Commons
{
    public class NotificationService : INotificationService
    {
        private readonly KafkaProducerService _kafkaProducer;

        public NotificationService(KafkaProducerService kafkaProducer)
        {
            _kafkaProducer = kafkaProducer;
        }

        public async Task SendRealtimeNotificationAsync(
            int targetUserId,
            string title,
            string message,
            int requestedByUserId,
            string requestedByRole,
            Dictionary<string, string>? metadata = null)
        {
            var notifPayload = new SendNotificationPayload
            {
                TargetUserIds = new List<string> { targetUserId.ToString() },
                Title = title,
                Message = message,
                Type = NotificationType.Info,
                Priority = NotificationPriority.High,
                Metadata = metadata ?? new Dictionary<string, string>(),
                RequestedByUserId = requestedByUserId.ToString(),
                RequestedByRole = Enum.TryParse<UserRole>(requestedByRole, out var role) ? role : null
            };

            var notifEnvelope = new KafkaEnvelope<SendNotificationPayload>
            {
                Target = "notification-service",
                Event = "SendNotification",
                Payload = notifPayload
            };

            await _kafkaProducer.SendMessageAsync(notifEnvelope, "notifications");
        }
    }
}
