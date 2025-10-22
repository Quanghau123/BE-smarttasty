namespace backend.Application.Interfaces
{
    public interface IUserSessionService
    {
        Task SetTokenAsync(int userId, string token, TimeSpan expires);
        Task<string?> GetTokenAsync(int userId);
        Task RemoveTokenAsync(int userId);
    }
}