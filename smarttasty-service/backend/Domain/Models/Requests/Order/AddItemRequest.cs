namespace backend.Domain.Models.Requests.Order
{
    public class AddItemRequest
    {
        public int DishId { get; set; }
        public int Quantity { get; set; } = 1;
    }
}