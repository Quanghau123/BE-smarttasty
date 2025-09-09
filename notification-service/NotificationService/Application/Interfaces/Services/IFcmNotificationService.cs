using NotificationService.Application.DTOs.Fcm;
using System.Threading.Tasks;

namespace NotificationService.Application.Interfaces.Services
{
    public interface IFcmNotificationService
    {
        Task Send(FirebaseMessage message, string txId);
    }
}
