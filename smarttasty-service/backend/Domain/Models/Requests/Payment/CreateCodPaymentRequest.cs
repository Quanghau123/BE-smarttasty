namespace backend.Domain.Models.Requests.Payment
{
    public class CreateCodPaymentRequest
    {
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        // Nếu COD có thêm field riêng như địa chỉ giao hàng, số điện thoại thì thêm vào đây
        public string? ShippingAddress { get; set; }
        public string? ReceiverPhone { get; set; }
    }
}
