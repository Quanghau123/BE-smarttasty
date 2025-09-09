using backend.Domain.Enums;

namespace backend.Application.DTOs.KafkaPayload
{
    public class SendNotificationPayload
    {
        public List<string> TargetUserIds { get; set; } = new();
        public List<UserRole>? TargetRoles { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;

        public NotificationType Type { get; set; } = NotificationType.Info;
        public NotificationPriority Priority { get; set; } = NotificationPriority.Normal;

        public Dictionary<string, string>? Metadata { get; set; }

        public string? RequestedByUserId { get; set; }
        public UserRole? RequestedByRole { get; set; }
    }
}
