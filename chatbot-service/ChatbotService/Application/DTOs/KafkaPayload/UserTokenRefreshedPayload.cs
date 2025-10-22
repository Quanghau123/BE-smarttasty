namespace ChatbotService.Application.DTOs.KafkaPayload
{
    public class UserTokenRefreshedPayload
    {
        public string UserId { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
    }
}
