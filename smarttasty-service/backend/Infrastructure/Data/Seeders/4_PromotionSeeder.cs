using backend.Domain.Enums;
using backend.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Infrastructure.Data.Seeders
{
    public static class PromotionSeeder
    {
        public static void SeedPromotions(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Promotion>().HasData(
                new Promotion
                {
                    Id = 1,
                    RestaurantId = 1,
                    Title = "Giảm 20% Hải Sản",
                    Description = "Khuyến mãi 20% cho tất cả món hải sản trong menu.",
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddMonths(1),
                    DiscountType = DiscountType.percent,
                    DiscountValue = 20,
                    TargetType = PromotionTarget.category
                },
                new Promotion
                {
                    Id = 2,
                    RestaurantId = 2,
                    Title = "Combo Sinh Viên",
                    Description = "Giảm 15k cho đơn hàng từ 50k trở lên.",
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddMonths(2),
                    DiscountType = DiscountType.fixed_amount,
                    DiscountValue = 15000,
                    TargetType = PromotionTarget.order
                },
                new Promotion
                {
                    Id = 3,
                    RestaurantId = 3,
                    Title = "Mua 2 Tặng 1",
                    Description = "Áp dụng cho tất cả đồ uống trong menu.",
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddMonths(1),
                    DiscountType = DiscountType.percent,
                    DiscountValue = 33.3f, // tương đương "mua 2 tặng 1"
                    TargetType = PromotionTarget.dish
                },
                new Promotion
                {
                    Id = 4,
                    RestaurantId = 5,
                    Title = "Khuyến Mãi Ăn Chay",
                    Description = "Giảm 10% cho tất cả món chay vào ngày Rằm.",
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddMonths(3),
                    DiscountType = DiscountType.percent,
                    DiscountValue = 10,
                    TargetType = PromotionTarget.category
                }
            );
        }
    }
}
