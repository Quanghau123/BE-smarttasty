namespace backend.Domain.Models.Requests.Favorite
{
    public class CreateFavoriteRequest
    {
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
    }
}