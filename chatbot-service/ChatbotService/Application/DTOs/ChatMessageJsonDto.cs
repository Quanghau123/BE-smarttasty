namespace ChatbotService.Application.DTOs
{
    public class ChatMessageFormDto
    {
        public string AccessToken { get; set; } = "";
        public string Text { get; set; } = "";
        public IFormFile? Image { get; set; }
    }
}
