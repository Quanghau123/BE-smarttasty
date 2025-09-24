using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Domain.Enums;

namespace backend.Domain.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;

        [Required]
        public int RestaurantId { get; set; }

        [ForeignKey(nameof(RestaurantId))]
        public Restaurant Restaurant { get; set; } = null!;

        [Required]
        public decimal TotalPrice { get; set; }

        [Required]
        public decimal FinalPrice { get; set; }

        [Required]
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        // ------------------ Giao hàng ------------------
        [Required]
        public string DeliveryAddress { get; set; } = string.Empty;

        [Required]
        public string RecipientName { get; set; } = string.Empty;

        [Required]
        public string RecipientPhone { get; set; } = string.Empty;

        public DeliveryStatus DeliveryStatus { get; set; } = DeliveryStatus.Preparing;

        public DateTime? DeliveredAt { get; set; }

        // ------------------ Thời gian ------------------
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        // ------------------ Quan hệ ------------------
        public List<OrderItem> OrderItems { get; set; } = new();

        // ------------------ Thanh toán ------------------
        public Payment? Payment { get; set; }

        // ------------------ Domain Logic ------------------
        public void AddItem(OrderItem item)
        {
            OrderItems.Add(item);
            RecalculateTotal();
        }

        public void RemoveItem(int orderItemId)
        {
            var item = OrderItems.FirstOrDefault(x => x.Id == orderItemId);
            if (item != null)
            {
                OrderItems.Remove(item);
                RecalculateTotal();
            }
        }

        public void RecalculateTotal()
        {
            TotalPrice = OrderItems.Sum(i => i.TotalPrice);
            FinalPrice = TotalPrice; // TODO: áp dụng voucher / promotion nếu có
        }
    }
}
