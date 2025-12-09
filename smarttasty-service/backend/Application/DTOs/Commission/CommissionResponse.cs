public class CommissionResponse
{
    public int OrderId { get; set; }
    public int RestaurantId { get; set; }
    public decimal CommissionAmount { get; set; }
    public decimal Rate { get; set; }
    public decimal FinalPrice { get; set; }
    public DateTime CreatedAt { get; set; }
}
