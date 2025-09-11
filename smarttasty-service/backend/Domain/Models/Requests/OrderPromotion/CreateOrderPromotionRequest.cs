using System.ComponentModel.DataAnnotations;

namespace backend.Domain.Models.Requests.OrderPromotion
{
    public class CreateOrderPromotionRequest
    {
        public int PromotionId { get; set; }
        public float MinOrderValue { get; set; }
    }
}
