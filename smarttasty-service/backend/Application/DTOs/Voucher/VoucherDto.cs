using backend.Domain.Enums;

namespace backend.Application.DTOs.Voucher
{
    public class VoucherDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public int PromotionId { get; set; }
        public int? UserId { get; set; }
        public bool IsUsed { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiredAt { get; set; }

        // Thêm các trường từ Promotion
        public DiscountType DiscountType { get; set; }
        public float DiscountValue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
