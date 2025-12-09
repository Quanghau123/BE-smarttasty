using backend.Domain.Enums;

namespace backend.Application.DTOs.Commission
{
    public class PaymentCommissionResponse
    {
        public PaymentMethod PaymentMethod { get; set; }
        public decimal TotalCommission { get; set; }
        public int TotalOrders { get; set; }
    }
}
