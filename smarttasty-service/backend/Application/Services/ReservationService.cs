using backend.Application.Interfaces;
using backend.Domain.Models;
using backend.Domain.Models.Requests.Reservation;
using backend.Infrastructure.Data;
using backend.Infrastructure.Helpers.Commons.Response;
using backend.Domain.Enums.Commons.Response;
using backend.Domain.Enums;

namespace backend.Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly ApplicationDbContext _context;

        public ReservationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse<object>> CreateReservationAsync(CreateReservationRequest request)
        {
            var reservation = new Reservation
            {
                UserId = request.UserId,
                RestaurantId = request.RestaurantId,
                AdultCount = request.AdultCount,
                ChildCount = request.ChildCount,
                ArrivalDate = request.ArrivalDate.ToUniversalTime(),
                ReservationTime = request.ReservationTime,
                Note = request.Note,
                Status = ReservationStatus.Pending,
                CreatedAt = DateTime.UtcNow
            };

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            var bookingCustomer = new BookingCustomer
            {
                ReservationId = reservation.Id,
                ContactName = request.ContactName,
                Phone = request.Phone,
                Email = request.Email
            };

            _context.BookingCustomers.Add(bookingCustomer);

            var notification = new Notification
            {
                UserId = reservation.RestaurantId,
                Type = NotificationType.NewReservation,
                Message = $"New reservation from {request.ContactName}",
                CreatedAt = DateTime.UtcNow
            };
            _context.Notifications.Add(notification);

            await _context.SaveChangesAsync();

            return new ApiResponse<object>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Reservation created",
                Data = new
                {
                    reservation.Id,
                    reservation.UserId,
                    reservation.RestaurantId,
                    reservation.Status
                }
            };
        }

        public async Task<ApiResponse<object>> UpdateStatusAsync(int reservationId, ReservationStatus newStatus, int changedBy, string? note)
        {
            var reservation = await _context.Reservations.FindAsync(reservationId);
            if (reservation == null)
            {
                return new ApiResponse<object>(ErrorCode.NotFound, "Reservation not found");
            }

            reservation.Status = newStatus;

            var history = new ReservationStatusHistory
            {
                ReservationId = reservation.Id,
                Status = newStatus,
                ChangedAt = DateTime.UtcNow,
                ChangedBy = changedBy,
                Note = note
            };

            _context.ReservationStatusHistories.Add(history);
            await _context.SaveChangesAsync();

            return new ApiResponse<object>(ErrorCode.Success, "Status updated");
        }
    }
}
