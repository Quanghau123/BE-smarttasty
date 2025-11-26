using System.Threading.Tasks;
using NotificationService.Application.DTOs.KafkaPayload;

namespace NotificationService.Application.Interfaces.Services
{
    public interface INotificationHandler
    {
        Task HandleAsync(NotificationPayload payload, string txId);
        Task HandlePasswordResetAsync(PasswordResetRequestedPayload payload, string txId);
        Task HandleReservationCreatedAsync(ReservationCreatedPayload payload, string txId);
        Task HandleReservationStatusUpdatedAsync(ReservationStatusUpdatedPayload payload, string txId);
        Task HandleReservationCanceledByUserAsync(ReservationCanceledByUserPayload payload, string txId);
        Task HandleReservationCanceledByBusinessAsync(ReservationCanceledByBusinessPayload payload, string txId);
        Task HandleOrderDeliveryStatusUpdatedAsync(OrderDeliveryStatusUpdatedPayload payload, string txId);

    }
}
