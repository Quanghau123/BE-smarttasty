using backend.Domain.Enums;
using backend.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Infrastructure.Data.Seeders
{
    public static class RestaurantSeeder
    {
        public static void SeedRestaurants(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>().HasData(
                // UserId = 2 (business)
                new Restaurant
                {
                    Id = 1,
                    OwnerId = 2,
                    Name = "Nhà Hàng Hải Sản Biển Xanh",
                    Category = RestaurantCategory.NhaHang,
                    Address = "123 Đường Biển, TP. HCM",
                    ImagePublicId = null,
                    Latitude = 10.7769,
                    Longitude = 106.7009,
                    Description = "Chuyên các món hải sản tươi sống, không gian sang trọng.",
                    OpenTime = "09:00",
                    CloseTime = "22:00",
                    Status = RestaurantStatus.APPROVED,
                    IsHidden = false,
                    CreatedAt = DateTime.UtcNow
                },
                new Restaurant
                {
                    Id = 2,
                    OwnerId = 2,
                    Name = "Quán Ăn Vỉa Hè",
                    Category = RestaurantCategory.AnVatViaHe,
                    Address = "456 Đường Lê Lợi, Hà Nội",
                    ImagePublicId = null,
                    Latitude = 21.0285,
                    Longitude = 105.8542,
                    Description = "Quán ăn vặt bình dân, giá rẻ, hợp túi tiền sinh viên.",
                    OpenTime = "15:00",
                    CloseTime = "23:00",
                    Status = RestaurantStatus.PENDING,
                    IsHidden = false,
                    CreatedAt = DateTime.UtcNow
                },

                // UserId = 4 (business)
                new Restaurant
                {
                    Id = 3,
                    OwnerId = 4,
                    Name = "Cafe Góc Phố",
                    Category = RestaurantCategory.CafeNuocUong,
                    Address = "789 Đường Nguyễn Huệ, Đà Nẵng",
                    ImagePublicId = null,
                    Latitude = 16.0544,
                    Longitude = 108.2022,
                    Description = "Quán cafe view đẹp, thích hợp để học tập và làm việc.",
                    OpenTime = "07:00",
                    CloseTime = "21:00",
                    Status = RestaurantStatus.APPROVED,
                    IsHidden = false,
                    CreatedAt = DateTime.UtcNow
                },
                new Restaurant
                {
                    Id = 4,
                    OwnerId = 4,
                    Name = "Quán Nhậu Bình Dân",
                    Category = RestaurantCategory.QuanNhau,
                    Address = "654 Đường Hòa Bình, Cần Thơ",
                    ImagePublicId = null,
                    Latitude = 10.0452,
                    Longitude = 105.7469,
                    Description = "Chuyên các món nhậu dân dã, không gian thoải mái.",
                    OpenTime = "16:00",
                    CloseTime = "00:00",
                    Status = RestaurantStatus.APPROVED,
                    IsHidden = false,
                    CreatedAt = DateTime.UtcNow
                },

                // UserId = 6 (business)
                new Restaurant
                {
                    Id = 5,
                    OwnerId = 6,
                    Name = "Nhà Hàng Chay Tâm An",
                    Category = RestaurantCategory.AnChay,
                    Address = "321 Đường Nguyễn Văn Linh, Huế",
                    ImagePublicId = null,
                    Latitude = 16.4637,
                    Longitude = 107.5909,
                    Description = "Nhà hàng chay thanh tịnh, chuyên phục vụ các món ăn tốt cho sức khỏe.",
                    OpenTime = "08:00",
                    CloseTime = "21:00",
                    Status = RestaurantStatus.APPROVED,
                    IsHidden = false,
                    CreatedAt = DateTime.UtcNow
                },
                new Restaurant
                {
                    Id = 6,
                    OwnerId = 6,
                    Name = "Bar The Night",
                    Category = RestaurantCategory.Bar,
                    Address = "888 Đường Trần Hưng Đạo, Hà Nội",
                    ImagePublicId = null,
                    Latitude = 21.0338,
                    Longitude = 105.8500,
                    Description = "Bar sôi động với DJ và nhạc EDM cực chất.",
                    OpenTime = "20:00",
                    CloseTime = "03:00",
                    Status = RestaurantStatus.PENDING,
                    IsHidden = false,
                    CreatedAt = DateTime.UtcNow
                }
            );
        }
    }
}
