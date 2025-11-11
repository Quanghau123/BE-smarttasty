using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class update_orderv_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VoucherCode",
                table: "Promotions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppliedPromotionId",
                table: "Orders",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppliedVoucherCode",
                table: "Orders",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate", "VoucherCode" },
                values: new object[] { new DateTime(2025, 12, 11, 19, 8, 3, 342, DateTimeKind.Utc).AddTicks(4806), new DateTime(2025, 11, 11, 19, 8, 3, 342, DateTimeKind.Utc).AddTicks(4806), null });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate", "VoucherCode" },
                values: new object[] { new DateTime(2026, 1, 11, 19, 8, 3, 342, DateTimeKind.Utc).AddTicks(4815), new DateTime(2025, 11, 11, 19, 8, 3, 342, DateTimeKind.Utc).AddTicks(4815), null });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate", "VoucherCode" },
                values: new object[] { new DateTime(2025, 12, 11, 19, 8, 3, 342, DateTimeKind.Utc).AddTicks(4818), new DateTime(2025, 11, 11, 19, 8, 3, 342, DateTimeKind.Utc).AddTicks(4818), null });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate", "VoucherCode" },
                values: new object[] { new DateTime(2026, 2, 11, 19, 8, 3, 342, DateTimeKind.Utc).AddTicks(4820), new DateTime(2025, 11, 11, 19, 8, 3, 342, DateTimeKind.Utc).AddTicks(4820), null });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 8, 3, 342, DateTimeKind.Utc).AddTicks(4710));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 8, 3, 342, DateTimeKind.Utc).AddTicks(4715));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 8, 3, 342, DateTimeKind.Utc).AddTicks(4718));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 8, 3, 342, DateTimeKind.Utc).AddTicks(4720));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 8, 3, 342, DateTimeKind.Utc).AddTicks(4722));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 8, 3, 342, DateTimeKind.Utc).AddTicks(4725));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 8, 3, 342, DateTimeKind.Utc).AddTicks(4848));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 8, 3, 342, DateTimeKind.Utc).AddTicks(4849));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 8, 3, 342, DateTimeKind.Utc).AddTicks(4851));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 8, 3, 342, DateTimeKind.Utc).AddTicks(4853));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 8, 3, 342, DateTimeKind.Utc).AddTicks(4854));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 8, 3, 342, DateTimeKind.Utc).AddTicks(4855));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 8, 3, 342, DateTimeKind.Utc).AddTicks(4857));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 8, 3, 342, DateTimeKind.Utc).AddTicks(4858));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 8, 3, 342, DateTimeKind.Utc).AddTicks(4859));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 8, 3, 342, DateTimeKind.Utc).AddTicks(4861));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 8, 3, 342, DateTimeKind.Utc).AddTicks(4862));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 8, 3, 342, DateTimeKind.Utc).AddTicks(4863));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 8, 3, 342, DateTimeKind.Utc).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 8, 3, 342, DateTimeKind.Utc).AddTicks(4317));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 8, 3, 342, DateTimeKind.Utc).AddTicks(4319));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 8, 3, 342, DateTimeKind.Utc).AddTicks(4329));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 8, 3, 342, DateTimeKind.Utc).AddTicks(4332));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 8, 3, 342, DateTimeKind.Utc).AddTicks(4334));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 8, 3, 342, DateTimeKind.Utc).AddTicks(4336));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VoucherCode",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "AppliedPromotionId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AppliedVoucherCode",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 11, 17, 38, 39, 994, DateTimeKind.Utc).AddTicks(1480), new DateTime(2025, 11, 11, 17, 38, 39, 994, DateTimeKind.Utc).AddTicks(1478) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 1, 11, 17, 38, 39, 994, DateTimeKind.Utc).AddTicks(1508), new DateTime(2025, 11, 11, 17, 38, 39, 994, DateTimeKind.Utc).AddTicks(1499) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 11, 17, 38, 39, 994, DateTimeKind.Utc).AddTicks(1513), new DateTime(2025, 11, 11, 17, 38, 39, 994, DateTimeKind.Utc).AddTicks(1512) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 2, 11, 17, 38, 39, 994, DateTimeKind.Utc).AddTicks(1516), new DateTime(2025, 11, 11, 17, 38, 39, 994, DateTimeKind.Utc).AddTicks(1516) });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 17, 38, 39, 994, DateTimeKind.Utc).AddTicks(1281));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 17, 38, 39, 994, DateTimeKind.Utc).AddTicks(1286));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 17, 38, 39, 994, DateTimeKind.Utc).AddTicks(1290));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 17, 38, 39, 994, DateTimeKind.Utc).AddTicks(1294));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 17, 38, 39, 994, DateTimeKind.Utc).AddTicks(1297));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 17, 38, 39, 994, DateTimeKind.Utc).AddTicks(1301));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 17, 38, 39, 994, DateTimeKind.Utc).AddTicks(1576));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 17, 38, 39, 994, DateTimeKind.Utc).AddTicks(1579));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 17, 38, 39, 994, DateTimeKind.Utc).AddTicks(1581));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 17, 38, 39, 994, DateTimeKind.Utc).AddTicks(1583));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 17, 38, 39, 994, DateTimeKind.Utc).AddTicks(1585));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 17, 38, 39, 994, DateTimeKind.Utc).AddTicks(1613));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 17, 38, 39, 994, DateTimeKind.Utc).AddTicks(1617));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 17, 38, 39, 994, DateTimeKind.Utc).AddTicks(1620));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 17, 38, 39, 994, DateTimeKind.Utc).AddTicks(1623));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 17, 38, 39, 994, DateTimeKind.Utc).AddTicks(1625));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 17, 38, 39, 994, DateTimeKind.Utc).AddTicks(1627));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 17, 38, 39, 994, DateTimeKind.Utc).AddTicks(1630));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 17, 38, 39, 994, DateTimeKind.Utc).AddTicks(605));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 17, 38, 39, 994, DateTimeKind.Utc).AddTicks(610));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 17, 38, 39, 994, DateTimeKind.Utc).AddTicks(737));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 17, 38, 39, 994, DateTimeKind.Utc).AddTicks(742));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 17, 38, 39, 994, DateTimeKind.Utc).AddTicks(746));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 17, 38, 39, 994, DateTimeKind.Utc).AddTicks(749));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 17, 38, 39, 994, DateTimeKind.Utc).AddTicks(753));
        }
    }
}
