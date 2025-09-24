namespace backend.Application.DTOs.Order
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int DishId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string DishName { get; set; } = string.Empty;
    }
}
