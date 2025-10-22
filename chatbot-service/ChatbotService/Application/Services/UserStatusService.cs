using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;
using ChatbotService.Application.Interfaces;

namespace ChatbotService.Application.Services
{
    public class UserStatusService : IUserStatusService
    {
        private readonly IMemoryCache _cache;

        public UserStatusService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public Task UpdateUserSessionAsync(string userId, string role, string token, bool isOnline)
        {
            var session = new
            {
                Role = role,
                Token = token,
                IsOnline = isOnline,
                LastUpdated = DateTime.UtcNow
            };
            _cache.Set($"session:{userId}", session, TimeSpan.FromHours(2));
            return Task.CompletedTask;
        }

        public Task<string?> GetUserTokenAsync(string userId)
        {
            if (_cache.TryGetValue($"session:{userId}", out dynamic session))
                return Task.FromResult(session?.Token as string);
            return Task.FromResult<string?>(null);
        }

        public Task<string?> GetUserRoleAsync(string userId)
        {
            if (_cache.TryGetValue($"session:{userId}", out dynamic session))
                return Task.FromResult(session?.Role as string);
            return Task.FromResult<string?>(null);
        }
    }
}