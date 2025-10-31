using backend.Application.DTOs.Order;
using backend.Domain.Enums;

namespace backend.Application.DTOs.Payment
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public PaymentStatus Status { get; set; }
        public string PaymentUrl { get; set; } = string.Empty;
        public OrderDto Order { get; set; } = null!;
    }
}
