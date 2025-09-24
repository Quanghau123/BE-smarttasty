using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Domain.Enums;

namespace backend.Domain.Models
{
    public class PaymentTransactionLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int PaymentId { get; set; }

        [ForeignKey("PaymentId")]
        public Payment Payment { get; set; } = null!;

        [Required]
        public PaymentProvider Provider { get; set; } // Enum thay cho string

        [Required]
        public PaymentStatus Status { get; set; } // Enum thay cho string

        public string? RawData { get; set; }

        public string? ErrorMessage { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
