using backend.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Domain.Models
{
    public class Dish
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public DishCategory Category { get; set; }

        public string Description { get; set; } = string.Empty;

        [Required]
        public float Price { get; set; }

        public string Image { get; set; } = string.Empty;

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public int RestaurantId { get; set; }

        [ForeignKey("RestaurantId")]
        public Restaurant? Restaurant { get; set; } = null!;

        public List<DishPromotion> DishPromotions { get; set; } = new();
    }
}