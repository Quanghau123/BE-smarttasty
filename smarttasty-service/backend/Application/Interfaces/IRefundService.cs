using backend.Infrastructure.Helpers.Commons.Response;
using backend.Domain.Models.Requests.Refund;

namespace backend.Application.Interfaces
{
    public interface IRefundService
    {
        Task<ApiResponse<object>> CreateRefundAsync(CreateRefundRequest request);
        Task<ApiResponse<object>> GetRefundsByPaymentAsync(int paymentId);
    }
}
