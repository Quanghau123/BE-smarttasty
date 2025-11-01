namespace NotificationService.Application.DTOs.KafkaPayload
{
    public class ReservationCreatedPayload
    {
        public int ReservationId { get; set; }
        public int RestaurantId { get; set; }
        public string BusinessEmail { get; set; } = string.Empty;
        public string ContactName { get; set; } = string.Empty;
        public string ContactEmail { get; set; } = string.Empty;
        public DateTime ArrivalDate { get; set; }
        public TimeSpan ReservationTime { get; set; }
    }
}
