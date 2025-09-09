using backend.Domain.Enums;

namespace backend.Application.DTOs.Restaurant
{
    public class RestaurantDto
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }

        public string OwnerEmail { get; set; } = "";
        public string OwnerName { get; set; } = "";
        public string OwnerPhone { get; set; } = "";

        public string Name { get; set; } = "";
        public RestaurantCategory Category { get; set; }
        public string Address { get; set; } = "";
        public string ImagePublicId { get; set; } = "";
        public string? ImageUrl { get; set; } = "";
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Description { get; set; } = "";
        public string OpenTime { get; set; } = "";
        public string CloseTime { get; set; } = "";
        public RestaurantStatus Status { get; set; }
        public bool IsHidden { get; set; }
        public DateTime CreatedAt { get; set; }

        public double? DistanceKm { get; set; }
    }
}
