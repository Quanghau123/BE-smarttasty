using backend.Domain.Models;
using backend.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace backend.Infrastructure.Data.Seeders
{
    public static class RecipeReviewSeeder
    {
        public static void SeedRecipeReviews(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeReview>().HasData(

                new RecipeReview { Id = 1, RecipeId = 1, UserId = 3, Rating = 5, Comment = "Món ăn rất ngon và dễ làm!", CreatedAt = DateTime.UtcNow },
                new RecipeReview { Id = 2, RecipeId = 1, UserId = 5, Rating = 4, Comment = "Sốt thịt bò thơm, mì mềm vừa ăn.", CreatedAt = DateTime.UtcNow },
                new RecipeReview { Id = 3, RecipeId = 1, UserId = 7, Rating = 5, Comment = "Công thức chi tiết, làm xong ngon y như nhà hàng.", CreatedAt = DateTime.UtcNow },
                new RecipeReview { Id = 4, RecipeId = 1, UserId = 9, Rating = 4, Comment = "Gia vị vừa miệng, mình sẽ thử lại lần nữa.", CreatedAt = DateTime.UtcNow },
                new RecipeReview { Id = 5, RecipeId = 1, UserId = 11, Rating = 5, Comment = "Rất hài lòng với món spaghetti này!", CreatedAt = DateTime.UtcNow },
                new RecipeReview { Id = 6, RecipeId = 2, UserId = 3, Rating = 5, Comment = "Gỏi cuốn tươi mát, ăn cực đã.", CreatedAt = DateTime.UtcNow },
                new RecipeReview { Id = 7, RecipeId = 2, UserId = 5, Rating = 4, Comment = "Nhân đầy đủ, nước chấm ngon.", CreatedAt = DateTime.UtcNow },
                new RecipeReview { Id = 8, RecipeId = 2, UserId = 7, Rating = 5, Comment = "Rất dễ làm theo hướng dẫn, thành công 100%.", CreatedAt = DateTime.UtcNow },
                new RecipeReview { Id = 9, RecipeId = 2, UserId = 9, Rating = 4, Comment = "Thích nhất phần rau sống tươi.", CreatedAt = DateTime.UtcNow },
                new RecipeReview { Id = 10, RecipeId = 2, UserId = 11, Rating = 5, Comment = "Ăn ngon và healthy, sẽ làm lại nhiều lần.", CreatedAt = DateTime.UtcNow },
                new RecipeReview { Id = 11, RecipeId = 3, UserId = 3, Rating = 5, Comment = "Bánh flan mềm mịn, caramel ngon tuyệt.", CreatedAt = DateTime.UtcNow },
                new RecipeReview { Id = 12, RecipeId = 3, UserId = 5, Rating = 4, Comment = "Mình thích vị béo vừa phải, không ngọt quá.", CreatedAt = DateTime.UtcNow },
                new RecipeReview { Id = 13, RecipeId = 3, UserId = 7, Rating = 5, Comment = "Công thức đơn giản, thành công ngay lần đầu.", CreatedAt = DateTime.UtcNow },
                new RecipeReview { Id = 14, RecipeId = 3, UserId = 9, Rating = 4, Comment = "Caramel thơm, bánh mịn, ngon.", CreatedAt = DateTime.UtcNow },
                new RecipeReview { Id = 15, RecipeId = 3, UserId = 11, Rating = 5, Comment = "Rất thích món tráng miệng này!", CreatedAt = DateTime.UtcNow },
                new RecipeReview { Id = 16, RecipeId = 4, UserId = 3, Rating = 5, Comment = "Trà sữa thơm ngon, trân châu mềm.", CreatedAt = DateTime.UtcNow },
                new RecipeReview { Id = 17, RecipeId = 4, UserId = 5, Rating = 4, Comment = "Đường vừa phải, không quá ngọt.", CreatedAt = DateTime.UtcNow },
                new RecipeReview { Id = 18, RecipeId = 4, UserId = 7, Rating = 5, Comment = "Mình làm theo công thức, cực ngon!", CreatedAt = DateTime.UtcNow },
                new RecipeReview { Id = 19, RecipeId = 4, UserId = 9, Rating = 4, Comment = "Thích nhất vị trà đậm, béo vừa.", CreatedAt = DateTime.UtcNow },
                new RecipeReview { Id = 20, RecipeId = 4, UserId = 11, Rating = 5, Comment = "Trân châu mềm dẻo, uống cực đã.", CreatedAt = DateTime.UtcNow },
                new RecipeReview { Id = 21, RecipeId = 5, UserId = 3, Rating = 5, Comment = "Cơm chiên hải sản vừa miệng, ngon.", CreatedAt = DateTime.UtcNow },
                new RecipeReview { Id = 22, RecipeId = 5, UserId = 5, Rating = 4, Comment = "Món chiên thơm, hải sản tươi.", CreatedAt = DateTime.UtcNow },
                new RecipeReview { Id = 23, RecipeId = 5, UserId = 7, Rating = 5, Comment = "Chiên vừa lửa, cơm tơi xốp.", CreatedAt = DateTime.UtcNow },
                new RecipeReview { Id = 24, RecipeId = 5, UserId = 9, Rating = 4, Comment = "Món ngon, dễ làm theo hướng dẫn.", CreatedAt = DateTime.UtcNow },
                new RecipeReview { Id = 25, RecipeId = 5, UserId = 11, Rating = 5, Comment = "Hải sản đầy đủ, ăn rất đã.", CreatedAt = DateTime.UtcNow }
            );
        }
    }
}
