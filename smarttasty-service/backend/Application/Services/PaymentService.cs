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

        public async Task<Payment?> GetPaymentByOrderIdAsync(string orderId)
        {
            return await _db.Payments
        .Include(p => p.Order)
            .ThenInclude(o => o.OrderItems)
                .ThenInclude(oi => oi.Dish)  // phải load cả Dish
        .Include(p => p.TransactionLogs)
        .FirstOrDefaultAsync(p => p.OrderId.ToString() == orderId);
        }

        public async Task<ApiResponse<object>> UpdatePaymentSuccess(Payment payment, string transactionNo)
        {
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

        public async Task<ApiResponse<object>> UpdatePaymentFail(Payment payment, string? message)
        {
            payment.Status = PaymentStatus.Failed;

            var log = new PaymentTransactionLog
            {
                PaymentId = payment.Id,
                Provider = PaymentProvider.VNPay,
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
                Provider = PaymentProvider.VNPay,
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
            var transactionNo = query["vnp_TransactionNo"].ToString();
            var responseCode = query["vnp_ResponseCode"].ToString();

            var payment = await GetPaymentByOrderIdAsync(txnRef);
            if (payment == null)
            {
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "Payment not found",
                    Data = null
                };
            }

            if (responseCode == "00")
            {
                await UpdatePaymentSuccess(payment, transactionNo);
                await LogTransactionAsync(payment, PaymentStatus.Success, query);
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.Success,
                    ErrMessage = "Payment successful",
                    Data = payment
                };
            }
            else
            {
                await UpdatePaymentFail(payment, $"VNPay failed with code {responseCode}");
                await LogTransactionAsync(payment, PaymentStatus.Failed, query);
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.ValidationError,
                    ErrMessage = $"Payment failed with code {responseCode}",
                    Data = payment
                };
            }
        }

        public async Task<object> HandleVNPayIpn(IQueryCollection query)
        {
            if (!_vnPayService.ValidateSignature(query))
                return new { RspCode = "97", Message = "Invalid signature" };

            var txnRef = query["vnp_TxnRef"].ToString();
            var transactionNo = query["vnp_TransactionNo"].ToString();
            var responseCode = query["vnp_ResponseCode"].ToString();

            var payment = await GetPaymentByOrderIdAsync(txnRef);
            if (payment == null)
                return new { RspCode = "01", Message = "Payment not found" };

            if (payment.Status == PaymentStatus.Success)
                return new { RspCode = "02", Message = "Payment already confirmed" };

            if (responseCode == "00")
            {
                await UpdatePaymentSuccess(payment, transactionNo);
                await LogTransactionAsync(payment, PaymentStatus.Success, query);
                return new { RspCode = "00", Message = "Confirm Success" };
            }
            else
            {
                await UpdatePaymentFail(payment, $"VNPay failed with code {responseCode}");
                await LogTransactionAsync(payment, PaymentStatus.Failed, query);
                return new { RspCode = "00", Message = "Confirm Failed" };
            }
        }

        public async Task<ApiResponse<object>> CreateCodPaymentAsync(Payment payment)
        {
            return await _codService.CreateCodPaymentAsync(payment);
        }

        public async Task<ApiResponse<object>> ConfirmCodPaymentAsync(int codPaymentId)
        {
            return await _codService.ConfirmCodPaymentAsync(codPaymentId);
        }
    }
}
