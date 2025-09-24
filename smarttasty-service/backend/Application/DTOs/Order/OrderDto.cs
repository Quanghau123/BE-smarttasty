namespace backend.Application.DTOs.Order
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
        public string DeliveryAddress { get; set; } = string.Empty;
        public string RecipientName { get; set; } = string.Empty;
        public string RecipientPhone { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<OrderItemDto> Items { get; set; } = new();
    }
}
