namespace WebSocketServer.Domain.Enums
{
    public enum NotificationType
    {
        // Đặt bàn
        NewReservation,
        ReservationConfirmed,
        ReservationCancelled,

        // Thanh toán
        PaymentSuccess,
        PaymentFailed,

        // Hệ thống & quản trị
        Promotion,
        Warning,
        Info,
        Alert
    }
}