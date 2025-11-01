using backend.Application.Interfaces;
using backend.Domain.Models;
using backend.Domain.Models.Requests.Reservation;
using backend.Infrastructure.Data;
using backend.Infrastructure.Helpers.Commons.Response;
using backend.Domain.Enums.Commons.Response;
using backend.Domain.Enums;
using Microsoft.EntityFrameworkCore;

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

        public async Task<ApiResponse<object>> GetReservationsByRestaurantAsync(int restaurantId)
        {
            // Load reservations (entities) first to avoid complex EF translations
            var reservationsEntities = await _context.Reservations
                .Include(r => r.Customers)
                .Where(r => r.RestaurantId == restaurantId)
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();

            // Load related users for name lookup
            var userIds = reservationsEntities.Select(r => r.UserId).Distinct().ToList();
            var users = await _context.Users
                .Where(u => userIds.Contains(u.UserId))
                .ToListAsync();
            var userDict = users.ToDictionary(u => u.UserId);

            // Helper to get best display name via reflection/fallbacks
            static string? GetDisplayName(object? user)
            {
                if (user == null) return null;
                var t = user.GetType();
                string? TryProp(string name)
                {
                    var p = t.GetProperty(name);
                    if (p == null) return null;
                    var v = p.GetValue(user);
                    return v?.ToString();
                }

                return TryProp("FullName")
                    ?? (TryProp("FirstName") != null || TryProp("LastName") != null
                        ? $"{TryProp("FirstName") ?? ""} {TryProp("LastName") ?? ""}".Trim()
                        : TryProp("Name") ?? TryProp("UserName") ?? TryProp("Email"));
            }

            // Map to DTO-like anonymous objects
            var reservations = reservationsEntities.Select(r => new
            {
                r.Id,
                r.UserId,
                UserName = userDict.TryGetValue(r.UserId, out var u) ? GetDisplayName(u) : null,
                r.RestaurantId,
                r.AdultCount,
                r.ChildCount,
                r.ArrivalDate,
                r.ReservationTime,
                r.Note,
                r.Status,
                r.CreatedAt,
                Customers = r.Customers?.Select(c => new
                {
                    c.ContactName,
                    c.Phone,
                    c.Email
                }).ToList(),
                LatestHistory = _context.ReservationStatusHistories
                    .Where(h => h.ReservationId == r.Id)
                    .OrderByDescending(h => h.ChangedAt)
                    .Select(h => new { h.Status, h.Note, h.ChangedAt })
                    .FirstOrDefault()
            }).ToList();

            return new ApiResponse<object>(ErrorCode.Success, "Fetched successfully", reservations);
        }

        public async Task<ApiResponse<object>> GetReservationsByUserAsync(int userId)
        {
            var reservations = await _context.Reservations
                .Include(r => r.Restaurant)
                .Where(r => r.UserId == userId)
                .OrderByDescending(r => r.CreatedAt)
                .Select(r => new
                {
                    r.Id,
                    r.RestaurantId,
                    RestaurantName = r.Restaurant != null ? r.Restaurant.Name : null,
                    r.AdultCount,
                    r.ChildCount,
                    r.ArrivalDate,
                    r.ReservationTime,
                    r.Note,
                    r.Status,
                    r.CreatedAt
                })
                .ToListAsync();

            return new ApiResponse<object>(ErrorCode.Success, "Fetched successfully", reservations);
        }
        public async Task<ApiResponse<object>> DeleteReservationAsync(int reservationId, int userId)
        {
            var reservation = await _context.Reservations.FindAsync(reservationId);

            if (reservation == null || reservation.UserId != userId)
                return new ApiResponse<object>(ErrorCode.NotFound, "Reservation not found");

            if (reservation.Status != ReservationStatus.Pending)
                return new ApiResponse<object>(ErrorCode.ValidationError, "Only pending reservations can be cancelled");

            reservation.Status = ReservationStatus.Cancelled;

            var history = new ReservationStatusHistory
            {
                ReservationId = reservation.Id,
                Status = ReservationStatus.Cancelled,
                ChangedAt = DateTime.UtcNow,
                ChangedBy = userId,
                Note = "User canceled the reservation"
            };

            _context.ReservationStatusHistories.Add(history);
            await _context.SaveChangesAsync();

            return new ApiResponse<object>(ErrorCode.Success, "Reservation canceled successfully");
        }

    }
}
