using backend.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Infrastructure.Data.Seeders
{
    public static class ReviewSeeder
    {
        public static void SeedReviews(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>().HasData(
                // Restaurant 1
                new Review
                {
                    Id = 1,
                    UserId = 1, // giả sử user 1 là khách
                    RestaurantId = 1,
                    Rating = 5,
                    Comment = "Hải sản rất tươi, nhân viên phục vụ nhiệt tình.",
                    CreatedAt = DateTime.UtcNow
                },
                new Review
                {
                    Id = 2,
                    UserId = 3, // user khác
                    RestaurantId = 1,
                    Rating = 4,
                    Comment = "Không gian đẹp, giá hơi cao nhưng xứng đáng.",
                    CreatedAt = DateTime.UtcNow
                },

                // Restaurant 2
                new Review
                {
                    Id = 3,
                    UserId = 1,
                    RestaurantId = 2,
                    Rating = 4,
                    Comment = "Quán ăn vặt ngon, hợp túi tiền.",
                    CreatedAt = DateTime.UtcNow
                },
                new Review
                {
                    Id = 4,
                    UserId = 5,
                    RestaurantId = 2,
                    Rating = 3,
                    Comment = "Đông khách, phục vụ hơi chậm.",
                    CreatedAt = DateTime.UtcNow
                },

                // Restaurant 3
                new Review
                {
                    Id = 5,
                    UserId = 1,
                    RestaurantId = 3,
                    Rating = 5,
                    Comment = "Cafe ngon, view đẹp, yên tĩnh học bài.",
                    CreatedAt = DateTime.UtcNow
                },
                new Review
                {
                    Id = 6,
                    UserId = 5,
                    RestaurantId = 3,
                    Rating = 4,
                    Comment = "Không gian ổn, giá hơi cao.",
                    CreatedAt = DateTime.UtcNow
                },

                // Restaurant 4
                new Review
                {
                    Id = 7,
                    UserId = 1,
                    RestaurantId = 4,
                    Rating = 4,
                    Comment = "Đồ nhậu ngon, giá rẻ.",
                    CreatedAt = DateTime.UtcNow
                },
                new Review
                {
                    Id = 8,
                    UserId = 7,
                    RestaurantId = 4,
                    Rating = 5,
                    Comment = "Không gian thoải mái, thích hợp tụ tập bạn bè.",
                    CreatedAt = DateTime.UtcNow
                },

                // Restaurant 5
                new Review
                {
                    Id = 9,
                    UserId = 1,
                    RestaurantId = 5,
                    Rating = 5,
                    Comment = "Đồ ăn chay ngon, cảm giác nhẹ nhàng.",
                    CreatedAt = DateTime.UtcNow
                },
                new Review
                {
                    Id = 10,
                    UserId = 3,
                    RestaurantId = 5,
                    Rating = 4,
                    Comment = "Món ăn đa dạng, nhân viên thân thiện.",
                    CreatedAt = DateTime.UtcNow
                },

                // Restaurant 6
                new Review
                {
                    Id = 11,
                    UserId = 1,
                    RestaurantId = 6,
                    Rating = 3,
                    Comment = "Bar sôi động nhưng hơi ồn.",
                    CreatedAt = DateTime.UtcNow
                },
                new Review
                {
                    Id = 12,
                    UserId = 5,
                    RestaurantId = 6,
                    Rating = 5,
                    Comment = "Nhạc DJ cực chất, không gian sôi động.",
                    CreatedAt = DateTime.UtcNow
                }
            );
        }
    }
}
