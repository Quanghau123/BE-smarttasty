using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace NotificationService.Infrastructure.Cache
{
    public class RedisCacheService : IDisposable
    {
        private readonly ILogger<RedisCacheService> _logger;
        private readonly ConnectionMultiplexer _redis;
        private readonly IDatabase _db;

        public RedisCacheService(IConfiguration config, ILogger<RedisCacheService> logger)
        {
            _logger = logger;

            var host = config["Redis:Host"] ?? "localhost";
            var port = config["Redis:Port"] ?? "6379";
            var password = config["Redis:Password"];

            var options = ConfigurationOptions.Parse($"{host}:{port}");
            if (!string.IsNullOrEmpty(password))
                options.Password = password;

            _redis = ConnectionMultiplexer.Connect(options);
            _db = _redis.GetDatabase();

            _logger.LogInformation("Redis connected at {Host}:{Port}", host, port);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan? expiry = null)
        {
            var json = JsonSerializer.Serialize(value);
            await _db.StringSetAsync(key, json, expiry);
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            var value = await _db.StringGetAsync(key);
            if (value.IsNullOrEmpty) return default;
            return JsonSerializer.Deserialize<T>(value!);
        }

        public async Task<bool> DeleteAsync(string key)
        {
            return await _db.KeyDeleteAsync(key);
        }

        public void Dispose()
        {
            _redis?.Dispose();
        }
    }
}
