using backend.Application.DTOs.Order;
using backend.Application.DTOs.Restaurant;

namespace backend.Application.DTOs.Payment
{
    public class InfoPaymentDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; } = string.Empty;
        public OrderDto Order { get; set; } = null!;
    }
}
