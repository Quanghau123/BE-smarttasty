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

        [ForeignKey("UserId")]
        public User? User { get; set; } = null!;

        [Required]
        public int RestaurantId { get; set; }

        [ForeignKey("RestaurantId")]
        public Restaurant? Restaurant { get; set; } = null!;

        [Required]
        public decimal TotalPrice { get; set; }

        [Required]
        public decimal FinalPrice { get; set; }

        [Required]
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        // ------------------ Thanh toán ------------------
        [Required]
        public PaymentMethod PaymentMethod { get; set; }

        public string? TransactionId { get; set; }

        public string? PaymentUrl { get; set; }

        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;

        public DateTime? PaidAt { get; set; }

        // ------------------ Giao hàng ------------------
        [Required]
        public string DeliveryAddress { get; set; } = string.Empty;

        [Required]
        public string RecipientName { get; set; } = string.Empty;

        [Required]
        public string RecipientPhone { get; set; } = string.Empty;

        public DeliveryStatus DeliveryStatus { get; set; } = DeliveryStatus.Preparing;

        public DateTime? DeliveredAt { get; set; }

        // ------------------ Shipper nội bộ (optional) ------------------
        public int? ShipperId { get; set; }

        [ForeignKey("ShipperId")]
        public User? Shipper { get; set; }

        // ------------------ Thời gian ------------------
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        // ------------------ Quan hệ ------------------
        [Required]
        public List<OrderItem> OrderItems { get; set; } = new();
    }
}
