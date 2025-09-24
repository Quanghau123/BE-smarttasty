using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Domain.Enums;

namespace backend.Domain.Models
{
    public class Refund
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int PaymentId { get; set; }

        [ForeignKey("PaymentId")]
        public Payment Payment { get; set; } = null!;

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public RefundStatus Status { get; set; } = RefundStatus.Pending;

        public string? TransactionId { get; set; } // Mã giao dịch hoàn tiền từ VNPay/ZaloPay

        public string? Reason { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? ProcessedAt { get; set; }
    }
}
