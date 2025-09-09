using backend.Application.DTOs.Restaurant;

namespace backend.Application.DTOs.Promotion
{
    public class PromotionDto
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public RestaurantForPromotionDto Restaurant { get; set; } = null!;
    }

    public class RestaurantForPromotionDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
    }

}