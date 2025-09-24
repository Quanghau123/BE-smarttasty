using backend.Domain.Enums;
using backend.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Infrastructure.Data.Seeders
{
    public static class DishSeeder
    {
        public static void SeedDishes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dish>().HasData(
                // Nhà hàng 1 - Hải Sản Biển Xanh
                new Dish
                {
                    Id = 1,
                    Name = "Tôm Hùm Nướng Bơ Tỏi",
                    Category = DishCategory.ThucAn,
                    Description = "Tôm hùm tươi nướng với bơ tỏi thơm lừng.",
                    Price = 1200000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 1
                },
                new Dish
                {
                    Id = 2,
                    Name = "Sò Huyết Xào Me",
                    Category = DishCategory.ThucAn,
                    Description = "Sò huyết xào me chua ngọt hấp dẫn.",
                    Price = 250000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 1
                },

                // Nhà hàng 2 - Quán Ăn Vỉa Hè
                new Dish
                {
                    Id = 3,
                    Name = "Bánh Tráng Trộn",
                    Category = DishCategory.ThucAn,
                    Description = "Món ăn vặt quen thuộc với đủ topping.",
                    Price = 30000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 2
                },
                new Dish
                {
                    Id = 4,
                    Name = "Trà Tắc",
                    Category = DishCategory.NuocUong,
                    Description = "Nước giải khát mát lạnh.",
                    Price = 15000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 2
                },

                // Nhà hàng 3 - Cafe Góc Phố
                new Dish
                {
                    Id = 5,
                    Name = "Cafe Sữa Đá",
                    Category = DishCategory.NuocUong,
                    Description = "Cafe truyền thống Việt Nam.",
                    Price = 25000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 3
                },
                new Dish
                {
                    Id = 6,
                    Name = "Bánh Ngọt",
                    Category = DishCategory.ThucAnThem,
                    Description = "Bánh ngọt ăn kèm cafe.",
                    Price = 35000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 3
                },

                // Nhà hàng 4 - Quán Nhậu Bình Dân
                new Dish
                {
                    Id = 7,
                    Name = "Lẩu Cá Kèo",
                    Category = DishCategory.ThucAn,
                    Description = "Lẩu cá kèo dân dã miền Tây.",
                    Price = 300000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 4
                },
                new Dish
                {
                    Id = 8,
                    Name = "Bia Hơi",
                    Category = DishCategory.NuocUong,
                    Description = "Bia tươi mát lạnh.",
                    Price = 20000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 4
                },

                // Nhà hàng 5 - Nhà Hàng Chay Tâm An
                new Dish
                {
                    Id = 9,
                    Name = "Đậu Hũ Kho Nấm",
                    Category = DishCategory.ThucAn,
                    Description = "Món chay thanh đạm, bổ dưỡng.",
                    Price = 80000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 5
                },
                new Dish
                {
                    Id = 10,
                    Name = "Nước Ép Rau Má",
                    Category = DishCategory.NuocUong,
                    Description = "Giúp giải nhiệt, tốt cho sức khỏe.",
                    Price = 25000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 5
                },

                // Nhà hàng 6 - Bar The Night
                new Dish
                {
                    Id = 11,
                    Name = "Cocktail Mojito",
                    Category = DishCategory.NuocUong,
                    Description = "Cocktail thanh mát, dễ uống.",
                    Price = 120000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 6
                },
                new Dish
                {
                    Id = 12,
                    Name = "Snack Mix",
                    Category = DishCategory.ThucAnThem,
                    Description = "Snack ăn kèm khi uống rượu.",
                    Price = 60000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 6
                }
            );
        }
    }
}
