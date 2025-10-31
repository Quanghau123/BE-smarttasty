namespace backend.Domain.Enums
{
    public enum DeliveryStatus
    {
        Preparing, //Đơn hàng đang được chuẩn bị
        Delivering, //Đơn hàng đang được giao
        Delivered, //Đơn hàng đã được giao
        Canceled //Đơn hàng đã bị hủy
    }
}