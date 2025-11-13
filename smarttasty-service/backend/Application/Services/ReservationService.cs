using backend.Application.Interfaces;
using backend.Application.Interfaces.Commons;
using backend.Domain.Models;
using backend.Domain.Models.Requests.Reservation;
using backend.Infrastructure.Data;
using backend.Infrastructure.Helpers.Commons.Response;
using backend.Domain.Enums.Commons.Response;
using backend.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using backend.Infrastructure.Messaging.Kafka;
using backend.Application.DTOs.Kafka;
using backend.Application.DTOs.KafkaPayload;

namespace backend.Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly ApplicationDbContext _context;
        private readonly KafkaProducerService _kafkaProducer;
        private readonly INotificationService _notificationService;

        public ReservationService(
            ApplicationDbContext context,
            KafkaProducerService kafkaProducer,
            INotificationService notificationService)
        {
            _context = context;
            _kafkaProducer = kafkaProducer;
            _notificationService = notificationService;
        }

        public async Task<ApiResponse<object>> CreateReservationAsync(CreateReservationRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.ContactName))
                return new ApiResponse<object>(ErrorCode.ValidationError, "ContactName is required");

            if (string.IsNullOrWhiteSpace(request.Email))
                return new ApiResponse<object>(ErrorCode.ValidationError, "ContactEmail is required");

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

            // Notification DB
            var notification = new Notification
            {
                UserId = reservation.RestaurantId,
                Type = NotificationType.NewReservation,
                Message = $"New reservation from {request.ContactName}",
                CreatedAt = DateTime.UtcNow
            };
            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();

            var restaurant = await _context.Restaurants
                            .Include(r => r.Owner)
                            .FirstOrDefaultAsync(r => r.Id == reservation.RestaurantId);

            if (restaurant == null)
                return new ApiResponse<object>(ErrorCode.NotFound, "Restaurant not found");

            // Kafka email
            var payload = new ReservationCreatedPayload
            {
                ReservationId = reservation.Id,
                RestaurantId = reservation.RestaurantId,
                BusinessEmail = restaurant.Owner.Email,
                ContactName = request.ContactName,
                ContactEmail = request.Email,
                ArrivalDate = reservation.ArrivalDate,
                ReservationTime = reservation.ReservationTime
            };
            var emailEnvelope = new KafkaEnvelope<ReservationCreatedPayload>
            {
                Target = "notification-service",
                Event = "reservation.created",
                Payload = payload
            };
            await _kafkaProducer.SendMessageAsync(emailEnvelope, "notification-reservation");

            // Realtime notification
            await _notificationService.SendRealtimeNotificationAsync(
                restaurant.Owner.UserId,
                "Có đơn đặt bàn mới!",
                $"Khách {request.ContactName} vừa đặt bàn tại {restaurant.Name}.",
                request.UserId,
                UserRole.user.ToString(),
                new Dictionary<string, string>
                {
                    { "ReservationId", reservation.Id.ToString() },
                    { "RestaurantId", restaurant.Id.ToString() }
                }
            );

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
                return new ApiResponse<object>(ErrorCode.NotFound, "Reservation not found");

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

            var reservationWithDetails = await _context.Reservations
                .Include(r => r.Customers)
                .Include(r => r.Restaurant)
                    .ThenInclude(res => res!.Owner)
                .FirstOrDefaultAsync(r => r.Id == reservationId);

            if (reservationWithDetails?.Restaurant?.Owner != null)
            {
                var customer = reservationWithDetails.Customers?.FirstOrDefault();
                if (customer != null)
                {
                    var payload = new ReservationStatusUpdatedPayload
                    {
                        ReservationId = reservationWithDetails.Id,
                        RestaurantName = reservationWithDetails.Restaurant?.Name,
                        ContactName = customer.ContactName ?? string.Empty,
                        ContactEmail = customer.Email ?? string.Empty,
                        NewStatus = newStatus.ToString(),
                        Note = note
                    };
                    var envelope = new KafkaEnvelope<ReservationStatusUpdatedPayload>
                    {
                        Target = "notification-service",
                        Event = "reservation.status_updated",
                        Payload = payload
                    };
                    await _kafkaProducer.SendMessageAsync(envelope, "notification-reservation");

                    if (reservationWithDetails.Restaurant?.Owner != null && customer != null)
                    {
                        await _notificationService.SendRealtimeNotificationAsync(
                            reservationWithDetails.Restaurant.Owner.UserId,
                            "Trạng thái đặt bàn đã thay đổi",
                            $"Đơn đặt bàn của {customer.ContactName} tại {reservationWithDetails.Restaurant.Name} đã chuyển sang trạng thái {newStatus}.",
                            changedBy,
                            UserRole.business.ToString(),
                            new Dictionary<string, string>
                            {
            { "ReservationId", reservationWithDetails.Id.ToString() },
            { "RestaurantId", reservationWithDetails.RestaurantId.ToString() }
                            }
                        );
                    }
                }
            }

            return new ApiResponse<object>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Reservation status updated",
                Data = new { reservation.Id, reservation.Status }
            };
        }

        public async Task<ApiResponse<object>> GetReservationsByRestaurantAsync(int restaurantId)
        {
            var reservationsEntities = await _context.Reservations
                .Include(r => r.Customers)
                .Where(r => r.RestaurantId == restaurantId)
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();

            var userIds = reservationsEntities.Select(r => r.UserId).Distinct().ToList();
            var users = await _context.Users
                .Where(u => userIds.Contains(u.UserId))
                .ToListAsync();
            var userDict = users.ToDictionary(u => u.UserId);

            static string? GetDisplayName(object? user)
            {
                if (user == null) return null;
                var t = user.GetType();
                string? TryProp(string name) => t.GetProperty(name)?.GetValue(user)?.ToString();
                return TryProp("FullName")
                    ?? (TryProp("FirstName") != null || TryProp("LastName") != null
                        ? $"{TryProp("FirstName") ?? ""} {TryProp("LastName") ?? ""}".Trim()
                        : TryProp("Name") ?? TryProp("UserName") ?? TryProp("Email"));
            }

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
                Customers = r.Customers?.Select(c => new { c.ContactName, c.Phone, c.Email }).ToList(),
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
            // Load entities từ DB, Include các liên quan
            var reservationsEntities = await _context.Reservations
                .Include(r => r.Restaurant)
                .Include(r => r.User)
                .Where(r => r.UserId == userId)
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync(); // Lấy ra danh sách trước

            // Map sang DTO / anonymous object sau khi đã load (linq-to-objects)
            var reservations = reservationsEntities.Select(r => new
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
                r.CreatedAt,
                UserEmail = r.User != null ? r.User.Email : null,
                UserPhone = r.User != null ? r.User.Phone : null
            }).ToList();

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

            var reservationWithDetails = await _context.Reservations
                .Include(r => r.Restaurant)
                    .ThenInclude(res => res!.Owner)
                .Include(r => r.Customers)
                .FirstOrDefaultAsync(r => r.Id == reservationId);

            if (reservationWithDetails?.Restaurant?.Owner != null)
            {
                var customer = reservationWithDetails.Customers?.FirstOrDefault();
                if (customer != null)
                {
                    var payload = new ReservationCanceledByUserPayload
                    {
                        ReservationId = reservationWithDetails.Id,
                        RestaurantId = reservationWithDetails.RestaurantId,
                        BusinessEmail = reservationWithDetails.Restaurant.Owner.Email,
                        ContactName = customer.ContactName ?? string.Empty,
                        ContactEmail = customer.Email ?? string.Empty,
                        ArrivalDate = reservationWithDetails.ArrivalDate,
                        ReservationTime = reservationWithDetails.ReservationTime
                    };

                    var envelope = new KafkaEnvelope<ReservationCanceledByUserPayload>
                    {
                        Target = "notification-service",
                        Event = "reservation.canceled_by_user",
                        Payload = payload
                    };
                    await _kafkaProducer.SendMessageAsync(envelope, "notification-reservation");

                    await _notificationService.SendRealtimeNotificationAsync(
                        reservationWithDetails.Restaurant.Owner.UserId,
                        "Đơn đặt bàn đã bị hủy",
                        $"Đơn đặt bàn của khách hàng {customer.ContactName} đã bị hủy bởi khách hàng {customer.ContactName}.",
                        userId,
                        UserRole.user.ToString(),
                        new Dictionary<string, string>
                        {
                            { "ReservationId", reservationWithDetails.Id.ToString() },
                            { "RestaurantId", reservationWithDetails.RestaurantId.ToString() }
                        }
                    );
                }
            }

            return new ApiResponse<object>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Reservation cancelled",
                Data = new { reservation.Id, reservation.Status }
            };
        }

        public async Task<ApiResponse<object>> DeleteReservationForBusinessAsync(int reservationId, int userId)
        {
            var reservation = await _context.Reservations.FindAsync(reservationId);
            if (reservation == null)
                return new ApiResponse<object>(ErrorCode.NotFound, "Reservation not found");

            reservation.Status = ReservationStatus.Cancelled;

            var history = new ReservationStatusHistory
            {
                ReservationId = reservation.Id,
                Status = ReservationStatus.Cancelled,
                ChangedAt = DateTime.UtcNow,
                ChangedBy = userId,
                Note = "Business canceled the reservation"
            };
            _context.ReservationStatusHistories.Add(history);
            await _context.SaveChangesAsync();

            var reservationWithDetails = await _context.Reservations
                .Include(r => r.Restaurant)
                    .ThenInclude(res => res!.Owner)
                .Include(r => r.Customers)
                .FirstOrDefaultAsync(r => r.Id == reservationId);

            if (reservationWithDetails?.Restaurant?.Owner != null)
            {
                var customer = reservationWithDetails.Customers?.FirstOrDefault();
                if (customer != null)
                {
                    var payload = new ReservationCanceledByBusinessPayload
                    {
                        ReservationId = reservationWithDetails.Id,
                        RestaurantId = reservationWithDetails.RestaurantId,
                        BusinessEmail = reservationWithDetails.Restaurant.Owner.Email,
                        ContactName = customer.ContactName ?? string.Empty,
                        ContactEmail = customer.Email ?? string.Empty,
                        ArrivalDate = reservationWithDetails.ArrivalDate,
                        ReservationTime = reservationWithDetails.ReservationTime
                    };

                    var envelope = new KafkaEnvelope<ReservationCanceledByBusinessPayload>
                    {
                        Target = "notification-service",
                        Event = "reservation.canceled_by_business",
                        Payload = payload
                    };
                    await _kafkaProducer.SendMessageAsync(envelope, "notification-reservation");

                    await _notificationService.SendRealtimeNotificationAsync(
                        reservationWithDetails.Restaurant.Owner.UserId,
                        "Đơn đặt bàn đã bị hủy",
                        $"Đơn đặt bàn của khách hàng {customer.ContactName} đã bị hủy bởi nhà hàng {reservationWithDetails.Restaurant.Name}.",
                        userId,
                        UserRole.business.ToString(),
                        new Dictionary<string, string>
                        {
                            { "ReservationId", reservationWithDetails.Id.ToString() },
                            { "RestaurantId", reservationWithDetails.RestaurantId.ToString() }
                        }
                    );
                }
            }

            return new ApiResponse<object>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Reservation cancelled by business",
                Data = new { reservation.Id, reservation.Status }
            };
        }

    }
}
