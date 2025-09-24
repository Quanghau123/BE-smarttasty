using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class promotionSeeder_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Category", "Description", "Image", "IsActive", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 1, 0, "Tôm hùm tươi nướng với bơ tỏi thơm lừng.", "", true, "Tôm Hùm Nướng Bơ Tỏi", 1200000f, 1 },
                    { 2, 0, "Sò huyết xào me chua ngọt hấp dẫn.", "", true, "Sò Huyết Xào Me", 250000f, 1 },
                    { 3, 0, "Món ăn vặt quen thuộc với đủ topping.", "", true, "Bánh Tráng Trộn", 30000f, 2 },
                    { 4, 1, "Nước giải khát mát lạnh.", "", true, "Trà Tắc", 15000f, 2 },
                    { 5, 1, "Cafe truyền thống Việt Nam.", "", true, "Cafe Sữa Đá", 25000f, 3 },
                    { 6, 2, "Bánh ngọt ăn kèm cafe.", "", true, "Bánh Ngọt", 35000f, 3 },
                    { 7, 0, "Lẩu cá kèo dân dã miền Tây.", "", true, "Lẩu Cá Kèo", 300000f, 4 },
                    { 8, 1, "Bia tươi mát lạnh.", "", true, "Bia Hơi", 20000f, 4 },
                    { 9, 0, "Món chay thanh đạm, bổ dưỡng.", "", true, "Đậu Hũ Kho Nấm", 80000f, 5 },
                    { 10, 1, "Giúp giải nhiệt, tốt cho sức khỏe.", "", true, "Nước Ép Rau Má", 25000f, 5 },
                    { 11, 1, "Cocktail thanh mát, dễ uống.", "", true, "Cocktail Mojito", 120000f, 6 },
                    { 12, 2, "Snack ăn kèm khi uống rượu.", "", true, "Snack Mix", 60000f, 6 }
                });

            migrationBuilder.InsertData(
                table: "Promotions",
                columns: new[] { "Id", "Description", "DiscountType", "DiscountValue", "EndDate", "RestaurantId", "StartDate", "TargetType", "Title" },
                values: new object[,]
                {
                    { 1, "Khuyến mãi 20% cho tất cả món hải sản trong menu.", 0, 20f, new DateTime(2025, 10, 18, 15, 25, 57, 692, DateTimeKind.Utc).AddTicks(9210), 1, new DateTime(2025, 9, 18, 15, 25, 57, 692, DateTimeKind.Utc).AddTicks(9209), 2, "Giảm 20% Hải Sản" },
                    { 2, "Giảm 15k cho đơn hàng từ 50k trở lên.", 1, 15000f, new DateTime(2025, 11, 18, 15, 25, 57, 692, DateTimeKind.Utc).AddTicks(9218), 2, new DateTime(2025, 9, 18, 15, 25, 57, 692, DateTimeKind.Utc).AddTicks(9218), 1, "Combo Sinh Viên" },
                    { 3, "Áp dụng cho tất cả đồ uống trong menu.", 0, 33.3f, new DateTime(2025, 10, 18, 15, 25, 57, 692, DateTimeKind.Utc).AddTicks(9221), 3, new DateTime(2025, 9, 18, 15, 25, 57, 692, DateTimeKind.Utc).AddTicks(9221), 0, "Mua 2 Tặng 1" },
                    { 4, "Giảm 10% cho tất cả món chay vào ngày Rằm.", 0, 10f, new DateTime(2025, 12, 18, 15, 25, 57, 692, DateTimeKind.Utc).AddTicks(9224), 5, new DateTime(2025, 9, 18, 15, 25, 57, 692, DateTimeKind.Utc).AddTicks(9224), 2, "Khuyến Mãi Ăn Chay" }
                });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 25, 57, 692, DateTimeKind.Utc).AddTicks(9120));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 25, 57, 692, DateTimeKind.Utc).AddTicks(9123));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 25, 57, 692, DateTimeKind.Utc).AddTicks(9126));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 25, 57, 692, DateTimeKind.Utc).AddTicks(9129));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 25, 57, 692, DateTimeKind.Utc).AddTicks(9132));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 25, 57, 692, DateTimeKind.Utc).AddTicks(9134));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 25, 57, 692, DateTimeKind.Utc).AddTicks(8848));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 25, 57, 692, DateTimeKind.Utc).AddTicks(8853));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 25, 57, 692, DateTimeKind.Utc).AddTicks(8856));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 25, 57, 692, DateTimeKind.Utc).AddTicks(8858));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 25, 57, 692, DateTimeKind.Utc).AddTicks(8896));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 25, 57, 692, DateTimeKind.Utc).AddTicks(8899));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 25, 57, 692, DateTimeKind.Utc).AddTicks(8901));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 4, 19, 375, DateTimeKind.Utc).AddTicks(6503));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 4, 19, 375, DateTimeKind.Utc).AddTicks(6507));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 4, 19, 375, DateTimeKind.Utc).AddTicks(6510));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 4, 19, 375, DateTimeKind.Utc).AddTicks(6512));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 4, 19, 375, DateTimeKind.Utc).AddTicks(6515));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 4, 19, 375, DateTimeKind.Utc).AddTicks(6518));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 4, 19, 375, DateTimeKind.Utc).AddTicks(6243));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 4, 19, 375, DateTimeKind.Utc).AddTicks(6247));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 4, 19, 375, DateTimeKind.Utc).AddTicks(6249));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 4, 19, 375, DateTimeKind.Utc).AddTicks(6252));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 4, 19, 375, DateTimeKind.Utc).AddTicks(6254));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 4, 19, 375, DateTimeKind.Utc).AddTicks(6257));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 4, 19, 375, DateTimeKind.Utc).AddTicks(6259));
        }
    }
}
