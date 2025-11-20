using backend.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Infrastructure.Data.Seeders
{
    public static class ReviewSeeder
    {
        public static void SeedReviews(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>().HasData(
                new Review { Id = 1, UserId = 3, RestaurantId = 1, Rating = 5, Comment = "Hải sản rất tươi, nêm nếm vừa miệng, không gian sang trọng.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 2, UserId = 5, RestaurantId = 1, Rating = 4, Comment = "Tôm hùm ngon, giá hơi cao nhưng đáng tiền.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 3, UserId = 7, RestaurantId = 1, Rating = 5, Comment = "Phục vụ chu đáo, món ăn lên nhanh, rất hài lòng.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 4, UserId = 9, RestaurantId = 1, Rating = 4, Comment = "Không gian đẹp, phù hợp đi gia đình, sẽ quay lại.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 5, UserId = 11, RestaurantId = 1, Rating = 5, Comment = "Mực hấp siêu ngon, cực kỳ tươi!", CreatedAt = DateTime.UtcNow },
                new Review { Id = 6, UserId = 13, RestaurantId = 1, Rating = 3, Comment = "Hải sản ngon nhưng đông khách quá, đợi hơi lâu.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 7, UserId = 15, RestaurantId = 1, Rating = 5, Comment = "Không gian sang, hải sản tươi, nhân viên thân thiện.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 8, UserId = 17, RestaurantId = 1, Rating = 4, Comment = "Lẩu hải sản ngon, nước dùng ngọt tự nhiên.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 9, UserId = 19, RestaurantId = 1, Rating = 5, Comment = "Chất lượng tuyệt vời, lần sau sẽ dẫn bạn bè tới.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 10, UserId = 3, RestaurantId = 1, Rating = 5, Comment = "Bạch tuộc nướng siêu đỉnh, đáng thử!", CreatedAt = DateTime.UtcNow },
                new Review { Id = 11, UserId = 5, RestaurantId = 2, Rating = 4, Comment = "Đồ ăn ngon, giá rẻ, hợp sinh viên.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 12, UserId = 7, RestaurantId = 2, Rating = 5, Comment = "Bánh tráng trộn cực ngon, đậm vị.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 13, UserId = 9, RestaurantId = 2, Rating = 3, Comment = "Ngon nhưng hơi đông, phục vụ chậm.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 14, UserId = 11, RestaurantId = 2, Rating = 4, Comment = "Trà đào rẻ và ngon, rất đáng thử.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 15, UserId = 13, RestaurantId = 2, Rating = 4, Comment = "Xiên nướng vừa miệng, giá ổn.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 16, UserId = 15, RestaurantId = 2, Rating = 5, Comment = "Đồ ăn lên nhanh, bán đúng giá sinh viên.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 17, UserId = 17, RestaurantId = 2, Rating = 4, Comment = "Bánh tráng cuốn bơ ngon xuất sắc.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 18, UserId = 19, RestaurantId = 2, Rating = 3, Comment = "Quán hơi nhỏ nhưng đồ ăn ngon.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 19, UserId = 3, RestaurantId = 2, Rating = 4, Comment = "Giá mềm, rất đáng để thử.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 20, UserId = 5, RestaurantId = 2, Rating = 5, Comment = "Ăn vặt chất lượng, nhất định quay lại.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 21, UserId = 7, RestaurantId = 3, Rating = 5, Comment = "Không gian yên tĩnh, rất thích hợp để làm việc.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 22, UserId = 9, RestaurantId = 3, Rating = 4, Comment = "Cà phê ngon, giá hợp lý.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 23, UserId = 11, RestaurantId = 3, Rating = 5, Comment = "Trà sữa machiato ngon bất ngờ.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 24, UserId = 13, RestaurantId = 3, Rating = 4, Comment = "Không gian đẹp, nhiều góc sống ảo.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 25, UserId = 15, RestaurantId = 3, Rating = 5, Comment = "Phục vụ lịch sự, nước mang ra nhanh.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 26, UserId = 17, RestaurantId = 3, Rating = 4, Comment = "Âm nhạc nhẹ nhàng, relaxing.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 27, UserId = 19, RestaurantId = 3, Rating = 5, Comment = "Cafe trứng rất ngon, đậm vị.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 28, UserId = 3, RestaurantId = 3, Rating = 4, Comment = "Wifi mạnh, phù hợp làm việc online.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 29, UserId = 5, RestaurantId = 3, Rating = 5, Comment = "Frappuccino ngon, giá mềm.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 30, UserId = 7, RestaurantId = 3, Rating = 5, Comment = "View đường Nguyễn Huệ quá đẹp.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 31, UserId = 9, RestaurantId = 4, Rating = 4, Comment = "Món nhậu ngon, giá bình dân, hợp nhóm bạn.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 32, UserId = 11, RestaurantId = 4, Rating = 5, Comment = "Ếch xào sa tế xuất sắc, ăn là ghiền.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 33, UserId = 13, RestaurantId = 4, Rating = 4, Comment = "Quán rộng rãi, phục vụ ổn.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 34, UserId = 15, RestaurantId = 4, Rating = 5, Comment = "Chân gà sả tắc chuẩn vị.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 35, UserId = 17, RestaurantId = 4, Rating = 3, Comment = "Đồ ăn ngon nhưng hơi ồn.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 36, UserId = 19, RestaurantId = 4, Rating = 4, Comment = "Bia lạnh, món lên nhanh.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 37, UserId = 3, RestaurantId = 4, Rating = 5, Comment = "Đồ ăn rất hợp khẩu vị, đáng thử.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 38, UserId = 5, RestaurantId = 4, Rating = 4, Comment = "Giá rẻ, phù hợp tụ tập bạn bè.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 39, UserId = 7, RestaurantId = 4, Rating = 5, Comment = "Lẩu thái ngon, đậm đà.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 40, UserId = 9, RestaurantId = 4, Rating = 4, Comment = "Không gian thoải mái, đồ ăn ổn.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 41, UserId = 11, RestaurantId = 5, Rating = 5, Comment = "Đồ chay thanh đạm, ăn rất nhẹ bụng.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 42, UserId = 13, RestaurantId = 5, Rating = 4, Comment = "Không gian yên tĩnh, rất thư giãn.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 43, UserId = 15, RestaurantId = 5, Rating = 5, Comment = "Món cơm thập cẩm rất ngon, giá hợp lý.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 44, UserId = 17, RestaurantId = 5, Rating = 4, Comment = "Phở chay thơm, nước dùng ngon.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 45, UserId = 19, RestaurantId = 5, Rating = 5, Comment = "Đồ ăn sạch, cảm giác rất healthy.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 46, UserId = 3, RestaurantId = 5, Rating = 5, Comment = "Mình rất thích hủ tiếu chay ở đây.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 47, UserId = 5, RestaurantId = 5, Rating = 4, Comment = "Không gian đẹp, nhẹ nhàng, thanh tịnh.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 48, UserId = 7, RestaurantId = 5, Rating = 5, Comment = "Rau củ luôn tươi, chế biến ngon.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 49, UserId = 9, RestaurantId = 5, Rating = 4, Comment = "Giá hợp lý, món đa dạng.", CreatedAt = DateTime.UtcNow },
                new Review { Id = 50, UserId = 11, RestaurantId = 5, Rating = 5, Comment = "Ăn chay mà vị vẫn rất hấp dẫn!", CreatedAt = DateTime.UtcNow }
            );
        }
    }
}
