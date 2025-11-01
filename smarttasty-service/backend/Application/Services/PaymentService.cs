using backend.Application.Interfaces;
using backend.Domain.Enums;
using backend.Domain.Models;
using backend.Application.DTOs.Payment;
using backend.Infrastructure.Data;
using backend.Infrastructure.Helpers.Commons.Response;
using backend.Domain.Enums.Commons.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Linq;

namespace backend.Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly ApplicationDbContext _db;
        private readonly IVNPayService _vnPayService;
        private readonly ICODService _codService;
        public PaymentService(ApplicationDbContext db, IVNPayService vnPayService, ICODService codService)
        {
            _db = db;
            _vnPayService = vnPayService;
            _codService = codService;
        }

        public async Task<ApiResponse<object>> AddPaymentAsync(Payment payment)
        {
            _db.Payments.Add(payment);
            await _db.SaveChangesAsync();
            return new ApiResponse<object>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Payment created successfully",
                Data = payment
            };
        }

        public async Task<bool> OrderExistsAsync(int orderId)
        {
            return await _db.Orders.AnyAsync(o => o.Id == orderId);
        }

        // Implements IPaymentService.GetPaymentByOrderIdAsync(string)
        public async Task<Payment?> GetPaymentByOrderIdAsync(string orderId)
        {
            if (int.TryParse(orderId, out int id))
            {
                return await GetPaymentByOrderIdAsync(id);
            }
            return null;
        }

        public async Task<Payment?> GetPaymentByOrderIdAsync(int orderId)
        {
            return await _db.Payments
                .Include(p => p.Order)
                    .ThenInclude(o => o.OrderItems)
                        .ThenInclude(oi => oi.Dish)
                .Include(p => p.TransactionLogs)
                .FirstOrDefaultAsync(p => p.OrderId == orderId);
        }

        public async Task<ApiResponse<object>> UpdatePaymentSuccess(Payment payment, string transactionNo)
        {
            if (payment.Method == PaymentMethod.COD)
            {
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.ValidationError,
                    ErrMessage = "COD payment cannot be auto-confirmed",
                    Data = null
                };
            }

            payment.Status = PaymentStatus.Success;
            payment.TransactionId = transactionNo;
            payment.PaidAt = DateTime.UtcNow;

            if (payment.Order != null)
                payment.Order.Status = OrderStatus.Paid;

            await _db.SaveChangesAsync();

            return new ApiResponse<object>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Payment success updated",
                Data = payment
            };
        }

        public async Task<ApiResponse<object>> GetPaymentsByRestaurantIdAsync(int restaurantId)
        {
            var payments = await _db.Payments
               .Include(p => p.Order)
                    .ThenInclude(o => o.OrderItems)
                        .ThenInclude(oi => oi.Dish)
                .Include(p => p.Order.Restaurant)
                .Include(p => p.CODPayment)
                .Where(p => p.Order != null && p.Order.RestaurantId == restaurantId)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();

            return new ApiResponse<object>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "OK",
                Data = payments
            };
        }

        // Fix: Correct signature and remove extra parameter
        public async Task<ApiResponse<object>> UpdatePaymentFail(Payment payment, string? message)
        {
            payment.Status = PaymentStatus.Failed;

            var log = new PaymentTransactionLog
            {
                PaymentId = payment.Id,
                Provider = payment.Method, // Use Provider for payment method
                Status = PaymentStatus.Failed,
                ErrorMessage = message,
                CreatedAt = DateTime.UtcNow
            };

            _db.PaymentTransactionLogs.Add(log);
            await _db.SaveChangesAsync();

            return new ApiResponse<object>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Payment failed updated",
                Data = payment
            };
        }

        public async Task<ApiResponse<object>> LogTransactionAsync(Payment payment, PaymentStatus status, IQueryCollection query)
        {
            var log = new PaymentTransactionLog
            {
                PaymentId = payment.Id,
                Provider = PaymentMethod.VNPay,
                Status = status,
                RawData = string.Join("&", query.Select(kv => $"{kv.Key}={kv.Value}")),
                CreatedAt = DateTime.UtcNow
            };
            _db.PaymentTransactionLogs.Add(log);
            await _db.SaveChangesAsync();

            return new ApiResponse<object>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Transaction logged",
                Data = log
            };
        }

        public async Task<List<Payment>> GetPendingPayments()
        {
            return await _db.Payments
                .Where(p => p.Status == PaymentStatus.Pending)
                .ToListAsync();
        }

        public async Task<(bool IsSuccess, bool IsFailed, string? TransactionNo, string? Message)> VerifyWithVNPay(Payment payment)
        {
            // Demo logic xác thực VNPay
            await Task.Delay(100);
            if (payment.Amount % 2 == 0)
                return (true, false, "TXN123456", null);
            return (false, true, null, "VNPay báo thất bại");
        }

        public async Task<ApiResponse<object>> HandleVNPayReturn(IQueryCollection query)
        {
            if (!_vnPayService.ValidateSignature(query))
            {
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.ValidationError,
                    ErrMessage = "Invalid signature",
                    Data = null
                };
            }

            var txnRef = query["vnp_TxnRef"].ToString();

            var payment = await GetPaymentByOrderIdAsync(txnRef); // giả sử trả về Payment entity
            if (payment == null)
            {
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "Payment not found",
                    Data = null
                };
            }

            string message;
            ErrorCode errCode;

            switch (payment.Status)
            {
                case PaymentStatus.Success:
                    errCode = ErrorCode.Success;
                    message = "Payment successful";
                    break;
                case PaymentStatus.Failed:
                    errCode = ErrorCode.ValidationError;
                    message = "Payment failed";
                    break;
                default:
                    errCode = ErrorCode.UnknownError;
                    message = "Payment pending";
                    break;
            }

            return new ApiResponse<object>
            {
                ErrCode = errCode,
                ErrMessage = message,
                Data = new
                {
                    payment.Id,
                    payment.Amount,
                    payment.Status,
                    payment.OrderId,
                    OrderStatus = payment.Order?.Status
                }
            };
        }

        public async Task<ApiResponse<object>> ProcessVNPayIpnAsync(IQueryCollection query)
        {
            // Kiểm tra chữ ký bảo mật
            if (!_vnPayService.ValidateSignature(query))
            {
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.ValidationError,
                    ErrMessage = "Invalid signature",
                    Data = new { RspCode = "97", Message = "Invalid signature" }
                };
            }

            var txnRef = query["vnp_TxnRef"].ToString();
            var transactionNo = query["vnp_TransactionNo"].ToString();
            var responseCode = query["vnp_ResponseCode"].ToString();

            // Tìm payment tương ứng
            var payment = await GetPaymentByOrderIdAsync(txnRef);
            if (payment == null)
            {
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "Payment not found",
                    Data = new { RspCode = "01", Message = "Payment not found" }
                };
            }

            // Nếu đã xác nhận rồi thì bỏ qua
            if (payment.Status == PaymentStatus.Success)
            {
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.Success,
                    ErrMessage = "Payment already confirmed",
                    Data = new { RspCode = "02", Message = "Payment already confirmed" }
                };
            }

            // Xử lý kết quả từ VNPay
            if (responseCode == "00")
            {
                await UpdatePaymentSuccess(payment, transactionNo);
                await LogTransactionAsync(payment, PaymentStatus.Success, query);

                // Cập nhật trạng thái đơn hàng (đảm bảo có entity Order)
                if (payment.Order != null)
                {
                    payment.Order.Status = OrderStatus.Processing;
                    await _db.SaveChangesAsync();
                }

                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.Success,
                    ErrMessage = "Payment confirmed successfully",
                    Data = new { RspCode = "00", Message = "Confirm Success" }
                };
            }
            else
            {
                await UpdatePaymentFail(payment, $"VNPay failed with code {responseCode}");
                await LogTransactionAsync(payment, PaymentStatus.Failed, query);
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.ValidationError,
                    ErrMessage = "VNPay failed",
                    Data = new { RspCode = "00", Message = "Confirm Failed" }
                };
            }
        }
        public async Task<ApiResponse<object>> CreateCodPaymentAsync(Payment payment)
        {
            using var tx = await _db.Database.BeginTransactionAsync();
            try
            {
                payment.Method = PaymentMethod.COD;
                payment.Status = PaymentStatus.Pending;
                _db.Payments.Add(payment);
                await _db.SaveChangesAsync();

                var codPayment = new CODPayment { PaymentId = payment.Id, IsCollected = false };
                _db.CODPayments.Add(codPayment);
                await _db.SaveChangesAsync();

                await tx.CommitAsync();
                return new ApiResponse<object> { ErrCode = ErrorCode.Success, ErrMessage = "COD Payment created", Data = codPayment };
            }
            catch (Exception ex)
            {
                await tx.RollbackAsync();
                return new ApiResponse<object> { ErrCode = ErrorCode.ServerError, ErrMessage = ex.Message, Data = null };
            }
        }
        public async Task<ApiResponse<object>> GetPaymentsByUserIdAsync(int userId)
        {
            var payments = await _db.Payments
               .Include(p => p.Order)
                    .ThenInclude(o => o.OrderItems)
                        .ThenInclude(oi => oi.Dish)
                .Include(p => p.Order)
                    .ThenInclude(o => o.Restaurant)
                .Where(p => p.Order.UserId == userId)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();

            return new ApiResponse<object>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "OK",
                Data = payments
            };
        }
        public async Task<ApiResponse<object>> ConfirmCodPaymentAsync(int codPaymentId)
        {
            return await _codService.ConfirmCodPaymentAsync(codPaymentId);
        }
        public async Task<ApiResponse<object>> CancelOrderAsync(int orderId)
        {
            // Lấy order kèm payment
            var order = await _db.Orders
                .Include(o => o.Payment)
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
            {
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "Order not found",
                    Data = null
                };
            }

            if (order.Status == OrderStatus.Paid)
            {
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.ValidationError,
                    ErrMessage = "Paid orders cannot be cancelled",
                    Data = null
                };
            }

            using var tx = await _db.Database.BeginTransactionAsync();
            try
            {
                // Nếu có payment thì xóa logs và payment (hoặc xử lý khác tuỳ yêu cầu)
                if (order.Payment != null)
                {
                    var logs = _db.PaymentTransactionLogs.Where(l => l.PaymentId == order.Payment.Id);
                    _db.PaymentTransactionLogs.RemoveRange(logs);
                    _db.Payments.Remove(order.Payment);
                }

                // Xóa order items trước
                _db.OrderItems.RemoveRange(order.OrderItems);

                // Xóa order hoặc đánh dấu cancelled tuỳ logic
                _db.Orders.Remove(order);

                await _db.SaveChangesAsync();
                await tx.CommitAsync();

                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.Success,
                    ErrMessage = "Order cancelled successfully",
                    Data = null
                };
            }
            catch (Exception ex)
            {
                await tx.RollbackAsync();
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.ServerError,
                    ErrMessage = $"Failed to cancel order: {ex.Message}",
                    Data = null
                };
            }
        }
    }
}
