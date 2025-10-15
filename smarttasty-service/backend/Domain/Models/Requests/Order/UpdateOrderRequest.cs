using System.Collections.Generic;

namespace backend.Domain.Models.Requests.Order
{
    public class UpdateOrderRequest
    {
        public string? DeliveryAddress { get; set; }
        public string? RecipientName { get; set; }
        public string? RecipientPhone { get; set; }
    }
}