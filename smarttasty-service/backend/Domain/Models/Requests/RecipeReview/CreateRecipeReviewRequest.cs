namespace backend.Domain.Models.Requests.RecipeReview
{
    public class CreateRecipeReviewRequest
    {
        public int UserId { get; set; }
        public int RecipeId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
    }
}