namespace backend.Application.DTOs.Order
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int DishId { get; set; }
        public string Image { get; set; } = string.Empty;
        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }
        public string DishName { get; set; } = string.Empty;
    }
}
