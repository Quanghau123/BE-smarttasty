namespace backend.Domain.Models.Requests.DishPromotion
{
    public class CreateDishPromotionRequest
    {
        public int DishId { get; set; }
        public int PromotionId { get; set; }
    }
}