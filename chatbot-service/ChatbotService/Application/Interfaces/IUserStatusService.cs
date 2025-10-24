namespace ChatbotService.Application.Interfaces
{
    public interface IUserStatusService
    {
        Task UpdateUserSessionAsync(string userId, string username, string role, string token, bool isOnline);
        Task<string?> GetUserTokenAsync(string userId);
        Task<string?> GetUserRoleAsync(string userId);
        Task<UserStatusService.UserSession?> GetUserSessionAsync(string userId);
    }
}
