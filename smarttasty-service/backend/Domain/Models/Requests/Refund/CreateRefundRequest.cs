namespace backend.Domain.Models.Requests.Refund
{
    public class CreateRefundRequest
    {
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public string Reason { get; set; } = string.Empty;
    }
}