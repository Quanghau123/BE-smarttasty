using backend.Application.DTOs.Voucher;
using backend.Domain.Models.Requests.Voucher;
using backend.Domain.Enums.Commons.Response;
using backend.Infrastructure.Helpers.Commons.Response;

namespace backend.Application.Interfaces
{
    public interface IVoucherService
    {

        Task<ApiResponse<VoucherDto?>> GetByCodeAsync(string code);
        Task<ApiResponse<VoucherDto?>> CreateVoucherAsync(CreateVoucherRequest dto);
        Task<ApiResponse<List<VoucherDto>>> GetUserVouchersAsync(int userId);
        Task<ApiResponse<object>> MarkAsUsedAsync(int id);
    }
}
