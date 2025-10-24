using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using System;
using System.Threading.Tasks;
using ChatbotService.Application.Interfaces;

public class UserStatusService : IUserStatusService
{
    private readonly IDistributedCache _cache;
    private readonly DistributedCacheEntryOptions _cacheOptions;

    public UserStatusService(IDistributedCache cache)
    {
        _cache = cache;
        _cacheOptions = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(2)
        };
    }

    public async Task UpdateUserSessionAsync(string userId, string username, string role, string token, bool isOnline)
    {
        var session = new
        {
            UserId = userId,
            Username = username,
            Role = role,
            Token = token,
            IsOnline = isOnline,
            LastUpdated = DateTime.UtcNow
        };

        var json = JsonSerializer.Serialize(session);
        await _cache.SetStringAsync(GetKey(userId), json, _cacheOptions);
    }

    public async Task<string?> GetUserTokenAsync(string userId)
    {
        var json = await _cache.GetStringAsync(GetKey(userId));
        if (string.IsNullOrEmpty(json)) return null;
        using var doc = JsonDocument.Parse(json);
        if (doc.RootElement.TryGetProperty("Token", out var t)) return t.GetString();
        return null;
    }

    public async Task<string?> GetUserRoleAsync(string userId)
    {
        var json = await _cache.GetStringAsync(GetKey(userId));
        if (string.IsNullOrEmpty(json)) return null;
        using var doc = JsonDocument.Parse(json);
        if (doc.RootElement.TryGetProperty("Role", out var r)) return r.GetString();
        return null;
    }

    public async Task<UserSession?> GetUserSessionAsync(string userId)
    {
        var json = await _cache.GetStringAsync(GetKey(userId));
        return string.IsNullOrEmpty(json) ? null : JsonSerializer.Deserialize<UserSession>(json);
    }

    private string GetKey(string userId) => $"session:{userId}";

    public record UserSession(string UserId, string Username, string Role, string Token, bool IsOnline, DateTime LastUpdated);
}
