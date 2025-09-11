using Microsoft.Extensions.Logging;
using NotificationService.Application.Interfaces.Services;
using NotificationService.Infrastructure.Cache;
using System;
using System.Threading.Tasks;

namespace NotificationService.Application.Services
{
    public class RedisUserStatusService : IUserStatusService
    {
        private readonly RedisCacheService _redis;
        private readonly ILogger<RedisUserStatusService> _logger;

        public RedisUserStatusService(RedisCacheService redis, ILogger<RedisUserStatusService> logger)
        {
            _redis = redis;
            _logger = logger;
        }

        public async Task MarkOnlineAsync(string userId, DateTime timestamp)
        {
            await _redis.SetAsync($"user:{userId}:online", timestamp, TimeSpan.FromHours(2));
            _logger.LogInformation("User {UserId} marked online", userId);
        }

        public async Task MarkOfflineAsync(string userId)
        {
            await _redis.DeleteAsync($"user:{userId}:online");
            _logger.LogInformation("User {UserId} marked offline", userId);
        }

        public async Task<bool> IsOnlineAsync(string userId)
        {
            var exists = await _redis.GetAsync<DateTime?>($"user:{userId}:online");
            return exists.HasValue;
        }
    }
}
