using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ChatbotService.Services
{
    public class N8nWebhookService
    {
        private readonly HttpClient _httpClient;
        private readonly string _n8nUrl;
        private readonly SmartTastyServiceClient _smartTastyClient;

        public N8nWebhookService(HttpClient httpClient, IConfiguration configuration, SmartTastyServiceClient smartTastyClient)
        {
            _httpClient = httpClient;
            _n8nUrl = configuration["N8N_URL"];
            _smartTastyClient = smartTastyClient;
        }

        public async Task SendOrderCreatedAsync(int userId, int orderId, decimal amount)
        {
            // 1. Lấy token từ smarttasty-service
            var userToken = await _smartTastyClient.GetUserTokenAsync(userId);

            // 2. Map payload n8n
            var payload = new
            {
                sessionId = userToken, // token user
                text = $"Order amount: {amount}"
            };

            var json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_n8nUrl, content);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            // Optional: Console.WriteLine(responseBody);
        }
    }
}
