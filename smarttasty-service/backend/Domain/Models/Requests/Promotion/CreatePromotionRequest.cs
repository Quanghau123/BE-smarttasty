using backend.Domain.Enums;

namespace backend.Domain.Models.Requests.Promotion
{
    public class CreatePromotionRequest
    {
        public string? VoucherCode { get; set; }
        public int RestaurantId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DiscountType DiscountType { get; set; }
        public float DiscountValue { get; set; }
        public PromotionTarget TargetType { get; set; }
    }
}
