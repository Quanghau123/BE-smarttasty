using System;
using System.Threading.Tasks;

namespace NotificationService.Application.Interfaces.Services
{
    public interface IUserStatusService
    {
        Task MarkOnlineAsync(string userId, DateTime timestamp);
        Task MarkOfflineAsync(string userId);
        Task<bool> IsOnlineAsync(string userId);
    }
}
