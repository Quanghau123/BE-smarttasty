namespace backend.Domain.Models.Requests.Payment
{
    public class CreatePaymentRequest
    {
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        // Thêm các thuộc tính khác nếu cần, ví dụ:
        // public PaymentMethod Method { get; set; }
        // public string? Description { get; set; }
    }
}
