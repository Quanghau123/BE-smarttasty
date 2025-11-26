namespace backend.Application.DTOs.KafkaPayload
{
    public class OrderDeliveryStatusUpdatedPayload
    {
        public int OrderId { get; set; }
        public string? RestaurantName { get; set; }
        public string? ContactName { get; set; }
        public string? ContactEmail { get; set; }
        public string? NewStatus { get; set; }
    }
}
