namespace NotificationService.Application.DTOs.KafkaPayload
{
    public class UserLoggedInPayload
    {
        public string UserId { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Jwt { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
