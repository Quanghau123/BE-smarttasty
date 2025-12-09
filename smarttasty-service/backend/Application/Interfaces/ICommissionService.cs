using backend.Application.DTOs.Commission;
using backend.Domain.Models;

namespace backend.Application.Interfaces
{
    public interface ICommissionService
    {
        Task<bool> IsCommissionRecorded(int orderId);
        Task RecordCommissionAsync(Order order);
        Task<decimal> GetMonthlyCommissionAsync(int month, int year);
        Task<IEnumerable<CommissionResponse>> GetCommissionListAsync(int month, int year);
        Task<IEnumerable<RestaurantCommissionResponse>> GetCommissionByRestaurantAsync(int month, int year);
        Task<IEnumerable<DailyCommissionResponse>> GetDailyCommissionAsync(int month, int year);
        Task<IEnumerable<PaymentCommissionResponse>> GetCommissionByPaymentMethodAsync(int month, int year);
        Task<CommissionResponse?> GetCommissionDetailAsync(int orderId);
    }
}
