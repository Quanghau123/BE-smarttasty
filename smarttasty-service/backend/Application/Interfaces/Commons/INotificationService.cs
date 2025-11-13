namespace backend.Application.Interfaces.Commons
{
    public interface INotificationService
    {
        Task SendRealtimeNotificationAsync(
            int targetUserId,
            string title,
            string message,
            int requestedByUserId,
            string requestedByRole,
            Dictionary<string, string>? metadata = null);
    }
}
