using backend.Domain.Models;

namespace backend.Application.Interfaces
{
    public interface IApplyPromotionService
    {
        Task<float> ApplyPromotionAsync(Order order, string? voucherCode = null);
    }
}