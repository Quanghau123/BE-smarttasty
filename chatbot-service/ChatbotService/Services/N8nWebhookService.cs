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

        public N8nWebhookService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _n8nUrl = configuration["N8N_URL"]
            ?? configuration["N8N:BaseUrl"]
            ?? "http://localhost:5678";
        }

        public async Task SendOrderCreatedAsync(int orderId, decimal amount)
        {
            var dto = new { orderId, amount };
            var json = JsonSerializer.Serialize(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{_n8nUrl}/webhook/order_created", content);
            response.EnsureSuccessStatusCode();
        }
    }
}
