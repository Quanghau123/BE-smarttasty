using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NotificationService.Application.Requests.Shared;

namespace NotificationService.Application.Services
{
    public class SocketClusterService : IDisposable
    {
        private readonly ILogger<SocketClusterService> _logger;
        private readonly IConfiguration _config;
        private readonly Uri _serverUri;
        private ClientWebSocket _client;
        private readonly SemaphoreSlim _sendLock = new(1, 1);
        private CancellationTokenSource _cts = new();
        private Task? _listenTask;
        private string? _authToken;

        public SocketClusterService(ILogger<SocketClusterService> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;

            var host = _config["SocketCluster:Host"];
            var port = _config.GetValue<int>("SocketCluster:Port");
            _serverUri = new Uri($"ws://{host}:{port}/ws");

            _client = new ClientWebSocket();
        }

        public async Task ConnectAsync(int maxRetry = 5)
        {
            int retryCount = 0;
            int delayMs = 1000;

            while (!_cts.Token.IsCancellationRequested)
            {
                try
                {
                    if (_client.State != WebSocketState.Open)
                    {
                        if (_listenTask != null && !_listenTask.IsCompleted)
                        {
                            _logger.LogWarning("Previous listen task still running, waiting...");
                            await Task.WhenAny(_listenTask, Task.Delay(5000, _cts.Token));
                        }

                        _client.Dispose();
                        _client = new ClientWebSocket();
                        await _client.ConnectAsync(_serverUri, _cts.Token);
                        _logger.LogInformation("SocketCluster connected: {Uri}", _serverUri);

                        // Tạo listen loop
                        _listenTask = Task.Run(() => ListenLoopAsync(_cts.Token));

                        // Login nếu cần
                        if (_config.GetValue<bool>("WsAuth:EnableAuth"))
                        {
                            await LoginAsync();
                        }
                    }
                    break;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to connect");
                    retryCount++;
                    if (retryCount > maxRetry)
                    {
                        _logger.LogError("Max retry reached ({MaxRetry}), giving up", maxRetry);
                        break;
                    }
                    _logger.LogInformation("Retrying in {Delay} ms...", delayMs);
                    await Task.Delay(delayMs, _cts.Token);
                    delayMs = Math.Min(delayMs * 2, 30000);
                }
            }
        }

        private async Task ListenLoopAsync(CancellationToken token)
        {
            var buffer = new byte[8192];

            try
            {
                while (!token.IsCancellationRequested && _client.State == WebSocketState.Open)
                {
                    var ms = new System.IO.MemoryStream();
                    WebSocketReceiveResult result;

                    do
                    {
                        result = await _client.ReceiveAsync(buffer, token);
                        if (result.MessageType == WebSocketMessageType.Close)
                        {
                            _logger.LogWarning("Socket closed by server");
                            await ConnectAsync();
                            return;
                        }
                        ms.Write(buffer, 0, result.Count);
                    } while (!result.EndOfMessage);

                    var msgJson = Encoding.UTF8.GetString(ms.ToArray());
                    Console.WriteLine("=== CLIENT LOG: Received raw JSON ===");
                    Console.WriteLine(msgJson);

                    var msg = JsonSerializer.Deserialize<WsMessageResp>(msgJson);

                    if (msg == null)
                    {
                        Console.WriteLine("=== CLIENT LOG: Deserialize returned null ===");
                        continue;
                    }

                    // Nếu là Login response, lấy token
                    if (msg.EventName == "Login")
                    {
                        if (msg.Data is JsonElement el && el.TryGetProperty("Token", out var tokenProp))
                        {
                            _authToken = tokenProp.GetString();
                            Console.WriteLine("=== CLIENT LOG: Received AuthToken ===");
                            Console.WriteLine(_authToken ?? "<null>");
                        }
                        else
                        {
                            Console.WriteLine("=== CLIENT LOG: Login Data missing Token field ===");
                            Console.WriteLine("Data type: " + msg.Data?.GetType());
                        }
                    }
                    else
                    {
                        Console.WriteLine("=== CLIENT LOG: Received message: " + msgJson);
                    }

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in ListenLoopAsync, reconnecting...");
                if (_client.State != WebSocketState.Open)
                    await ConnectAsync();
            }
        }

        private async Task LoginAsync()
        {
            var dataLogin = new
            {
                username = _config["WsAuth:Username"],
                password = _config["WsAuth:Password"]
            };

            var msg = new
            {
                EventName = "Login",
                Data = dataLogin
            };

            var json = JsonSerializer.Serialize(msg);
            var bytes = Encoding.UTF8.GetBytes(json);

            await _sendLock.WaitAsync();
            try
            {
                await _client.SendAsync(bytes, WebSocketMessageType.Text, true, _cts.Token);
            }
            finally
            {
                _sendLock.Release();
            }
        }

        public async Task SendNotificationAsync(ScReq scReq, string txId, long? schedule = null)
        {
            if (schedule.HasValue)
            {
                var delay = schedule.Value - DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                if (delay < 0) delay = 0;

                _ = Task.Run(async () =>
                {
                    await Task.Delay((int)delay);
                    await RealSendAsync(scReq, txId);
                });
            }
            else
            {
                await RealSendAsync(scReq, txId);
            }
        }

        private async Task RealSendAsync(ScReq scReq, string txId)
        {
            foreach (var channel in scReq.Channels ?? new List<string>())
            {
                _logger.LogInformation("[{TxId}] publish to channel {Channel}: {Params}",
                    txId, channel, JsonSerializer.Serialize(scReq.Params));

                var payload = new Dictionary<string, object>(scReq.Params ?? new Dictionary<string, object>())
                {
                    ["publishKey"] = _config["PublishKey"] ?? string.Empty
                };

                await InvokePublishAsync(channel, payload);
            }
        }

        private async Task InvokePublishAsync(string channel, object data)
        {
            var msg = new
            {
                EventName = "Publish",
                Channel = channel,
                Data = data,
                AuthToken = _authToken
            };

            var bytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(msg));

            await _sendLock.WaitAsync();
            try
            {
                await _client.SendAsync(bytes, WebSocketMessageType.Text, true, _cts.Token);
            }
            finally
            {
                _sendLock.Release();
            }

            _logger.LogInformation("Publish to channel {Channel}", channel);
        }

        public void Dispose()
        {
            _cts.Cancel();
            _client?.Dispose();
            _sendLock?.Dispose();
            _cts?.Dispose();
        }

        private class WsMessageResp
        {
            public string EventName { get; set; } = "";
            public string Channel { get; set; } = "";
            public object? Data { get; set; }
            public string? AuthToken { get; set; }
        }
    }
}
