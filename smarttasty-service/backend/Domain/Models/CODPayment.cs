using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Domain.Models
{
    public class CODPayment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int PaymentId { get; set; }

        [ForeignKey("PaymentId")]
        public Payment Payment { get; set; } = null!;

        [Required]
        public bool IsCollected { get; set; } = false;

        public DateTime? CollectedAt { get; set; }
    }
}
