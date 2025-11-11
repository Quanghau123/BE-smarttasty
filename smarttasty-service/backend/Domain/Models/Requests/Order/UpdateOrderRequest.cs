using System.Collections.Generic;

namespace backend.Domain.Models.Requests.Order
{
    public class UpdateOrderRequest
    {
        public string? DeliveryAddress { get; set; }
        public string? RecipientName { get; set; }
        public string? RecipientPhone { get; set; }
        public string? VoucherCode { get; set; }
        public List<UpdateOrderItemRequest>? Items { get; set; }
    }
    public class UpdateOrderItemRequest
    {
        public int DishId { get; set; }
        public int Quantity { get; set; }
    }
}