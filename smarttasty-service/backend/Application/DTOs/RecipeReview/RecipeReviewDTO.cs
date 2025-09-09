namespace backend.Application.DTOs.RecipeReview
{
    public class RecipeReviewDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public int RecipeId { get; set; }
        public string? Title { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
