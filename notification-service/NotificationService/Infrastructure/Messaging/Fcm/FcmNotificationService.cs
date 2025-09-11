using Google.Apis.Auth.OAuth2;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using NotificationService.Application.Interfaces.Services;
using NotificationService.Application.DTOs.Fcm;

namespace NotificationService.Infrastructure.Messaging.Fcm
{
    public class FcmNotificationService : IFcmNotificationService
    {
        private readonly IConfiguration _config;
        private readonly ILogger<FcmNotificationService> _logger;
        private readonly HttpClient _httpClient;

        private const string MessagingScope = "https://www.googleapis.com/auth/firebase.messaging";
        private readonly string[] Scopes = new[] { MessagingScope };

        public FcmNotificationService(IConfiguration config, ILogger<FcmNotificationService> logger, HttpClient httpClient)
        {
            _config = config;
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task Send(FirebaseMessage message, string txId)
        {
            try
            {
                var token = await GetAccessToken(txId);

                var body = new
                {
                    message = new
                    {
                        token = message.Token,
                        topic = message.Topic,
                        notification = message.Notification,
                        data = message.Data
                    }
                };

                var json = JsonConvert.SerializeObject(body);
                var httpRequest = new HttpRequestMessage(HttpMethod.Post, _config["Firebase:Endpoint"])
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };

                httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await _httpClient.SendAsync(httpRequest);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    _logger.LogError("Error sending push notification. TxId={TxId}, StatusCode={Status}, Response={Response}",
                        txId, response.StatusCode, errorContent);
                }
                else
                {
                    _logger.LogInformation("Push notification sent successfully. TxId={TxId}", txId);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception while sending push notification, TxId={TxId}", txId);
            }
        }

        private async Task<string> GetAccessToken(string txId)
        {
            try
            {
                _logger.LogInformation("[{TxId}] Getting Firebase access token...", txId);

                // Chuyển \n thành xuống dòng thật
                var privateKeyRaw = _config["Firebase:PrivateKey"];
                if (string.IsNullOrEmpty(privateKeyRaw))
                {
                    throw new InvalidOperationException("Firebase private key is not configured.");
                }

                var privateKey = privateKeyRaw.Replace("\\n", "\n");

                var credential = new ServiceAccountCredential(
                    new ServiceAccountCredential.Initializer(_config["Firebase:ClientEmail"])
                    {
                        Scopes = Scopes
                    }.FromPrivateKey(privateKey) // dùng key đã được sửa
                );

                if (!await credential.RequestAccessTokenAsync(System.Threading.CancellationToken.None))
                {
                    throw new Exception("Unable to acquire Firebase access token.");
                }

                return credential.Token.AccessToken;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get Firebase token, TxId={TxId}", txId);
                throw;
            }
        }
    }
}
