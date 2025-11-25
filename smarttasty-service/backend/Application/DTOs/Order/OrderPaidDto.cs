using backend.Application.DTOs.Restaurant;
using backend.Domain.Enums;

namespace backend.Application.DTOs.Order
{
    public class OrderPaidDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal FinalPrice { get; set; }
        public string DeliveryAddress { get; set; } = string.Empty;
        public string RecipientName { get; set; } = string.Empty;
        public string RecipientPhone { get; set; } = string.Empty;
        public DeliveryStatus DeliveryStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<OrderItemDto> Items { get; set; } = new();
        public RestaurantDto Restaurant { get; set; } = new();
    }
}
