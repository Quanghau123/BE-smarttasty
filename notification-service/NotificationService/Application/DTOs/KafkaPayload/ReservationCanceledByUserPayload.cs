namespace NotificationService.Application.DTOs.KafkaPayload
{
    public class ReservationCanceledByUserPayload
    {
        public int ReservationId { get; set; }
        public int RestaurantId { get; set; }
        public string? BusinessEmail { get; set; }
        public string? ContactName { get; set; }
        public string? ContactEmail { get; set; }
        public DateTime ArrivalDate { get; set; }
        public TimeSpan ReservationTime { get; set; }
    }
}
