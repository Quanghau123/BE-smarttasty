using backend.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Domain.Models
{
    public class Restaurant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public User Owner { get; set; } = null!;

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public RestaurantCategory Category { get; set; }

        [Required]
        public string Address { get; set; } = string.Empty;

        public string? ImagePublicId { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string OpenTime { get; set; } = "08:00";

        [Required]
        public string CloseTime { get; set; } = "22:00";

        [Required]
        public RestaurantStatus Status { get; set; } = RestaurantStatus.PENDING;

        [Required]
        public bool IsHidden { get; set; } = false;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Dish> Dishes { get; set; } = new List<Dish>();
        public ICollection<Promotion> Promotions { get; set; } = new List<Promotion>();

    }
}
