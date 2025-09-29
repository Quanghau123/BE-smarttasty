using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedReviews_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 29, 14, 39, 22, 648, DateTimeKind.Utc).AddTicks(4807), new DateTime(2025, 9, 29, 14, 39, 22, 648, DateTimeKind.Utc).AddTicks(4806) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 29, 14, 39, 22, 648, DateTimeKind.Utc).AddTicks(4820), new DateTime(2025, 9, 29, 14, 39, 22, 648, DateTimeKind.Utc).AddTicks(4819) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 29, 14, 39, 22, 648, DateTimeKind.Utc).AddTicks(4823), new DateTime(2025, 9, 29, 14, 39, 22, 648, DateTimeKind.Utc).AddTicks(4822) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 29, 14, 39, 22, 648, DateTimeKind.Utc).AddTicks(4863), new DateTime(2025, 9, 29, 14, 39, 22, 648, DateTimeKind.Utc).AddTicks(4863) });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 29, 14, 39, 22, 648, DateTimeKind.Utc).AddTicks(4705));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 29, 14, 39, 22, 648, DateTimeKind.Utc).AddTicks(4709));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 29, 14, 39, 22, 648, DateTimeKind.Utc).AddTicks(4712));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 29, 14, 39, 22, 648, DateTimeKind.Utc).AddTicks(4714));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 29, 14, 39, 22, 648, DateTimeKind.Utc).AddTicks(4717));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 29, 14, 39, 22, 648, DateTimeKind.Utc).AddTicks(4720));

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Comment", "CreatedAt", "Rating", "RestaurantId", "UserId" },
                values: new object[,]
                {
                    { 1, "Hải sản rất tươi, nhân viên phục vụ nhiệt tình.", new DateTime(2025, 9, 29, 14, 39, 22, 648, DateTimeKind.Utc).AddTicks(4895), 5, 1, 1 },
                    { 2, "Không gian đẹp, giá hơi cao nhưng xứng đáng.", new DateTime(2025, 9, 29, 14, 39, 22, 648, DateTimeKind.Utc).AddTicks(4897), 4, 1, 3 },
                    { 3, "Quán ăn vặt ngon, hợp túi tiền.", new DateTime(2025, 9, 29, 14, 39, 22, 648, DateTimeKind.Utc).AddTicks(4899), 4, 2, 1 },
                    { 4, "Đông khách, phục vụ hơi chậm.", new DateTime(2025, 9, 29, 14, 39, 22, 648, DateTimeKind.Utc).AddTicks(4900), 3, 2, 5 },
                    { 5, "Cafe ngon, view đẹp, yên tĩnh học bài.", new DateTime(2025, 9, 29, 14, 39, 22, 648, DateTimeKind.Utc).AddTicks(4901), 5, 3, 1 },
                    { 6, "Không gian ổn, giá hơi cao.", new DateTime(2025, 9, 29, 14, 39, 22, 648, DateTimeKind.Utc).AddTicks(4903), 4, 3, 5 },
                    { 7, "Đồ nhậu ngon, giá rẻ.", new DateTime(2025, 9, 29, 14, 39, 22, 648, DateTimeKind.Utc).AddTicks(4904), 4, 4, 1 },
                    { 8, "Không gian thoải mái, thích hợp tụ tập bạn bè.", new DateTime(2025, 9, 29, 14, 39, 22, 648, DateTimeKind.Utc).AddTicks(4906), 5, 4, 7 },
                    { 9, "Đồ ăn chay ngon, cảm giác nhẹ nhàng.", new DateTime(2025, 9, 29, 14, 39, 22, 648, DateTimeKind.Utc).AddTicks(4907), 5, 5, 1 },
                    { 10, "Món ăn đa dạng, nhân viên thân thiện.", new DateTime(2025, 9, 29, 14, 39, 22, 648, DateTimeKind.Utc).AddTicks(4908), 4, 5, 3 },
                    { 11, "Bar sôi động nhưng hơi ồn.", new DateTime(2025, 9, 29, 14, 39, 22, 648, DateTimeKind.Utc).AddTicks(4910), 3, 6, 1 },
                    { 12, "Nhạc DJ cực chất, không gian sôi động.", new DateTime(2025, 9, 29, 14, 39, 22, 648, DateTimeKind.Utc).AddTicks(4911), 5, 6, 5 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 29, 14, 39, 22, 648, DateTimeKind.Utc).AddTicks(4476));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 29, 14, 39, 22, 648, DateTimeKind.Utc).AddTicks(4480));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 29, 14, 39, 22, 648, DateTimeKind.Utc).AddTicks(4483));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 29, 14, 39, 22, 648, DateTimeKind.Utc).AddTicks(4485));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 29, 14, 39, 22, 648, DateTimeKind.Utc).AddTicks(4488));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 29, 14, 39, 22, 648, DateTimeKind.Utc).AddTicks(4490));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 29, 14, 39, 22, 648, DateTimeKind.Utc).AddTicks(4493));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 19, 4, 47, 33, 667, DateTimeKind.Utc).AddTicks(484), new DateTime(2025, 9, 19, 4, 47, 33, 667, DateTimeKind.Utc).AddTicks(475) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 19, 4, 47, 33, 667, DateTimeKind.Utc).AddTicks(524), new DateTime(2025, 9, 19, 4, 47, 33, 667, DateTimeKind.Utc).AddTicks(512) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 19, 4, 47, 33, 667, DateTimeKind.Utc).AddTicks(533), new DateTime(2025, 9, 19, 4, 47, 33, 667, DateTimeKind.Utc).AddTicks(532) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 19, 4, 47, 33, 667, DateTimeKind.Utc).AddTicks(542), new DateTime(2025, 9, 19, 4, 47, 33, 667, DateTimeKind.Utc).AddTicks(540) });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 4, 47, 33, 657, DateTimeKind.Utc).AddTicks(3126));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 4, 47, 33, 657, DateTimeKind.Utc).AddTicks(3135));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 4, 47, 33, 657, DateTimeKind.Utc).AddTicks(3141));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 4, 47, 33, 657, DateTimeKind.Utc).AddTicks(3147));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 4, 47, 33, 657, DateTimeKind.Utc).AddTicks(3153));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 4, 47, 33, 657, DateTimeKind.Utc).AddTicks(3159));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 4, 47, 33, 657, DateTimeKind.Utc).AddTicks(2348));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 4, 47, 33, 657, DateTimeKind.Utc).AddTicks(2356));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 4, 47, 33, 657, DateTimeKind.Utc).AddTicks(2363));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 4, 47, 33, 657, DateTimeKind.Utc).AddTicks(2370));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 4, 47, 33, 657, DateTimeKind.Utc).AddTicks(2377));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 4, 47, 33, 657, DateTimeKind.Utc).AddTicks(2523));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 4, 47, 33, 657, DateTimeKind.Utc).AddTicks(2530));
        }
    }
}
