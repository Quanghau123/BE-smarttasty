namespace backend.Domain.Enums
{
    public enum OrderStatus
    {
        Pending,     // Mới tạo, chưa thanh toán
        Paid,        // Đã thanh toán (hoàn tất)
        Cancelled,
        Failed,
        Processing,  // Đang xử lý (sau khi thanh toán thành công VNPAY)
    }
}