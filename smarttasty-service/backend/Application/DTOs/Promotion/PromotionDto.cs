using backend.Application.DTOs.Restaurant;
using backend.Domain.Enums;

namespace backend.Application.DTOs.Promotion
{
    public class PromotionDto
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public PromotionTarget TargetType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public RestaurantForPromotionDto Restaurant { get; set; } = null!;

        // store public id/key of uploaded image
        public string? Image { get; set; }

        // full URL for UI
        public string? ImageUrl { get; set; }
    }

    public class RestaurantForPromotionDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
    }

}