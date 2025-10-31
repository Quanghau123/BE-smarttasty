namespace backend.Application.DTOs.KafkaPayload
{
    public class RatingUpdatedPayload
    {
        public int RestaurantId { get; set; }
        public double AverageRating { get; set; }
        public int TotalReviews { get; set; }
    }
}
