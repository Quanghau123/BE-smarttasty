using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Domain.Models
{
    public class Voucher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Code { get; set; } = string.Empty;

        [Required]
        public int PromotionId { get; set; }

        [ForeignKey("PromotionId")]
        public Promotion Promotion { get; set; } = null!;

        public int? UserId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }

        [Required]
        public bool IsUsed { get; set; } = false;

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime ExpiredAt { get; set; }
    }
}
