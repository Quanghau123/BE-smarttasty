using backend.Infrastructure.Helpers.Commons.Response;
using backend.Domain.Enums;
using backend.Domain.Models.Requests.Reservation;

namespace backend.Application.Interfaces
{
    public interface IReservationService
    {
        Task<ApiResponse<object>> CreateReservationAsync(CreateReservationRequest request);

        Task<ApiResponse<object>> UpdateStatusAsync(int reservationId, ReservationStatus newStatus, int changedBy, string? note);

        Task<ApiResponse<object>> GetReservationsByRestaurantAsync(int restaurantId);

        Task<ApiResponse<object>> GetReservationsByUserAsync(int userId);

        Task<ApiResponse<object>> DeleteReservationAsync(int reservationId, int userId);
        Task<ApiResponse<object>> DeleteReservationForBusinessAsync(int reservationId, int userId);
    }
}
