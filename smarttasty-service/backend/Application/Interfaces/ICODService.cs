using backend.Domain.Models;
using backend.Infrastructure.Helpers.Commons.Response;
using System.Threading.Tasks;

namespace backend.Application.Interfaces
{
    public interface ICODService
    {
        Task<ApiResponse<object>> CreateCodPaymentAsync(Payment payment);
        Task<ApiResponse<object>> ConfirmCodPaymentAsync(int codPaymentId);
    }
}
