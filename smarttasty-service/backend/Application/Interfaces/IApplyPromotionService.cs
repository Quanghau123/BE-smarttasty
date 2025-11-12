using backend.Domain.Models;

namespace backend.Application.Interfaces
{
    public interface IApplyPromotionService
    {
        Task<float> ApplyPromotionAsync(int orderId, string voucherCode);
        Task<float> RemovePromotionAsync(int orderId);
    }
}