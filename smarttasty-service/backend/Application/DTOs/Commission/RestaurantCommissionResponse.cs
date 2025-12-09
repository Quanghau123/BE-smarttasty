namespace backend.Application.DTOs.Commission
{
    public class RestaurantCommissionResponse
    {
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; } = string.Empty;
        public decimal TotalCommission { get; set; }
        public int TotalOrders { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}
