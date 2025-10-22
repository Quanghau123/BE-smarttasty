using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ChatbotService.Services
{
    public class SmartTastyServiceClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public SmartTastyServiceClient(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _baseUrl = config["SmartTastyService:BaseUrl"];
        }

        public async Task<string> GetUserTokenAsync(string email, string password)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/user/login", new
            {
                Email = email,
                UserPassword = password
            });

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
            return result?.Data?.token;
        }

        public class LoginResponse
        {
            public int ErrCode { get; set; }
            public string ErrMessage { get; set; }
            public LoginData Data { get; set; }
        }

        public class LoginData
        {
            public string token { get; set; }
        }
    }

    public class GetTokenResponse
    {
        public string Token { get; set; }
    }
}
