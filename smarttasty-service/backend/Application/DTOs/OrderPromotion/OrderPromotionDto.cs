using backend.Domain.Enums;
using backend.Domain.Models;

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

        public int? RestaurantId { get; set; }
        public string? RestaurantName { get; set; }
        public int? TargetUserId { get; set; }
        public bool IsGlobal { get; set; }
    }
}
