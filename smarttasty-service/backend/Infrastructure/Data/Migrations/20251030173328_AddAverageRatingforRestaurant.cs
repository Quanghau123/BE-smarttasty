using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAverageRatingforRestaurant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AverageRating",
                table: "Restaurants",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

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
                columns: new[] { "AverageRating", "CreatedAt" },
                values: new object[] { 0.0, new DateTime(2025, 10, 30, 17, 33, 27, 881, DateTimeKind.Utc).AddTicks(1900) });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AverageRating", "CreatedAt" },
                values: new object[] { 0.0, new DateTime(2025, 10, 30, 17, 33, 27, 881, DateTimeKind.Utc).AddTicks(1904) });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AverageRating", "CreatedAt" },
                values: new object[] { 0.0, new DateTime(2025, 10, 30, 17, 33, 27, 881, DateTimeKind.Utc).AddTicks(1907) });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AverageRating", "CreatedAt" },
                values: new object[] { 0.0, new DateTime(2025, 10, 30, 17, 33, 27, 881, DateTimeKind.Utc).AddTicks(1910) });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AverageRating", "CreatedAt" },
                values: new object[] { 0.0, new DateTime(2025, 10, 30, 17, 33, 27, 881, DateTimeKind.Utc).AddTicks(1913) });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AverageRating", "CreatedAt" },
                values: new object[] { 0.0, new DateTime(2025, 10, 30, 17, 33, 27, 881, DateTimeKind.Utc).AddTicks(1915) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageRating",
                table: "Restaurants");

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 21, 3, 5, 58, 71, DateTimeKind.Utc).AddTicks(661), new DateTime(2025, 10, 21, 3, 5, 58, 71, DateTimeKind.Utc).AddTicks(660) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 21, 3, 5, 58, 71, DateTimeKind.Utc).AddTicks(689), new DateTime(2025, 10, 21, 3, 5, 58, 71, DateTimeKind.Utc).AddTicks(678) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 21, 3, 5, 58, 71, DateTimeKind.Utc).AddTicks(697), new DateTime(2025, 10, 21, 3, 5, 58, 71, DateTimeKind.Utc).AddTicks(696) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 1, 21, 3, 5, 58, 71, DateTimeKind.Utc).AddTicks(702), new DateTime(2025, 10, 21, 3, 5, 58, 71, DateTimeKind.Utc).AddTicks(701) });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 21, 3, 5, 58, 71, DateTimeKind.Utc).AddTicks(141));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 21, 3, 5, 58, 71, DateTimeKind.Utc).AddTicks(150));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 21, 3, 5, 58, 71, DateTimeKind.Utc).AddTicks(156));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 21, 3, 5, 58, 71, DateTimeKind.Utc).AddTicks(163));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 21, 3, 5, 58, 71, DateTimeKind.Utc).AddTicks(170));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 21, 3, 5, 58, 71, DateTimeKind.Utc).AddTicks(176));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 21, 3, 5, 58, 71, DateTimeKind.Utc).AddTicks(786));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 21, 3, 5, 58, 71, DateTimeKind.Utc).AddTicks(790));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 21, 3, 5, 58, 71, DateTimeKind.Utc).AddTicks(793));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 21, 3, 5, 58, 71, DateTimeKind.Utc).AddTicks(796));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 21, 3, 5, 58, 71, DateTimeKind.Utc).AddTicks(799));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 21, 3, 5, 58, 71, DateTimeKind.Utc).AddTicks(802));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 21, 3, 5, 58, 71, DateTimeKind.Utc).AddTicks(805));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 21, 3, 5, 58, 71, DateTimeKind.Utc).AddTicks(808));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 21, 3, 5, 58, 71, DateTimeKind.Utc).AddTicks(811));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 21, 3, 5, 58, 71, DateTimeKind.Utc).AddTicks(814));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 21, 3, 5, 58, 71, DateTimeKind.Utc).AddTicks(816));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 21, 3, 5, 58, 71, DateTimeKind.Utc).AddTicks(819));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 21, 3, 5, 58, 70, DateTimeKind.Utc).AddTicks(9340));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 21, 3, 5, 58, 70, DateTimeKind.Utc).AddTicks(9349));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 21, 3, 5, 58, 70, DateTimeKind.Utc).AddTicks(9355));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 21, 3, 5, 58, 70, DateTimeKind.Utc).AddTicks(9503));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 21, 3, 5, 58, 70, DateTimeKind.Utc).AddTicks(9510));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 21, 3, 5, 58, 70, DateTimeKind.Utc).AddTicks(9516));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 21, 3, 5, 58, 70, DateTimeKind.Utc).AddTicks(9522));
        }
    }
}
