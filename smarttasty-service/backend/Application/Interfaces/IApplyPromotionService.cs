using backend.Domain.Models;

namespace backend.Application.Interfaces
{
    public interface IApplyPromotionService
    {
        Task<float> ApplyPromotionAsync(Order order, int currentUserId, string? voucherCode = null);
        Task<float> RemovePromotionAsync(Order order);
    }
}