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

                new Dish
                {
                    Id = 3,
                    Name = "Cua Hoàng Đế Hấp",
                    Category = DishCategory.ThucAn,
                    Description = "Cua hoàng đế tươi sống hấp nguyên con giữ trọn vị ngọt.",
                    Price = 3200000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 1
                },
                new Dish
                {
                    Id = 4,
                    Name = "Ghẹ Rang Muối",
                    Category = DishCategory.ThucAn,
                    Description = "Ghẹ rang muối đậm đà, thịt chắc và thơm.",
                    Price = 450000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 1
                },
                new Dish
                {
                    Id = 5,
                    Name = "Mực Một Nắng Nướng Muối Ớt",
                    Category = DishCategory.ThucAn,
                    Description = "Mực một nắng nướng muối ớt cay thơm, mềm ngọt.",
                    Price = 380000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 1
                },
                new Dish
                {
                    Id = 6,
                    Name = "Hàu Nướng Phô Mai",
                    Category = DishCategory.ThucAn,
                    Description = "Hàu tươi nướng phô mai béo ngậy, hấp dẫn.",
                    Price = 160000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 1
                },
                new Dish
                {
                    Id = 7,
                    Name = "Ốc Hương Rang Tỏi",
                    Category = DishCategory.ThucAn,
                    Description = "Ốc hương rang tỏi thơm lừng, giòn ngọt.",
                    Price = 290000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 1
                },
                new Dish
                {
                    Id = 8,
                    Name = "Tôm Sú Hấp Nước Dừa",
                    Category = DishCategory.ThucAn,
                    Description = "Tôm sú hấp nước dừa thanh ngọt, hương vị tự nhiên.",
                    Price = 420000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 1
                },
                new Dish
                {
                    Id = 9,
                    Name = "Cá Chẽm Nướng Muối Ớt",
                    Category = DishCategory.ThucAn,
                    Description = "Cá chẽm nướng muối ớt, thịt dai và ít xương.",
                    Price = 360000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 1
                },
                new Dish
                {
                    Id = 10,
                    Name = "Cá Mú Hấp HongKong",
                    Category = DishCategory.ThucAn,
                    Description = "Cá mú hấp kiểu HongKong với gừng và nước tương đặc trưng.",
                    Price = 680000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 1
                },
                new Dish
                {
                    Id = 11,
                    Name = "Ngao Xào Bơ Tỏi",
                    Category = DishCategory.ThucAn,
                    Description = "Ngao xào bơ tỏi thơm, thịt ngọt mềm.",
                    Price = 180000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 1
                },
                new Dish
                {
                    Id = 12,
                    Name = "Sò Điệp Nướng Mỡ Hành",
                    Category = DishCategory.ThucAn,
                    Description = "Sò điệp tươi nướng mỡ hành béo thơm.",
                    Price = 220000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 1
                },
                new Dish
                {
                    Id = 13,
                    Name = "Tôm Tích Cháy Tỏi",
                    Category = DishCategory.ThucAn,
                    Description = "Tôm tích cháy tỏi giòn rụm, cực kỳ bắt vị.",
                    Price = 540000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 1
                },
                new Dish
                {
                    Id = 14,
                    Name = "Lẩu Hải Sản Thập Cẩm",
                    Category = DishCategory.ThucAn,
                    Description = "Lẩu hải sản đầy đủ tôm, mực, cá, nghêu cùng rau và bún.",
                    Price = 750000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 1
                },
                new Dish
                {
                    Id = 15,
                    Name = "Bạch Tuộc Nướng Sa Tế",
                    Category = DishCategory.ThucAn,
                    Description = "Bạch tuộc nướng sa tế cay nồng, dai giòn sần sật.",
                    Price = 330000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 1
                },
                new Dish
                {
                    Id = 16,
                    Name = "Bánh Tráng Trộn",
                    Category = DishCategory.ThucAn,
                    Description = "Bánh tráng trộn bò khô, trứng cút, rau răm, mỡ hành đậm vị.",
                    Price = 25000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 2
                },
                new Dish
                {
                    Id = 17,
                    Name = "Phô Mai Que",
                    Category = DishCategory.ThucAn,
                    Description = "Phô mai que chiên vàng giòn, kéo sợi hấp dẫn.",
                    Price = 30000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 2
                },
                new Dish
                {
                    Id = 18,
                    Name = "Cá Viên Chiên",
                    Category = DishCategory.ThucAn,
                    Description = "Cá viên chiên nóng giòn ăn kèm tương ớt và mayonnaise.",
                    Price = 20000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 2
                },
                new Dish
                {
                    Id = 19,
                    Name = "Xúc Xích Nướng",
                    Category = DishCategory.ThucAn,
                    Description = "Xúc xích nướng than thơm lừng, sốt đậm đà.",
                    Price = 15000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 2
                },
                new Dish
                {
                    Id = 20,
                    Name = "Bánh Tráng Cuốn",
                    Category = DishCategory.ThucAn,
                    Description = "Bánh tráng cuốn bơ, hành phi, bò khô, trứng cút.",
                    Price = 20000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 2
                },
                new Dish
                {
                    Id = 21,
                    Name = "Hồ Lô Nướng",
                    Category = DishCategory.ThucAn,
                    Description = "Hồ lô nướng dai giòn, thơm ngon chuẩn vỉa hè.",
                    Price = 20000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 2
                },
                new Dish
                {
                    Id = 22,
                    Name = "Nem Chua Rán",
                    Category = DishCategory.ThucAn,
                    Description = "Nem chua rán giòn ngoài mềm trong, chấm tương ớt tuyệt hảo.",
                    Price = 30000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 2
                },
                new Dish
                {
                    Id = 23,
                    Name = "Khoai Tây Lắc Phô Mai",
                    Category = DishCategory.ThucAn,
                    Description = "Khoai tây chiên lắc phô mai thơm béo, giòn rụm.",
                    Price = 25000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 2
                },
                new Dish
                {
                    Id = 24,
                    Name = "Bánh Mì Nướng Muối Ớt",
                    Category = DishCategory.ThucAn,
                    Description = "Bánh mì nướng giòn sốt bơ, trứng cút và chà bông.",
                    Price = 20000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 2
                },
                new Dish
                {
                    Id = 25,
                    Name = "Trà Tắc",
                    Category = DishCategory.ThucAn,
                    Description = "Trà tắc mát lạnh, vị chua nhẹ giải khát cực tốt.",
                    Price = 10000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 2
                },
                new Dish
                {
                    Id = 26,
                    Name = "Trà Sữa Trân Châu",
                    Category = DishCategory.ThucAn,
                    Description = "Trà sữa trân châu ngọt nhẹ, topping dẻo mềm.",
                    Price = 25000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 2
                },
                new Dish
                {
                    Id = 27,
                    Name = "Bánh Flan Caramel",
                    Category = DishCategory.ThucAn,
                    Description = "Bánh flan béo mềm, caramel thơm ngọt.",
                    Price = 15000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 2
                },
                new Dish
                {
                    Id = 28,
                    Name = "Sữa Chua Đá",
                    Category = DishCategory.ThucAn,
                    Description = "Sữa chua đá mát lạnh, vị chua nhẹ dễ uống.",
                    Price = 12000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 2
                },
                new Dish
                {
                    Id = 29,
                    Name = "Gỏi Xoài Bò Khô",
                    Category = DishCategory.ThucAn,
                    Description = "Gỏi xoài trộn bò khô, đậu phộng và nước mắm chua ngọt.",
                    Price = 30000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 2
                },
                new Dish
                {
                    Id = 30,
                    Name = "Bột Chiên",
                    Category = DishCategory.ThucAn,
                    Description = "Bột chiên trứng giòn mềm, ăn kèm đu đủ bào.",
                    Price = 30000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 2
                },
                new Dish
                {
                    Id = 31,
                    Name = "Cà Phê Đen Đá",
                    Category = DishCategory.NuocUong,
                    Description = "Cà phê đen pha phin truyền thống, đậm vị và tỉnh táo.",
                    Price = 25000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 3
                },
                new Dish
                {
                    Id = 32,
                    Name = "Cà Phê Sữa Đá",
                    Category = DishCategory.NuocUong,
                    Description = "Cà phê sữa đá đậm đà, cực kỳ phù hợp để học tập và làm việc.",
                    Price = 30000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 3
                },
                new Dish
                {
                    Id = 33,
                    Name = "Bạc Xỉu",
                    Category = DishCategory.NuocUong,
                    Description = "Bạc xỉu béo ngậy, ít cà phê, dễ uống.",
                    Price = 28000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 3
                },
                new Dish
                {
                    Id = 34,
                    Name = "Trà Đào Cam Sả",
                    Category = DishCategory.NuocUong,
                    Description = "Trà đào cam sả mát lạnh, hương thơm dễ chịu.",
                    Price = 35000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 3
                },
                new Dish
                {
                    Id = 35,
                    Name = "Trà Vải",
                    Category = DishCategory.NuocUong,
                    Description = "Trà vải ngọt nhẹ, thanh mát, nhiều trái vải.",
                    Price = 35000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 3
                },
                new Dish
                {
                    Id = 36,
                    Name = "Matcha Latte",
                    Category = DishCategory.NuocUong,
                    Description = "Matcha latte béo nhẹ, vị trà xanh thơm dịu.",
                    Price = 42000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 3
                },
                new Dish
                {
                    Id = 37,
                    Name = "Caramel Macchiato",
                    Category = DishCategory.NuocUong,
                    Description = "Caramel macchiato thơm ngọt, nhẹ nhàng và dễ uống.",
                    Price = 45000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 3
                },
                new Dish
                {
                    Id = 38,
                    Name = "Sinh Tố Bơ",
                    Category = DishCategory.NuocUong,
                    Description = "Sinh tố bơ béo mịn, làm từ bơ tươi nguyên chất.",
                    Price = 42000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 3
                },
                new Dish
                {
                    Id = 39,
                    Name = "Sinh Tố Dâu",
                    Category = DishCategory.NuocUong,
                    Description = "Sinh tố dâu chua nhẹ, mát lạnh, phù hợp ngày nóng.",
                    Price = 42000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 3
                },
                new Dish
                {
                    Id = 40,
                    Name = "Nước Ép Cam",
                    Category = DishCategory.NuocUong,
                    Description = "Nước ép cam tươi nguyên chất, giàu vitamin C.",
                    Price = 38000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 3
                },
                new Dish
                {
                    Id = 41,
                    Name = "Latte Nóng",
                    Category = DishCategory.NuocUong,
                    Description = "Ly latte nóng thơm nhẹ, tạo bọt mịn.",
                    Price = 42000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 3
                },
                new Dish
                {
                    Id = 42,
                    Name = "Cappuccino",
                    Category = DishCategory.NuocUong,
                    Description = "Cappuccino với lớp bọt sữa dày và hương cà phê đặc trưng.",
                    Price = 45000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 3
                },
                new Dish
                {
                    Id = 43,
                    Name = "Bánh Mousse Chocolate",
                    Category = DishCategory.ThucAn,
                    Description = "Bánh mousse chocolate mềm mịn, ngọt vừa phải.",
                    Price = 38000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 3
                },
                new Dish
                {
                    Id = 44,
                    Name = "Croissant Bơ",
                    Category = DishCategory.ThucAn,
                    Description = "Bánh croissant bơ thơm phức, vỏ giòn ruộm.",
                    Price = 32000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 3
                },
                new Dish
                {
                    Id = 45,
                    Name = "Bánh Tiramisu",
                    Category = DishCategory.ThucAn,
                    Description = "Tiramisu nhẹ nhàng vị cà phê, kem béo mịn.",
                    Price = 42000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 3
                },
                new Dish
                {
                    Id = 46,
                    Name = "Đậu Phộng Rang Tỏi",
                    Category = DishCategory.ThucAn,
                    Description = "Đậu phộng rang giòn, thơm mùi tỏi – món khai vị quen thuộc.",
                    Price = 30000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 4
                },
                new Dish
                {
                    Id = 47,
                    Name = "Khô Mực Nướng",
                    Category = DishCategory.ThucAn,
                    Description = "Khô mực nướng thơm lừng, xé chấm tương ớt chuẩn vị nhậu.",
                    Price = 120000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 4
                },
                new Dish
                {
                    Id = 48,
                    Name = "Gà Nướng Muối Ớt",
                    Category = DishCategory.ThucAn,
                    Description = "Gà nướng muối ớt cay thơm, da giòn thịt mềm.",
                    Price = 180000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 4
                },
                new Dish
                {
                    Id = 49,
                    Name = "Bò Xào Rau Muống",
                    Category = DishCategory.ThucAn,
                    Description = "Thịt bò xào rau muống thơm tỏi, món nhậu quen thuộc.",
                    Price = 90000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 4
                },
                new Dish
                {
                    Id = 50,
                    Name = "Nghêu Hấp Sả",
                    Category = DishCategory.ThucAn,
                    Description = "Nghêu hấp sả nóng hổi, ngọt nước và thơm mùi sả.",
                    Price = 70000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 4
                },
                new Dish
                {
                    Id = 51,
                    Name = "Ốc Len Xào Dừa",
                    Category = DishCategory.ThucAn,
                    Description = "Ốc len xào nước cốt dừa béo thơm, đặc sản miền Nam.",
                    Price = 80000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 4
                },
                new Dish
                {
                    Id = 52,
                    Name = "Tôm Rim Mặn Ngọt",
                    Category = DishCategory.ThucAn,
                    Description = "Tôm rim mặn ngọt đậm đà, ăn kèm rất đưa bia.",
                    Price = 90000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 4
                },
                new Dish
                {
                    Id = 53,
                    Name = "Sườn Nướng Ngũ Vị",
                    Category = DishCategory.ThucAn,
                    Description = "Sườn nướng ngũ vị thơm mềm, đậm vị.",
                    Price = 150000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 4
                },
                new Dish
                {
                    Id = 54,
                    Name = "Bạch Tuộc Nướng Sa Tế",
                    Category = DishCategory.ThucAn,
                    Description = "Bạch tuộc nướng sa tế cay nồng, giòn sần sật.",
                    Price = 120000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 4
                },
                new Dish
                {
                    Id = 55,
                    Name = "Lẩu Thái Chua Cay",
                    Category = DishCategory.ThucAn,
                    Description = "Lẩu Thái với hải sản và nấm, nước dùng chua cay đậm đà.",
                    Price = 190000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 4
                },
                new Dish
                {
                    Id = 56,
                    Name = "Giò Heo Muối Chiên",
                    Category = DishCategory.ThucAn,
                    Description = "Giò heo muối chiên giòn, nạc mỡ hòa quyện hấp dẫn.",
                    Price = 160000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 4
                },
                new Dish
                {
                    Id = 57,
                    Name = "Gỏi Gà Xé Phay",
                    Category = DishCategory.ThucAn,
                    Description = "Gỏi gà xé phay chua ngọt, giòn và thanh mát.",
                    Price = 85000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 4
                },
                new Dish
                {
                    Id = 58,
                    Name = "Cá Kèo Kho Tộ",
                    Category = DishCategory.ThucAn,
                    Description = "Cá kèo kho tộ đậm vị, thơm mùi tiêu và nước màu.",
                    Price = 95000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 4
                },
                new Dish
                {
                    Id = 59,
                    Name = "Ếch Xào Sả Ớt",
                    Category = DishCategory.ThucAn,
                    Description = "Ếch xào sả ớt thơm cay, rất đưa cơm và đưa bia.",
                    Price = 100000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 4
                },
                new Dish
                {
                    Id = 60,
                    Name = "Bia Tiger Nóng/Lạnh",
                    Category = DishCategory.NuocUong,
                    Description = "Bia Tiger chai/ly, lựa chọn nóng hoặc lạnh.",
                    Price = 25000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 4
                },
                new Dish
                {
                    Id = 61,
                    Name = "Đậu Hũ Sốt Cà",
                    Category = DishCategory.ThucAn,
                    Description = "Đậu hũ mềm sốt cà chua thanh nhẹ, thích hợp cho bữa trưa.",
                    Price = 45000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 5
                },
                new Dish
                {
                    Id = 62,
                    Name = "Nấm Kho Tiêu",
                    Category = DishCategory.ThucAn,
                    Description = "Nấm kho tiêu cay nhẹ, đậm vị, rất đưa cơm.",
                    Price = 50000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 5
                },
                new Dish
                {
                    Id = 63,
                    Name = "Cơm Chiên Chay",
                    Category = DishCategory.ThucAn,
                    Description = "Cơm chiên chay với đậu hũ, cà rốt, đậu Hà Lan và bắp.",
                    Price = 55000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 5
                },
                new Dish
                {
                    Id = 64,
                    Name = "Lẩu Nấm Chay",
                    Category = DishCategory.ThucAn,
                    Description = "Lẩu nấm thanh đạm, nước dùng ngọt tự nhiên từ rau củ.",
                    Price = 160000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 5
                },
                new Dish
                {
                    Id = 65,
                    Name = "Bún Riêu Chay",
                    Category = DishCategory.ThucAn,
                    Description = "Bún riêu chay với đậu hũ, chả chay và nước dùng thơm nhẹ.",
                    Price = 55000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 5
                },
                new Dish
                {
                    Id = 66,
                    Name = "Gỏi Ngó Sen Chay",
                    Category = DishCategory.ThucAn,
                    Description = "Gỏi ngó sen giòn, trộn cùng rau củ và đậu phộng rang.",
                    Price = 60000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 5
                },
                new Dish
                {
                    Id = 67,
                    Name = "Bánh Mì Chay",
                    Category = DishCategory.ThucAn,
                    Description = "Bánh mì chay với nhân nấm, đậu hũ và rau tươi.",
                    Price = 30000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 5
                },
                new Dish
                {
                    Id = 68,
                    Name = "Phở Chay",
                    Category = DishCategory.ThucAn,
                    Description = "Phở chay nước trong, ngọt từ rau củ và quế hồi.",
                    Price = 55000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 5
                },
                new Dish
                {
                    Id = 69,
                    Name = "Miến Xào Chay",
                    Category = DishCategory.ThucAn,
                    Description = "Miến xào chay với nấm, cải và đậu hũ chiên.",
                    Price = 50000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 5
                },
                new Dish
                {
                    Id = 70,
                    Name = "Đậu Hũ Chiên Sả",
                    Category = DishCategory.ThucAn,
                    Description = "Đậu hũ chiên giòn trộn sả ớt thơm lừng.",
                    Price = 45000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 5
                },
                new Dish
                {
                    Id = 71,
                    Name = "Rau Củ Luộc Chấm Kho Quẹt Chay",
                    Category = DishCategory.ThucAn,
                    Description = "Rau củ luộc chấm kho quẹt chay đậm đà, thơm mùi tiêu.",
                    Price = 55000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 5
                },
                new Dish
                {
                    Id = 72,
                    Name = "Bánh Xèo Chay",
                    Category = DishCategory.ThucAn,
                    Description = "Bánh xèo chay giòn rụm, nhân nấm và rau củ.",
                    Price = 60000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 5
                },
                new Dish
                {
                    Id = 73,
                    Name = "Đậu Hũ Non Sốt Nấm Đông Cô",
                    Category = DishCategory.ThucAn,
                    Description = "Đậu hũ non mềm mịn kết hợp nấm đông cô sốt đậm vị.",
                    Price = 55000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 5
                },
                new Dish
                {
                    Id = 74,
                    Name = "Chả Giò Chay",
                    Category = DishCategory.ThucAn,
                    Description = "Chả giò chay giòn rụm bên ngoài, nhân rau củ thơm ngon.",
                    Price = 50000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 5
                },
                new Dish
                {
                    Id = 75,
                    Name = "Súp Rau Củ Chay",
                    Category = DishCategory.ThucAn,
                    Description = "Súp chay nhẹ nhàng từ cà rốt, khoai tây, bắp và nấm.",
                    Price = 45000,
                    Image = "",
                    IsActive = true,
                    RestaurantId = 5
                }
            );
        }
    }
}
