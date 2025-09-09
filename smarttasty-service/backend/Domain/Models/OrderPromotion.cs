using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Domain.Models
{
    public class OrderPromotion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int PromotionId { get; set; }

        [ForeignKey("PromotionId")]
        public Promotion Promotion { get; set; } = null!;

        [Required]
        public float MinOrderValue { get; set; }
    }
}
