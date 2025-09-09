using NotificationService.Application.DTOs.KafkaPayload;
using NotificationService.Application.Interfaces.Repositories;
using NotificationService.Application.Interfaces.Services;

namespace NotificationService.Application.Services
{
    public class OfflineNotificationService : IOfflineNotificationService
    {
        private readonly IOfflineNotificationRepository _repo;

        public OfflineNotificationService(IOfflineNotificationRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<NotificationPayload>> GetOfflineNotificationsAsync(string userId)
        {
            return await _repo.GetPendingAsync(userId);
        }

        public async Task<IEnumerable<NotificationPayload>> PopOfflineNotificationsAsync(string userId)
        {
            var notifications = await _repo.GetPendingAsync(userId);
            foreach (var notif in notifications)
            {
                if (notif.Metadata != null && notif.Metadata.TryGetValue("txId", out var txId))
                {
                    await _repo.DeleteAsync(userId, txId.ToString()!);
                }
            }
            return notifications;
        }

        public async Task SaveOfflineNotificationAsync(string userId, NotificationPayload payload)
        {
            await _repo.SaveAsync(userId, payload);
        }

        public async Task DeleteOfflineNotificationAsync(string userId, string notificationId)
        {
            await _repo.DeleteAsync(userId, notificationId);
        }
    }
}
