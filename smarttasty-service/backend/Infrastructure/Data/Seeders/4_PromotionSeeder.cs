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
                    TargetType = PromotionTarget.category,
                    Image = null,
                    VoucherCode = "ABC20"
                },
                new Promotion
                {
                    Id = 2,
                    RestaurantId = 1,
                    Title = "Giảm 20k cho Hải Sản",
                    Description = "Khuyến mãi 20.000 cho tất cả món hải sản trong menu.",
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddMonths(1),
                    DiscountType = DiscountType.fixed_amount,
                    DiscountValue = 20000,
                    TargetType = PromotionTarget.category,
                    Image = null,
                    VoucherCode = "ABC20k"
                },
                new Promotion
                {
                    Id = 3,
                    RestaurantId = 2,
                    Title = "Combo Sinh Viên",
                    Description = "Giảm 15k cho đơn hàng từ 50k trở lên.",
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddMonths(2),
                    DiscountType = DiscountType.fixed_amount,
                    DiscountValue = 15000,
                    TargetType = PromotionTarget.order,
                    Image = null,
                    VoucherCode = "CBA15k"
                },
                new Promotion
                {
                    Id = 4,
                    RestaurantId = 2,
                    Title = "Mua 2 Tặng 1",
                    Description = "Áp dụng cho tất cả đồ uống trong menu.",
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddMonths(1),
                    DiscountType = DiscountType.percent,
                    DiscountValue = 33.3f, // tương đương "mua 2 tặng 1"
                    TargetType = PromotionTarget.dish,
                    Image = null,
                    VoucherCode = "CBABuy2Get1"
                },
               new Promotion
               {
                   Id = 5,
                   RestaurantId = 3,
                   Title = "Giảm 20% toàn bộ menu nước",
                   Description = "Ưu đãi 20% cho tất cả các loại cafe và thức uống tại Cafe Góc Phố. Áp dụng mọi ngày trong tuần.",
                   StartDate = DateTime.UtcNow,
                   EndDate = DateTime.UtcNow.AddMonths(3),
                   DiscountType = DiscountType.percent,
                   DiscountValue = 20,
                   TargetType = PromotionTarget.category,
                   Image = null,
                   VoucherCode = "CAFE20OFF"
               },
                new Promotion
                {
                    Id = 6,
                    RestaurantId = 3,
                    Title = "Giảm 15,000đ cho đơn từ 50,000đ",
                    Description = "Nhập mã để giảm ngay 15,000đ cho đơn hàng có giá trị tối thiểu 50,000đ tại Cafe Góc Phố.",
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddMonths(3),
                    DiscountType = DiscountType.fixed_amount,
                    DiscountValue = 15000,
                    TargetType = PromotionTarget.category,
                    Image = null,
                    VoucherCode = "CAFE15K"
                },
                new Promotion
                {
                    Id = 7,
                    RestaurantId = 4,
                    Title = "Giảm 10% các món nhậu đặc biệt",
                    Description = "Ưu đãi 10% cho các món nhậu đặc biệt như gỏi bò, chân gà sả tắc, ếch xào sa tế. Áp dụng tất cả các ngày trong tuần.",
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddMonths(2),
                    DiscountType = DiscountType.percent,
                    DiscountValue = 10,
                    TargetType = PromotionTarget.category,
                    Image = null,
                    VoucherCode = "NHAU10"
                },
                new Promotion
                {
                    Id = 8,
                    RestaurantId = 4,
                    Title = "Giảm 30,000đ cho hóa đơn từ 200,000đ",
                    Description = "Nhập mã để giảm ngay 30,000đ áp dụng cho hóa đơn tổng từ 200,000đ trở lên. Không áp dụng kèm ưu đãi khác.",
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddMonths(2),
                    DiscountType = DiscountType.fixed_amount,
                    DiscountValue = 30000,
                    TargetType = PromotionTarget.category,
                    Image = null,
                    VoucherCode = "NHAU30K"
                },
                new Promotion
                {
                    Id = 9,
                    RestaurantId = 5,
                    Title = "Giảm 15% các món chay tốt cho sức khỏe",
                    Description = "Ưu đãi 15% cho các món chay dinh dưỡng: phở chay, bún Huế chay, rau củ luộc, cơm thập cẩm.",
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddMonths(3),
                    DiscountType = DiscountType.percent,
                    DiscountValue = 15,
                    TargetType = PromotionTarget.category,
                    Image = null,
                    VoucherCode = "CHAY15"
                },
                new Promotion
                {
                    Id = 10,
                    RestaurantId = 5,
                    Title = "Giảm 20,000đ cho đơn từ 100,000đ",
                    Description = "Mã ưu đãi giảm 20,000đ cho hóa đơn tối thiểu 100,000đ tại Nhà Hàng Chay Tâm An. Áp dụng từ thứ 2 đến thứ 6.",
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddMonths(3),
                    DiscountType = DiscountType.fixed_amount,
                    DiscountValue = 20000,
                    TargetType = PromotionTarget.category,
                    Image = null,
                    VoucherCode = "TAMAN20"
                }
            );
        }
    }
}
