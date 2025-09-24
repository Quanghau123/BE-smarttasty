using backend.Application.DTOs.Order;

namespace backend.Application.DTOs.Payment
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; } = string.Empty;
        public string PaymentUrl { get; set; } = string.Empty;
        public OrderDto Order { get; set; } = null!;
    }
}
