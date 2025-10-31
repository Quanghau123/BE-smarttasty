namespace backend.Domain.Models.Requests.Payment
{
    public class CreateCodPaymentRequest
    {
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
    }
}
