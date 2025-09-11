namespace backend.Domain.Models.Requests.Review
{
    public class CreateReviewRequest
    {
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
    }
}