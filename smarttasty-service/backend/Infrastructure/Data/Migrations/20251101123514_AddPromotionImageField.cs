using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPromotionImageField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Promotions",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "Image", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8308), null, new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8305) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "Image", "StartDate" },
                values: new object[] { new DateTime(2026, 1, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8317), null, new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8317) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "Image", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8320), null, new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8320) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "Image", "StartDate" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8323), null, new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8322) });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8207));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8210));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8213));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8215));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8218));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8220));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8350));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8351));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8353));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8355));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8356));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8357));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8359));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8360));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8361));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8363));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8364));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8365));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(7955));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(7958));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(7960));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8007));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8010));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8012));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8014));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Promotions");

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 30, 17, 33, 27, 881, DateTimeKind.Utc).AddTicks(2019), new DateTime(2025, 10, 30, 17, 33, 27, 881, DateTimeKind.Utc).AddTicks(2019) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 30, 17, 33, 27, 881, DateTimeKind.Utc).AddTicks(2029), new DateTime(2025, 10, 30, 17, 33, 27, 881, DateTimeKind.Utc).AddTicks(2029) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 30, 17, 33, 27, 881, DateTimeKind.Utc).AddTicks(2032), new DateTime(2025, 10, 30, 17, 33, 27, 881, DateTimeKind.Utc).AddTicks(2032) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 1, 30, 17, 33, 27, 881, DateTimeKind.Utc).AddTicks(2035), new DateTime(2025, 10, 30, 17, 33, 27, 881, DateTimeKind.Utc).AddTicks(2034) });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 30, 17, 33, 27, 881, DateTimeKind.Utc).AddTicks(1900));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 30, 17, 33, 27, 881, DateTimeKind.Utc).AddTicks(1904));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 30, 17, 33, 27, 881, DateTimeKind.Utc).AddTicks(1907));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 30, 17, 33, 27, 881, DateTimeKind.Utc).AddTicks(1910));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 30, 17, 33, 27, 881, DateTimeKind.Utc).AddTicks(1913));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 30, 17, 33, 27, 881, DateTimeKind.Utc).AddTicks(1915));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 30, 17, 33, 27, 881, DateTimeKind.Utc).AddTicks(2064));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 30, 17, 33, 27, 881, DateTimeKind.Utc).AddTicks(2065));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 30, 17, 33, 27, 881, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 30, 17, 33, 27, 881, DateTimeKind.Utc).AddTicks(2068));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 30, 17, 33, 27, 881, DateTimeKind.Utc).AddTicks(2069));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 30, 17, 33, 27, 881, DateTimeKind.Utc).AddTicks(2071));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 30, 17, 33, 27, 881, DateTimeKind.Utc).AddTicks(2072));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 30, 17, 33, 27, 881, DateTimeKind.Utc).AddTicks(2073));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 30, 17, 33, 27, 881, DateTimeKind.Utc).AddTicks(2074));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 30, 17, 33, 27, 881, DateTimeKind.Utc).AddTicks(2076));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 30, 17, 33, 27, 881, DateTimeKind.Utc).AddTicks(2077));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 30, 17, 33, 27, 881, DateTimeKind.Utc).AddTicks(2078));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 30, 17, 33, 27, 881, DateTimeKind.Utc).AddTicks(1569));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 30, 17, 33, 27, 881, DateTimeKind.Utc).AddTicks(1611));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 30, 17, 33, 27, 881, DateTimeKind.Utc).AddTicks(1613));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 30, 17, 33, 27, 881, DateTimeKind.Utc).AddTicks(1616));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 30, 17, 33, 27, 881, DateTimeKind.Utc).AddTicks(1619));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 30, 17, 33, 27, 881, DateTimeKind.Utc).AddTicks(1621));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 30, 17, 33, 27, 881, DateTimeKind.Utc).AddTicks(1623));
        }
    }
}
