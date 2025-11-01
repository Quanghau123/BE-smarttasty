using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixCODPaymentRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 1, 20, 52, 5, 126, DateTimeKind.Utc).AddTicks(9463), new DateTime(2025, 11, 1, 20, 52, 5, 126, DateTimeKind.Utc).AddTicks(9462) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 1, 1, 20, 52, 5, 126, DateTimeKind.Utc).AddTicks(9472), new DateTime(2025, 11, 1, 20, 52, 5, 126, DateTimeKind.Utc).AddTicks(9471) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 1, 20, 52, 5, 126, DateTimeKind.Utc).AddTicks(9474), new DateTime(2025, 11, 1, 20, 52, 5, 126, DateTimeKind.Utc).AddTicks(9474) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 2, 1, 20, 52, 5, 126, DateTimeKind.Utc).AddTicks(9477), new DateTime(2025, 11, 1, 20, 52, 5, 126, DateTimeKind.Utc).AddTicks(9476) });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 20, 52, 5, 126, DateTimeKind.Utc).AddTicks(9366));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 20, 52, 5, 126, DateTimeKind.Utc).AddTicks(9370));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 20, 52, 5, 126, DateTimeKind.Utc).AddTicks(9372));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 20, 52, 5, 126, DateTimeKind.Utc).AddTicks(9374));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 20, 52, 5, 126, DateTimeKind.Utc).AddTicks(9377));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 20, 52, 5, 126, DateTimeKind.Utc).AddTicks(9379));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 20, 52, 5, 126, DateTimeKind.Utc).AddTicks(9509));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 20, 52, 5, 126, DateTimeKind.Utc).AddTicks(9510));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 20, 52, 5, 126, DateTimeKind.Utc).AddTicks(9512));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 20, 52, 5, 126, DateTimeKind.Utc).AddTicks(9513));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 20, 52, 5, 126, DateTimeKind.Utc).AddTicks(9514));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 20, 52, 5, 126, DateTimeKind.Utc).AddTicks(9516));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 20, 52, 5, 126, DateTimeKind.Utc).AddTicks(9517));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 20, 52, 5, 126, DateTimeKind.Utc).AddTicks(9518));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 20, 52, 5, 126, DateTimeKind.Utc).AddTicks(9519));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 20, 52, 5, 126, DateTimeKind.Utc).AddTicks(9521));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 20, 52, 5, 126, DateTimeKind.Utc).AddTicks(9522));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 20, 52, 5, 126, DateTimeKind.Utc).AddTicks(9523));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 20, 52, 5, 126, DateTimeKind.Utc).AddTicks(9013));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 20, 52, 5, 126, DateTimeKind.Utc).AddTicks(9016));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 20, 52, 5, 126, DateTimeKind.Utc).AddTicks(9019));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 20, 52, 5, 126, DateTimeKind.Utc).AddTicks(9022));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 20, 52, 5, 126, DateTimeKind.Utc).AddTicks(9024));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 20, 52, 5, 126, DateTimeKind.Utc).AddTicks(9027));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 20, 52, 5, 126, DateTimeKind.Utc).AddTicks(9029));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 1, 18, 55, 47, 912, DateTimeKind.Utc).AddTicks(2166), new DateTime(2025, 11, 1, 18, 55, 47, 912, DateTimeKind.Utc).AddTicks(2164) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 1, 1, 18, 55, 47, 912, DateTimeKind.Utc).AddTicks(2179), new DateTime(2025, 11, 1, 18, 55, 47, 912, DateTimeKind.Utc).AddTicks(2175) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 1, 18, 55, 47, 912, DateTimeKind.Utc).AddTicks(2182), new DateTime(2025, 11, 1, 18, 55, 47, 912, DateTimeKind.Utc).AddTicks(2182) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 2, 1, 18, 55, 47, 912, DateTimeKind.Utc).AddTicks(2185), new DateTime(2025, 11, 1, 18, 55, 47, 912, DateTimeKind.Utc).AddTicks(2185) });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 18, 55, 47, 912, DateTimeKind.Utc).AddTicks(1439));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 18, 55, 47, 912, DateTimeKind.Utc).AddTicks(1442));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 18, 55, 47, 912, DateTimeKind.Utc).AddTicks(1446));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 18, 55, 47, 912, DateTimeKind.Utc).AddTicks(1449));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 18, 55, 47, 912, DateTimeKind.Utc).AddTicks(1451));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 18, 55, 47, 912, DateTimeKind.Utc).AddTicks(1453));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 18, 55, 47, 912, DateTimeKind.Utc).AddTicks(2226));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 18, 55, 47, 912, DateTimeKind.Utc).AddTicks(2227));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 18, 55, 47, 912, DateTimeKind.Utc).AddTicks(2229));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 18, 55, 47, 912, DateTimeKind.Utc).AddTicks(2230));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 18, 55, 47, 912, DateTimeKind.Utc).AddTicks(2231));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 18, 55, 47, 912, DateTimeKind.Utc).AddTicks(2233));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 18, 55, 47, 912, DateTimeKind.Utc).AddTicks(2234));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 18, 55, 47, 912, DateTimeKind.Utc).AddTicks(2235));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 18, 55, 47, 912, DateTimeKind.Utc).AddTicks(2237));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 18, 55, 47, 912, DateTimeKind.Utc).AddTicks(2238));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 18, 55, 47, 912, DateTimeKind.Utc).AddTicks(2239));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 18, 55, 47, 912, DateTimeKind.Utc).AddTicks(2241));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 18, 55, 47, 912, DateTimeKind.Utc).AddTicks(1060));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 18, 55, 47, 912, DateTimeKind.Utc).AddTicks(1063));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 18, 55, 47, 912, DateTimeKind.Utc).AddTicks(1066));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 18, 55, 47, 912, DateTimeKind.Utc).AddTicks(1069));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 18, 55, 47, 912, DateTimeKind.Utc).AddTicks(1071));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 18, 55, 47, 912, DateTimeKind.Utc).AddTicks(1073));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 18, 55, 47, 912, DateTimeKind.Utc).AddTicks(1133));
        }
    }
}
