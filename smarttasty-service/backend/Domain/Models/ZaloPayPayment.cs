using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Domain.Models
{
    public class ZaloPayPayment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int PaymentId { get; set; }

        [ForeignKey("PaymentId")]
        public Payment Payment { get; set; } = null!;

        [Required]
        public string AppTransId { get; set; } = string.Empty;

        public string? ZpTransId { get; set; }

        public string? ResponseMessage { get; set; }
    }
}
