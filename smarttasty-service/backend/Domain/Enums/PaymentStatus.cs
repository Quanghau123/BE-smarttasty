namespace backend.Domain.Enums
{
    public enum PaymentStatus
    {
        Pending = 0,   // Chưa thanh toán
        Success = 1,   // Thanh toán thành công
        Failed = 2,    // Thanh toán thất bại
        Cancelled = 3, // Bị hủy
        Refunded = 4   // Đã hoàn tiền
    }
}