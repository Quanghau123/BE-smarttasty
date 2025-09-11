using backend.Domain.Enums;

namespace backend.Application.DTOs.DishPromotion
{
    public class DishPromotionDto
    {
        public int Id { get; set; }
        public int DishId { get; set; }
        public int PromotionId { get; set; }

        public string DishName { get; set; } = string.Empty;
        public string PromotionTitle { get; set; } = string.Empty;

        public DiscountType DiscountType { get; set; }
        public float DiscountValue { get; set; }
    }
}