using backend.Application.Interfaces;
using backend.Domain.Enums;
using backend.Domain.Enums.Commons.Response;
using backend.Domain.Models;
using backend.Domain.Models.Requests.Refund;
using backend.Infrastructure.Data;
using backend.Infrastructure.Helpers.Commons.Response;
using Microsoft.EntityFrameworkCore;

namespace backend.Application.Services
{
    public class RefundService : IRefundService
    {
        private readonly ApplicationDbContext _context;

        public RefundService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse<object>> CreateRefundAsync(CreateRefundRequest request)
        {
            var payment = await _context.Payments
                .Include(p => p.Refunds)
                .FirstOrDefaultAsync(p => p.Id == request.PaymentId);

            if (payment == null)
            {
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "Payment not found",
                    Data = null
                };
            }

            if (payment.Status != PaymentStatus.Success)
            {
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.ValidationError,
                    ErrMessage = "Payment not eligible for refund",
                    Data = null
                };
            }

            var refund = new Refund
            {
                PaymentId = request.PaymentId,
                Amount = request.Amount,
                Reason = request.Reason,
                CreatedAt = DateTime.UtcNow
            };

            payment.Refunds.Add(refund);

            if (request.Amount == payment.Amount)
            {
                payment.Status = PaymentStatus.Refunded;
            }

            await _context.SaveChangesAsync();

            return new ApiResponse<object>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Refund created successfully",
                Data = new
                {
                    refund.Id,
                    refund.PaymentId,
                    refund.Amount,
                    refund.Reason,
                    refund.CreatedAt
                }
            };
        }

        public async Task<ApiResponse<object>> GetRefundsByPaymentAsync(int paymentId)
        {
            var refunds = await _context.Refunds
                .Where(r => r.PaymentId == paymentId)
                .ToListAsync();

            if (!refunds.Any())
            {
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "No refunds found for this payment",
                    Data = null
                };
            }

            return new ApiResponse<object>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "OK",
                Data = refunds.Select(r => new
                {
                    r.Id,
                    r.PaymentId,
                    r.Amount,
                    r.Reason,
                    r.CreatedAt
                }).ToList()
            };
        }
    }
}
