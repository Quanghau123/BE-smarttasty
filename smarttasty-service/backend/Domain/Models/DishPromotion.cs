using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Domain.Models
{
    public class DishPromotion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int DishId { get; set; }

        [ForeignKey("DishId")]
        public Dish Dish { get; set; } = null!;

        [Required]
        public int PromotionId { get; set; }

        [ForeignKey("PromotionId")]
        public Promotion Promotion { get; set; } = null!;
        public float? OriginalPrice { get; set; }
        public float? AppliedPrice { get; set; }
    }

}