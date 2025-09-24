using backend.Application.Interfaces;
using backend.Domain.Enums;
using backend.Domain.Models;
using backend.Infrastructure.Data;
using backend.Infrastructure.Helpers.Commons.Response;
using backend.Domain.Enums.Commons.Response;
using Microsoft.EntityFrameworkCore;

namespace backend.Application.Services
{
    public class CODService : ICODService
    {
        private readonly ApplicationDbContext _db;

        public CODService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<ApiResponse<object>> CreateCodPaymentAsync(Payment payment)
        {
            payment.Method = PaymentMethod.COD;
            payment.Status = PaymentStatus.Pending;
            payment.PaidAt = null;

            _db.Payments.Add(payment);
            await _db.SaveChangesAsync();

            var codPayment = new CODPayment
            {
                PaymentId = payment.Id,
                IsCollected = false
            };

            _db.CODPayments.Add(codPayment);
            await _db.SaveChangesAsync();

            return new ApiResponse<object>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "COD Payment created successfully",
                Data = codPayment
            };
        }

        public async Task<ApiResponse<object>> ConfirmCodPaymentAsync(int codPaymentId)
        {
            var codPayment = await _db.CODPayments
                .Include(c => c.Payment)
                .ThenInclude(p => p.Order)
                .FirstOrDefaultAsync(c => c.Id == codPaymentId);

            if (codPayment == null)
            {
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "COD payment not found",
                    Data = null
                };
            }

            codPayment.IsCollected = true;
            codPayment.CollectedAt = DateTime.UtcNow;

            codPayment.Payment.Status = PaymentStatus.Success;
            codPayment.Payment.PaidAt = DateTime.UtcNow;

            if (codPayment.Payment.Order != null)
                codPayment.Payment.Order.Status = OrderStatus.Paid;

            await _db.SaveChangesAsync();

            return new ApiResponse<object>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "COD payment confirmed successfully",
                Data = codPayment
            };
        }
    }
}
