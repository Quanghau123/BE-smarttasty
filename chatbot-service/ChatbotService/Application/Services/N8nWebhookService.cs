using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using ChatbotService.Application.Interfaces;
using System.IO;

namespace ChatbotService.Application.Services
{
    public class N8nWebhookService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly string _n8nUrl;
        private readonly IUserStatusService _userStatusService;

        public N8nWebhookService(HttpClient httpClient, IConfiguration config, IUserStatusService userStatusService)
        {
            _httpClient = httpClient;
            _config = config;
            _n8nUrl = config["N8N_URL"] ?? string.Empty;
            _userStatusService = userStatusService;
        }

        public async Task<string> SendChatMessageAsync(string accessToken, string? text, IFormFile? imageFile)
        {
            // ✅ Xác thực token
            var jwtHelper = new JwtHelper(_config["JwtSettings:SecretKey"]);
            ClaimsPrincipal principal;
            try
            {
                principal = jwtHelper.ValidateToken(accessToken);
            }
            catch
            {
                throw new Exception("Invalid or expired token");
            }

            var userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value
                         ?? principal.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;

            if (string.IsNullOrEmpty(userId))
                throw new Exception("Cannot find userId in token");

            // ✅ Lấy session từ cache
            var userSession = await _userStatusService.GetUserSessionAsync(userId);
            if (userSession == null)
                throw new Exception($"No active session for user {userId}");

            // ✅ Tạo form-data
            var formData = new MultipartFormDataContent
    {
        { new StringContent(userSession.UserId), "sessionId" },
        { new StringContent(userSession.Username ?? ""), "username" },
        { new StringContent(userSession.Role ?? ""), "role" },
        { new StringContent(text ?? ""), "text" }
    };

            if (imageFile != null && imageFile.Length > 0)
            {
                var stream = imageFile.OpenReadStream();
                var fileContent = new StreamContent(stream);
                fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(imageFile.ContentType);
                formData.Add(fileContent, "image", imageFile.FileName);
            }

            var response = await _httpClient.PostAsync(_n8nUrl, formData);
            var responseText = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();

            return responseText;
        }
    }
}
