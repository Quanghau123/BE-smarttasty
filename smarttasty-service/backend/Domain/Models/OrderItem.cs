using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Domain.Models
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; } = null!;

        [Required]
        public int DishId { get; set; }

        [ForeignKey(nameof(DishId))]
        public Dish Dish { get; set; } = null!;

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        public decimal OriginalPrice { get; private set; }

        // Domain logic: khởi tạo từ món ăn
        public static OrderItem Create(int dishId, decimal unitPrice, int quantity, decimal originalPrice)
        {
            return new OrderItem
            {
                DishId = dishId,
                UnitPrice = unitPrice,
                OriginalPrice = originalPrice,
                Quantity = quantity,
                TotalPrice = unitPrice * quantity
            };
        }
    }
}
