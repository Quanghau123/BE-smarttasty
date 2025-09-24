namespace backend.Domain.Models.Requests.Order
{
    public class CreateOrderRequest
    {
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
        public string DeliveryAddress { get; set; } = string.Empty;
        public string RecipientName { get; set; } = string.Empty;
        public string RecipientPhone { get; set; } = string.Empty;

        public List<CreateOrderItemRequest> Items { get; set; } = new();
    }

    public class CreateOrderItemRequest
    {
        public int DishId { get; set; }
        public int Quantity { get; set; }
    }
}
