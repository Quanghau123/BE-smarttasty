using System.ComponentModel.DataAnnotations;

namespace backend.Domain.Models.Requests.Voucher
{
    public class CreateVoucherRequest
    {
        [Required]
        public string Code { get; set; } = string.Empty;

        [Required]
        public int PromotionId { get; set; }

        public int? UserId { get; set; }

        [Required]
        public DateTime ExpiredAt { get; set; }
    }
}
