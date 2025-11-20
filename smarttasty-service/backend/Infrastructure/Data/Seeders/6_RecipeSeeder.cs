using backend.Domain.Models;
using backend.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace backend.Infrastructure.Data.Seeders
{
    public static class RecipeSeeder
    {
        public static void SeedRecipes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>().HasData(
                new Recipe
                {
                    Id = 1,
                    UserId = 3,
                    Title = "Spaghetti Bolognese",
                    Category = RecipeCategory.MonChinh,
                    Description = "Món spaghetti sốt thịt kiểu Ý, thơm đậm đà.",
                    Ingredients = "Spaghetti, thịt bò xay, cà chua, hành tây, tỏi, dầu ô liu",
                    Steps = "1. Luộc mì.\n2. Phi hành tỏi.\n3. Xào thịt bò.\n4. Thêm sốt cà chua.\n5. Trộn với mì và thưởng thức.",
                    Image = "null",
                    CreatedAt = DateTime.UtcNow
                },
                new Recipe
                {
                    Id = 2,
                    UserId = 3,
                    Title = "Gỏi Cuốn Tôm Thịt",
                    Category = RecipeCategory.MonCuonGoi,
                    Description = "Món gỏi cuốn thanh mát, phù hợp mùa nóng.",
                    Ingredients = "Bánh tráng, bún, tôm, thịt heo luộc, rau sống",
                    Steps = "1. Luộc tôm thịt.\n2. Chuẩn bị rau sống.\n3. Cuốn cùng bún.\n4. Chấm nước mắm hoặc tương.",
                    Image = "null",
                    CreatedAt = DateTime.UtcNow
                },
                new Recipe
                {
                    Id = 3,
                    UserId = 3,
                    Title = "Bánh Flan Caramel",
                    Category = RecipeCategory.TrangMieng,
                    Description = "Bánh flan mềm mịn với lớp caramel nâu vàng.",
                    Ingredients = "Trứng, sữa tươi, đường, vanilla",
                    Steps = "1. Làm caramel.\n2. Đánh hỗn hợp trứng sữa.\n3. Hấp hoặc nướng cách thủy.\n4. Để lạnh và thưởng thức.",
                    Image = "null",
                    CreatedAt = DateTime.UtcNow
                },

                new Recipe
                {
                    Id = 4,
                    UserId = 5,
                    Title = "Trà Sữa Trân Châu Đường Đen",
                    Category = RecipeCategory.NuocUong,
                    Description = "Trà sữa thơm béo với trân châu mềm dẻo.",
                    Ingredients = "Trà đen, sữa tươi, bột béo, trân châu, đường đen",
                    Steps = "1. Nấu trân châu đường đen.\n2. Pha trà.\n3. Khuấy cùng sữa.\n4. Cho trân châu vào ly.",
                    Image = "null",
                    CreatedAt = DateTime.UtcNow
                },
                new Recipe
                {
                    Id = 5,
                    UserId = 5,
                    Title = "Cơm Chiên Hải Sản",
                    Category = RecipeCategory.MonChienXao,
                    Description = "Cơm chiên thơm lừng với tôm, mực và rau củ.",
                    Ingredients = "Cơm nguội, tôm, mực, trứng, hành tây, đậu Hà Lan",
                    Steps = "1. Xào hải sản.\n2. Thêm cơm và trứng.\n3. Nêm nếm.\n4. Xào đều tay cho tơi.",
                    Image = "null",
                    CreatedAt = DateTime.UtcNow
                },
                new Recipe
                {
                    Id = 6,
                    UserId = 5,
                    Title = "Súp Bí Đỏ",
                    Category = RecipeCategory.MonCanhSup,
                    Description = "Súp bí đỏ mềm mịn, bổ dưỡng.",
                    Ingredients = "Bí đỏ, kem tươi, hành tây, bơ, muối",
                    Steps = "1. Hấp bí đỏ.\n2. Xào hành với bơ.\n3. Xay nhuyễn hỗn hợp.\n4. Nấu sôi nhẹ với kem.",
                    Image = "null",
                    CreatedAt = DateTime.UtcNow
                },

                new Recipe
                {
                    Id = 7,
                    UserId = 7,
                    Title = "Salad Ức Gà Healthy",
                    Category = RecipeCategory.MonAnKieng,
                    Description = "Món salad ít calo, nhiều protein.",
                    Ingredients = "Ức gà, xà lách, cà chua, dưa leo, sốt dầu giấm",
                    Steps = "1. Áp chảo ức gà.\n2. Rửa rau.\n3. Trộn cùng dầu giấm.\n4. Cho gà lên trên.",
                    Image = "null",
                    CreatedAt = DateTime.UtcNow
                },
                new Recipe
                {
                    Id = 8,
                    UserId = 7,
                    Title = "Bánh Mì Chảo",
                    Category = RecipeCategory.MonChinh,
                    Description = "Bánh mì chảo nóng hổi với trứng, pate, xúc xích.",
                    Ingredients = "Pate, trứng, xúc xích, bánh mì",
                    Steps = "1. Làm nóng chảo.\n2. Chiên trứng.\n3. Làm nóng pate và xúc xích.\n4. Ăn cùng bánh mì.",
                    Image = "null",
                    CreatedAt = DateTime.UtcNow
                },
                new Recipe
                {
                    Id = 9,
                    UserId = 7,
                    Title = "Bánh Bông Lan Kem Tươi",
                    Category = RecipeCategory.BanhNgot,
                    Description = "Bánh mềm xốp, phù hợp ăn nhẹ.",
                    Ingredients = "Bột mì, trứng, đường, whipping cream",
                    Steps = "1. Đánh bông trứng.\n2. Trộn bột.\n3. Nướng.\n4. Phết kem.",
                    Image = "null",
                    CreatedAt = DateTime.UtcNow
                },

                new Recipe
                {
                    Id = 10,
                    UserId = 9,
                    Title = "Phở Bò Truyền Thống",
                    Category = RecipeCategory.MonTruyenThong,
                    Description = "Phở bò chuẩn vị truyền thống Việt Nam.",
                    Ingredients = "Xương bò, bánh phở, thịt bò, hành, gừng, gia vị",
                    Steps = "1. Ninh xương.\n2. Sơ chế thịt bò.\n3. Trụng bánh phở.\n4. Chan nước dùng nóng.",
                    Image = "null",
                    CreatedAt = DateTime.UtcNow
                },
                new Recipe
                {
                    Id = 11,
                    UserId = 9,
                    Title = "Bánh Xèo Miền Tây",
                    Category = RecipeCategory.MonNuong,
                    Description = "Bánh xèo giòn rụm, ăn kèm rau sống và nước mắm.",
                    Ingredients = "Bột bánh xèo, tôm, thịt, giá, hành lá",
                    Steps = "1. Pha bột.\n2. Chiên bánh.\n3. Thêm nhân.\n4. Gấp đôi và thưởng thức.",
                    Image = "null",
                    CreatedAt = DateTime.UtcNow
                },
                new Recipe
                {
                    Id = 12,
                    UserId = 9,
                    Title = "Chè Thái",
                    Category = RecipeCategory.TrangMieng,
                    Description = "Chè trái cây mát lạnh, ngọt béo.",
                    Ingredients = "Sầu riêng, thạch, mít, sữa, nước cốt dừa",
                    Steps = "1. Cắt nhỏ trái cây.\n2. Chuẩn bị thạch.\n3. Trộn với sữa.\n4. Thêm đá.",
                    Image = "null",
                    CreatedAt = DateTime.UtcNow
                },

                new Recipe
                {
                    Id = 13,
                    UserId = 11,
                    Title = "Sinh Tố Bơ",
                    Category = RecipeCategory.NuocUong,
                    Description = "Sinh tố béo mịn, thơm ngon.",
                    Ingredients = "Bơ, sữa đặc, sữa tươi, đá",
                    Steps = "1. Cho bơ vào máy xay.\n2. Thêm sữa và đá.\n3. Xay nhuyễn.\n4. Rót ra ly.",
                    Image = "null",
                    CreatedAt = DateTime.UtcNow
                },
                new Recipe
                {
                    Id = 14,
                    UserId = 11,
                    Title = "Cá Hấp Gừng",
                    Category = RecipeCategory.MonLuocHap,
                    Description = "Cá hấp thơm mùi gừng, ăn rất đưa cơm.",
                    Ingredients = "Cá, gừng, hành lá, nước mắm, tiêu",
                    Steps = "1. Sơ chế cá.\n2. Rải gừng hành.\n3. Hấp 15 phút.\n4. Rưới nước mắm.",
                    Image = "null",
                    CreatedAt = DateTime.UtcNow
                },
                new Recipe
                {
                    Id = 15,
                    UserId = 11,
                    Title = "Bánh Mì Thịt Nướng",
                    Category = RecipeCategory.BanhMan,
                    Description = "Bánh mì thơm lừng với thịt nướng và đồ chua.",
                    Ingredients = "Thịt heo, bánh mì, đồ chua, pate, rau",
                    Steps = "1. Ướp thịt.\n2. Nướng thơm vàng.\n3. Kẹp bánh mì.\n4. Thêm đồ chua và rau.",
                    Image = "null",
                    CreatedAt = DateTime.UtcNow
                }
            );
        }
    }
}
