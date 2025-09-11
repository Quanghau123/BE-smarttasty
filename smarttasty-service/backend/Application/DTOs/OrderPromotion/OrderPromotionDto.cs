using backend.Domain.Enums;

namespace backend.Application.DTOs.OrderPromotion
{
    public class OrderPromotionDto
    {
        public int Id { get; set; }
        public int PromotionId { get; set; }
        public float MinOrderValue { get; set; }

        public string PromotionTitle { get; set; } = string.Empty;
        public DiscountType DiscountType { get; set; }
        public float DiscountValue { get; set; }
    }
}
