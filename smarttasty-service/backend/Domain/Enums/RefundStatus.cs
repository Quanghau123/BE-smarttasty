namespace backend.Domain.Enums
{
    public enum RefundStatus
    {
        Pending = 0,   // Đang chờ xử lý
        Approved = 1,  // Được duyệt
        Rejected = 2,  // Bị từ chối
        Completed = 3, // Hoàn tất
        Failed = 4     // Thất bại
    }
}
