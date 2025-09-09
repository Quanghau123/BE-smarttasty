namespace backend.Application.DTOs.Dish
{
    public class DishDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Category { get; set; } = "";
        public float Price { get; set; }
        public string Image { get; set; } = "";
        public bool IsActive { get; set; }

        public string ImageUrl { get; set; } = "";

        public RestaurantForDishDto Restaurant { get; set; } = null!;
    }

    public class RestaurantForDishDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
    }
}