using NotificationService.Application.DTOs.KafkaPayload;

namespace NotificationService.Application.Interfaces.Repositories
{
    public interface IOfflineNotificationRepository
    {
        Task SaveAsync(string userId, NotificationPayload payload);
        Task<List<NotificationPayload>> GetPendingAsync(string userId);
        Task DeleteAsync(string userId, string notificationId);
    }

}