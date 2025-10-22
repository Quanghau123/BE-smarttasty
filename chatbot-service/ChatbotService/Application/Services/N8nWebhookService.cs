using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ChatbotService.Application.Interfaces;

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
            _n8nUrl = config["N8N_URL"];
            _userStatusService = userStatusService;
        }

        public async Task SendOrderCreatedAsync(string userId, int orderId, decimal amount)
        {
            var token = await _userStatusService.GetUserTokenAsync(userId);
            var role = await _userStatusService.GetUserRoleAsync(userId);

            if (string.IsNullOrEmpty(token))
                throw new Exception($"No active session for user {userId}");

            var payload = new
            {
                sessionId = token,
                role,
                text = $"Order {orderId} created. Amount: {amount}"
            };

            var json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(_n8nUrl, content);
            response.EnsureSuccessStatusCode();
        }
    }
}
