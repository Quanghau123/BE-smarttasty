using backend.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Domain.Models.Requests.Restaurant
{
    public class CreateRestaurantRequest
    {
        [Required]
        public int OwnerId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        [EnumDataType(typeof(RestaurantCategory), ErrorMessage = "Category không hợp lệ.")]
        public RestaurantCategory Category { get; set; }
        [Required]
        public string Address { get; set; } = string.Empty;
        public IFormFile? ImageFile { get; set; }
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
    }
}
