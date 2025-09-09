using System.Threading.Tasks;
using NotificationService.Application.DTOs.KafkaPayload;

namespace NotificationService.Application.Interfaces.Services
{
    public interface INotificationHandler
    {
        Task HandleAsync(NotificationPayload payload, string txId);
    }
}
