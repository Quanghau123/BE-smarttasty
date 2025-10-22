using backend.Application.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;

namespace backend.Infrastructure.Cache
{
    public class RedisUserSessionService : IUserSessionService
    {
        private readonly IDistributedCache _cache;
        private const string KeyPrefix = "user:token:";

        public RedisUserSessionService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task SetTokenAsync(int userId, string token, TimeSpan expires)
        {
            var key = KeyPrefix + userId;
            var options = new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = expires };
            await _cache.SetStringAsync(key, token, options);
        }

        public async Task<string?> GetTokenAsync(int userId)
        {
            var key = KeyPrefix + userId;
            return await _cache.GetStringAsync(key);
        }

        public async Task RemoveTokenAsync(int userId)
        {
            var key = KeyPrefix + userId;
            await _cache.RemoveAsync(key);
        }
    }
}