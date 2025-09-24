using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class RestaurantSeeder_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Address", "Category", "CloseTime", "CreatedAt", "Description", "ImagePublicId", "IsHidden", "Latitude", "Longitude", "Name", "OpenTime", "OwnerId", "Status" },
                values: new object[,]
                {
                    { 1, "123 Đường Biển, TP. HCM", 1, "22:00", new DateTime(2025, 9, 18, 15, 4, 19, 375, DateTimeKind.Utc).AddTicks(6503), "Chuyên các món hải sản tươi sống, không gian sang trọng.", null, false, 10.776899999999999, 106.7009, "Nhà Hàng Hải Sản Biển Xanh", "09:00", 2, 1 },
                    { 2, "456 Đường Lê Lợi, Hà Nội", 2, "23:00", new DateTime(2025, 9, 18, 15, 4, 19, 375, DateTimeKind.Utc).AddTicks(6507), "Quán ăn vặt bình dân, giá rẻ, hợp túi tiền sinh viên.", null, false, 21.028500000000001, 105.85420000000001, "Quán Ăn Vỉa Hè", "15:00", 2, 0 },
                    { 3, "789 Đường Nguyễn Huệ, Đà Nẵng", 4, "21:00", new DateTime(2025, 9, 18, 15, 4, 19, 375, DateTimeKind.Utc).AddTicks(6510), "Quán cafe view đẹp, thích hợp để học tập và làm việc.", null, false, 16.054400000000001, 108.2022, "Cafe Góc Phố", "07:00", 4, 1 },
                    { 4, "654 Đường Hòa Bình, Cần Thơ", 7, "00:00", new DateTime(2025, 9, 18, 15, 4, 19, 375, DateTimeKind.Utc).AddTicks(6512), "Chuyên các món nhậu dân dã, không gian thoải mái.", null, false, 10.045199999999999, 105.7469, "Quán Nhậu Bình Dân", "16:00", 4, 1 },
                    { 5, "321 Đường Nguyễn Văn Linh, Huế", 3, "21:00", new DateTime(2025, 9, 18, 15, 4, 19, 375, DateTimeKind.Utc).AddTicks(6515), "Nhà hàng chay thanh tịnh, chuyên phục vụ các món ăn tốt cho sức khỏe.", null, false, 16.463699999999999, 107.5909, "Nhà Hàng Chay Tâm An", "08:00", 6, 1 },
                    { 6, "888 Đường Trần Hưng Đạo, Hà Nội", 6, "03:00", new DateTime(2025, 9, 18, 15, 4, 19, 375, DateTimeKind.Utc).AddTicks(6518), "Bar sôi động với DJ và nhạc EDM cực chất.", null, false, 21.033799999999999, 105.84999999999999, "Bar The Night", "20:00", 6, 0 }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 1, 32, 662, DateTimeKind.Utc).AddTicks(559));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 1, 32, 662, DateTimeKind.Utc).AddTicks(562));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 1, 32, 662, DateTimeKind.Utc).AddTicks(565));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 1, 32, 662, DateTimeKind.Utc).AddTicks(567));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 1, 32, 662, DateTimeKind.Utc).AddTicks(569));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 1, 32, 662, DateTimeKind.Utc).AddTicks(572));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 1, 32, 662, DateTimeKind.Utc).AddTicks(574));
        }
    }
}
