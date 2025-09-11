namespace backend.Application.DTOs.Recipe
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Category { get; set; } = "";
        public string Description { get; set; } = "";
        public string Ingredients { get; set; } = "";
        public string Steps { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Image { get; set; } = "";

        public string ImageUrl { get; set; } = "";

        public UserForRecipeDto User { get; set; } = null!;
    }

    public class UserForRecipeDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = "";
        public string Phone { get; set; } = "";
    }

}