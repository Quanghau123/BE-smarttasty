using backend.Application.DTOs.Order;
using backend.Application.DTOs.Restaurant;
using backend.Domain.Enums;

namespace backend.Application.DTOs.Payment
{
    public class InfoPaymentDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public PaymentStatus Status { get; set; }
        public OrderDto Order { get; set; } = null!;
        public CODPaymentDto? CODPayment { get; set; }
    }
}
