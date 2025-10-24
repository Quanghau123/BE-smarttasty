using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ChatbotService.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace ChatbotService.Application.Services
{
    public class N8nWebhookService
    {
        private readonly HttpClient _httpClient;
        private readonly string _n8nUrl;
        private readonly IUserStatusService _userStatusService;

        public N8nWebhookService(HttpClient httpClient, IConfiguration config, IUserStatusService userStatusService)
        {
            _httpClient = httpClient;
            _n8nUrl = config["N8N_URL"] ?? string.Empty;
            _userStatusService = userStatusService;
        }

        public async Task<string> SendChatMessageAsync(string userId, string? text, string? imgText, IFormFile? imgPhoto)
        {
            var userSession = await _userStatusService.GetUserSessionAsync(userId);

            if (userSession == null)
                throw new Exception($"No active session for user {userId}");

            using var form = new MultipartFormDataContent();

            form.Add(new StringContent(userSession.UserId), "sessionId");
            form.Add(new StringContent(userSession.Username), "username");
            form.Add(new StringContent(userSession.Role), "role");
            form.Add(new StringContent(text ?? ""), "Text");
            form.Add(new StringContent(imgText ?? ""), "IMGText");

            if (imgPhoto != null)
            {
                var stream = imgPhoto.OpenReadStream();
                var fileContent = new StreamContent(stream);
                fileContent.Headers.ContentType = new MediaTypeHeaderValue(imgPhoto.ContentType);
                form.Add(fileContent, "IMGPhoto", imgPhoto.FileName);
            }

            var response = await _httpClient.PostAsync(_n8nUrl, form);
            var responseText = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();

            // Nếu n8n trả JSON (AI Agent reply)
            try
            {
                var doc = JsonDocument.Parse(responseText);
                if (doc.RootElement.TryGetProperty("reply", out var reply))
                    return reply.GetString() ?? responseText;
            }
            catch { }

            // Nếu trả plain text
            return responseText;
        }
    }
}
