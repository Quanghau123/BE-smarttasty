namespace backend.Application.DTOs.KafkaPayload
{
    public class PasswordResetRequestedPayload
    {
        public string UserId { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public string ResetLink { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
    }
}