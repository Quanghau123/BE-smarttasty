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
                    Address = "456 Đường Lê Lợi, TP. HCM",
                    ImagePublicId = null,
                    Latitude = 10.7705,
                    Longitude = 106.6980,
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
                    Address = "789 Đường Nguyễn Huệ, TP. HCM",
                    ImagePublicId = null,
                    Latitude = 10.7798,
                    Longitude = 106.6963,
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
                    Address = "654 Đường Hòa Bình, TP. HCM",
                    ImagePublicId = null,
                    Latitude = 10.7725,
                    Longitude = 106.6685,
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
                    Address = "321 Đường Nguyễn Văn Linh, TP. HCM",
                    ImagePublicId = null,
                    Latitude = 10.7790,
                    Longitude = 106.7000,
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
                    Address = "888 Đường Trần Hưng Đạo, TP. HCM",
                    ImagePublicId = null,
                    Latitude = 10.7720,
                    Longitude = 106.6990,
                    Description = "Bar sôi động với DJ và nhạc EDM cực chất.",
                    OpenTime = "20:00",
                    CloseTime = "03:00",
                    Status = RestaurantStatus.PENDING,
                    IsHidden = false,
                    CreatedAt = DateTime.UtcNow
                },

                // UserId = 8 (business)
                new Restaurant
                {
                    Id = 7,
                    OwnerId = 8,
                    Name = "Nhà Hàng Sushi Tokyo",
                    Category = RestaurantCategory.NhaHang,
                    Address = "12 Đường Trần Phú, TP. HCM",
                    ImagePublicId = null,
                    Latitude = 10.7740,
                    Longitude = 106.7010,
                    Description = "Nhà hàng Nhật Bản chuyên sushi, sashimi tươi ngon.",
                    OpenTime = "10:00",
                    CloseTime = "22:00",
                    Status = RestaurantStatus.APPROVED,
                    IsHidden = false,
                    CreatedAt = DateTime.UtcNow
                },
                new Restaurant
                {
                    Id = 8,
                    OwnerId = 8,
                    Name = "Cafe Sáng Phố",
                    Category = RestaurantCategory.CafeNuocUong,
                    Address = "34 Đường Hàng Bông, TP. HCM",
                    ImagePublicId = null,
                    Latitude = 10.7800,
                    Longitude = 106.6950,
                    Description = "Quán cafe yên tĩnh, phục vụ sáng và trưa.",
                    OpenTime = "06:30",
                    CloseTime = "18:00",
                    Status = RestaurantStatus.APPROVED,
                    IsHidden = false,
                    CreatedAt = DateTime.UtcNow
                },

                // UserId = 10 (business)
                new Restaurant
                {
                    Id = 9,
                    OwnerId = 10,
                    Name = "Quán Ăn Ngon 99",
                    Category = RestaurantCategory.QuanAn,
                    Address = "56 Đường Lý Thường Kiệt, TP. HCM",
                    ImagePublicId = null,
                    Latitude = 10.7820,
                    Longitude = 106.7020,
                    Description = "Quán ăn đa dạng món Việt, phục vụ nhanh và giá hợp lý.",
                    OpenTime = "09:00",
                    CloseTime = "21:00",
                    Status = RestaurantStatus.APPROVED,
                    IsHidden = false,
                    CreatedAt = DateTime.UtcNow
                },
                new Restaurant
                {
                    Id = 10,
                    OwnerId = 10,
                    Name = "Bar Sunset",
                    Category = RestaurantCategory.Bar,
                    Address = "78 Đường Bạch Đằng, TP. HCM",
                    ImagePublicId = null,
                    Latitude = 10.7760,
                    Longitude = 106.6985,
                    Description = "Bar với không gian ngoài trời, nhạc sống mỗi tối.",
                    OpenTime = "18:00",
                    CloseTime = "02:00",
                    Status = RestaurantStatus.PENDING,
                    IsHidden = false,
                    CreatedAt = DateTime.UtcNow
                },

                // UserId = 12 (business)
                new Restaurant
                {
                    Id = 11,
                    OwnerId = 12,
                    Name = "Nhà Hàng Chay An Lạc",
                    Category = RestaurantCategory.AnChay,
                    Address = "90 Đường Phan Chu Trinh, TP. HCM",
                    ImagePublicId = null,
                    Latitude = 10.7810,
                    Longitude = 106.7030,
                    Description = "Các món chay thanh tịnh, tốt cho sức khỏe và tâm hồn.",
                    OpenTime = "07:30",
                    CloseTime = "20:30",
                    Status = RestaurantStatus.APPROVED,
                    IsHidden = false,
                    CreatedAt = DateTime.UtcNow
                },
                new Restaurant
                {
                    Id = 12,
                    OwnerId = 12,
                    Name = "Cafe Mặt Trời",
                    Category = RestaurantCategory.CafeNuocUong,
                    Address = "23 Đường Lê Lợi, TP. HCM",
                    ImagePublicId = null,
                    Latitude = 10.7830,
                    Longitude = 106.7050,
                    Description = "Cafe với không gian ngoài trời, view đẹp.",
                    OpenTime = "06:30",
                    CloseTime = "19:00",
                    Status = RestaurantStatus.APPROVED,
                    IsHidden = false,
                    CreatedAt = DateTime.UtcNow
                },

                // UserId = 14 (business)
                new Restaurant
                {
                    Id = 13,
                    OwnerId = 14,
                    Name = "Nhà Hàng Bò Né 3 Ngon",
                    Category = RestaurantCategory.NhaHang,
                    Address = "12 Đường Nguyễn Văn Cừ, TP. HCM",
                    ImagePublicId = null,
                    Latitude = 10.7745,
                    Longitude = 106.6938,
                    Description = "Nhà hàng phục vụ bò né và các món ăn Việt truyền thống.",
                    OpenTime = "09:00",
                    CloseTime = "22:00",
                    Status = RestaurantStatus.APPROVED,
                    IsHidden = false,
                    CreatedAt = DateTime.UtcNow
                },
                new Restaurant
                {
                    Id = 14,
                    OwnerId = 14,
                    Name = "Quán Ăn Vặt Phố Xinh",
                    Category = RestaurantCategory.AnVatViaHe,
                    Address = "45 Đường Phạm Ngũ Lão, TP. HCM",
                    ImagePublicId = null,
                    Latitude = 10.7705,
                    Longitude = 106.6980,
                    Description = "Quán ăn vặt nổi tiếng, giá sinh viên, đông khách.",
                    OpenTime = "14:00",
                    CloseTime = "23:00",
                    Status = RestaurantStatus.PENDING,
                    IsHidden = false,
                    CreatedAt = DateTime.UtcNow
                },

                // UserId = 16 (business)
                new Restaurant
                {
                    Id = 15,
                    OwnerId = 16,
                    Name = "Nhà Hàng Hải Sản Đại Dương",
                    Category = RestaurantCategory.NhaHang,
                    Address = "78 Đường Trần Phú, TP. HCM",
                    ImagePublicId = null,
                    Latitude = 10.7795,
                    Longitude = 106.7025,
                    Description = "Hải sản tươi sống, không gian sang trọng bên bờ biển.",
                    OpenTime = "09:00",
                    CloseTime = "22:00",
                    Status = RestaurantStatus.APPROVED,
                    IsHidden = false,
                    CreatedAt = DateTime.UtcNow
                },
                new Restaurant
                {
                    Id = 16,
                    OwnerId = 16,
                    Name = "Bar Blue Night",
                    Category = RestaurantCategory.Bar,
                    Address = "90 Đường Trần Phú, TP. HCM",
                    ImagePublicId = null,
                    Latitude = 10.7805,
                    Longitude = 106.7030,
                    Description = "Bar với nhạc EDM và cocktail đặc sắc.",
                    OpenTime = "19:00",
                    CloseTime = "02:00",
                    Status = RestaurantStatus.PENDING,
                    IsHidden = false,
                    CreatedAt = DateTime.UtcNow
                },

                // UserId = 18 (business)
                new Restaurant
                {
                    Id = 17,
                    OwnerId = 18,
                    Name = "Cafe Gió Biển",
                    Category = RestaurantCategory.CafeNuocUong,
                    Address = "21 Đường Trần Phú, TP. HCM",
                    ImagePublicId = null,
                    Latitude = 10.7815,
                    Longitude = 106.7040,
                    Description = "Cafe view biển, phục vụ đồ uống và bánh ngọt.",
                    OpenTime = "06:30",
                    CloseTime = "21:00",
                    Status = RestaurantStatus.APPROVED,
                    IsHidden = false,
                    CreatedAt = DateTime.UtcNow
                },
                new Restaurant
                {
                    Id = 18,
                    OwnerId = 18,
                    Name = "Quán Nhậu Biển Xanh",
                    Category = RestaurantCategory.QuanNhau,
                    Address = "33 Đường Lê Hồng Phong, TP. HCM",
                    ImagePublicId = null,
                    Latitude = 10.7825,
                    Longitude = 106.7050,
                    Description = "Quán nhậu dân dã, hải sản tươi ngon, không gian thoải mái.",
                    OpenTime = "17:00",
                    CloseTime = "00:00",
                    Status = RestaurantStatus.APPROVED,
                    IsHidden = false,
                    CreatedAt = DateTime.UtcNow
                },

                // UserId = 20 (business)
                new Restaurant
                {
                    Id = 19,
                    OwnerId = 20,
                    Name = "Nhà Hàng Buffet Hoàng Gia",
                    Category = RestaurantCategory.Buffet,
                    Address = "12 Đường Nguyễn Trãi, TP. HCM",
                    ImagePublicId = null,
                    Latitude = 10.7700,
                    Longitude = 106.6985,
                    Description = "Buffet cao cấp với đa dạng món ăn Á – Âu.",
                    OpenTime = "11:00",
                    CloseTime = "22:00",
                    Status = RestaurantStatus.APPROVED,
                    IsHidden = false,
                    CreatedAt = DateTime.UtcNow
                },
                new Restaurant
                {
                    Id = 20,
                    OwnerId = 20,
                    Name = "Bar Red Moon",
                    Category = RestaurantCategory.Bar,
                    Address = "34 Đường Trần Nhân Tông, TP. HCM",
                    ImagePublicId = null,
                    Latitude = 10.7720,
                    Longitude = 106.6990,
                    Description = "Bar sôi động với âm nhạc trẻ trung, cocktail đặc sắc.",
                    OpenTime = "19:00",
                    CloseTime = "02:00",
                    Status = RestaurantStatus.PENDING,
                    IsHidden = false,
                    CreatedAt = DateTime.UtcNow
                }
            );
        }
    }
}
