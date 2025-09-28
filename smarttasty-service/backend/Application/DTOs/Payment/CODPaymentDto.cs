using backend.Application.DTOs.Order;

namespace backend.Application.DTOs.Payment
{
    public class CODPaymentDto
    {
        public int Id { get; set; }
        public int PaymentId { get; set; }
        public bool IsCollected { get; set; }
        public DateTime? CollectedAt { get; set; }
    }
}
