using backend.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
    
namespace backend.Application.Jobs
{
    public class PromotionJob
    {
        private readonly IPromotionService _promotionService;

        public PromotionJob(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        // Job này sẽ được Hangfire gọi theo schedule (vd: mỗi giờ)
        public async Task CleanupExpiredPromotions()
        {
            await _promotionService.RemoveExpiredPromotionsAsync();
        }
    }
}
