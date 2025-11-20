using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Domain.Enums;

namespace backend.Domain.Models
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; } = null!;

        [Required]
        public PaymentMethod Method { get; set; }

        [Required]
        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;

        [Required]
        public decimal Amount { get; set; }   // số tiền cần thanh toán

        public string? TransactionId { get; set; }

        public string? PaymentUrl { get; set; }

        public DateTime? PaidAt { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        public List<PaymentTransactionLog> TransactionLogs { get; set; } = new();

        public VNPayPayment? VNPayPayment { get; set; }
        public CODPayment? CODPayment { get; set; }
        public List<Refund> Refunds { get; set; } = new();

        [Required]
        public string OrderSnapshotJson { get; set; } = null!;
    }
}
