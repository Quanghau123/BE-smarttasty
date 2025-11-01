namespace backend.Application.DTOs.KafkaPayload
{
    public class ReservationStatusUpdatedPayload
    {
        public int ReservationId { get; set; }
        public string? RestaurantName { get; set; }
        public string? ContactName { get; set; }
        public string? ContactEmail { get; set; }
        public string? NewStatus { get; set; }
        public string? Note { get; set; }
    }
}
