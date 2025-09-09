using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Domain.Enums;

namespace backend.Domain.Models
{
    public class Promotion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int RestaurantId { get; set; }

        [ForeignKey("RestaurantId")]
        public Restaurant? Restaurant { get; set; } = null!;

        [Required]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public DiscountType DiscountType { get; set; }

        [Required]
        public float DiscountValue { get; set; }

        [Required]
        public PromotionTarget TargetType { get; set; }

        public List<DishPromotion> DishPromotions { get; set; } = new();

        public List<OrderPromotion> OrderPromotions { get; set; } = new();

        public List<Voucher> Vouchers { get; set; } = new();
    }
}