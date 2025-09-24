using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Domain.Models
{
    public class VNPayPayment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int PaymentId { get; set; }

        [ForeignKey("PaymentId")]
        public Payment Payment { get; set; } = null!;

        [Required]
        public string VnpTxnRef { get; set; } = string.Empty;

        public string? BankCode { get; set; }

        public string? CardType { get; set; }

        public string? ResponseCode { get; set; }
    }
}
