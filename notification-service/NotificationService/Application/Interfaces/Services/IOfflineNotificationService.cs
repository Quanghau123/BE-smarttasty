using NotificationService.Application.DTOs.KafkaPayload;

namespace NotificationService.Application.Interfaces.Services
{
    public interface IOfflineNotificationService
    {
        Task<IEnumerable<NotificationPayload>> GetOfflineNotificationsAsync(string userId);
        Task<IEnumerable<NotificationPayload>> PopOfflineNotificationsAsync(string userId);
        Task SaveOfflineNotificationAsync(string userId, NotificationPayload payload);
        Task DeleteOfflineNotificationAsync(string userId, string notificationId);
    }
}
