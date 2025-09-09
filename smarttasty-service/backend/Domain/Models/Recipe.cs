using backend.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Domain.Models
{
    public class Recipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        [Required]
        public string Title { get; set; } = "";

        [Required]
        public RecipeCategory Category { get; set; }

        public string Description { get; set; } = string.Empty;

        [Required]
        public string Ingredients { get; set; } = "";

        [Required]
        public string Steps { get; set; } = "";

        public string Image { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<RecipeReview> RecipeReviews { get; set; } = new List<RecipeReview>();


    }
}