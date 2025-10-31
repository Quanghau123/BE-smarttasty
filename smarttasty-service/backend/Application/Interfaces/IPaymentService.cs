using backend.Domain.Models;
using backend.Domain.Enums;
using backend.Application.DTOs.Payment;
using backend.Infrastructure.Helpers.Commons.Response;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Application.Interfaces
{
    public interface IPaymentService
    {
        Task<ApiResponse<object>> AddPaymentAsync(Payment payment);
        Task<Payment?> GetPaymentByOrderIdAsync(string orderId);
        Task<ApiResponse<object>> UpdatePaymentSuccess(Payment payment, string transactionNo);
        Task<ApiResponse<object>> UpdatePaymentFail(Payment payment, string? message);
        Task<ApiResponse<object>> LogTransactionAsync(Payment payment, PaymentStatus status, IQueryCollection query);
        Task<List<Payment>> GetPendingPayments();
        Task<(bool IsSuccess, bool IsFailed, string? TransactionNo, string? Message)> VerifyWithVNPay(Payment payment);
        Task<ApiResponse<object>> HandleVNPayReturn(IQueryCollection query);
        Task<ApiResponse<object>> ProcessVNPayIpnAsync(IQueryCollection query);

        Task<ApiResponse<object>> CreateCodPaymentAsync(Payment payment);
        Task<ApiResponse<object>> GetPaymentsByUserIdAsync(int userId);
        Task<ApiResponse<object>> ConfirmCodPaymentAsync(int codPaymentId);
    }
}
