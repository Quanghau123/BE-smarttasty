using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatetableorderpromotion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsGlobal",
                table: "OrderPromotions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "OrderPromotions",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TargetUserId",
                table: "OrderPromotions",
                type: "integer",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_OrderPromotions_RestaurantId",
                table: "OrderPromotions",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPromotions_Restaurants_RestaurantId",
                table: "OrderPromotions",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderPromotions_Restaurants_RestaurantId",
                table: "OrderPromotions");

            migrationBuilder.DropIndex(
                name: "IX_OrderPromotions_RestaurantId",
                table: "OrderPromotions");

            migrationBuilder.DropColumn(
                name: "IsGlobal",
                table: "OrderPromotions");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "OrderPromotions");

            migrationBuilder.DropColumn(
                name: "TargetUserId",
                table: "OrderPromotions");

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 11, 16, 15, 48, 136, DateTimeKind.Utc).AddTicks(602), new DateTime(2025, 11, 11, 16, 15, 48, 136, DateTimeKind.Utc).AddTicks(601) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 1, 11, 16, 15, 48, 136, DateTimeKind.Utc).AddTicks(621), new DateTime(2025, 11, 11, 16, 15, 48, 136, DateTimeKind.Utc).AddTicks(619) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 11, 16, 15, 48, 136, DateTimeKind.Utc).AddTicks(627), new DateTime(2025, 11, 11, 16, 15, 48, 136, DateTimeKind.Utc).AddTicks(626) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 2, 11, 16, 15, 48, 136, DateTimeKind.Utc).AddTicks(633), new DateTime(2025, 11, 11, 16, 15, 48, 136, DateTimeKind.Utc).AddTicks(632) });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 16, 15, 48, 136, DateTimeKind.Utc).AddTicks(363));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 16, 15, 48, 136, DateTimeKind.Utc).AddTicks(372));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 16, 15, 48, 136, DateTimeKind.Utc).AddTicks(379));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 16, 15, 48, 136, DateTimeKind.Utc).AddTicks(386));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 16, 15, 48, 136, DateTimeKind.Utc).AddTicks(392));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 16, 15, 48, 136, DateTimeKind.Utc).AddTicks(398));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 16, 15, 48, 136, DateTimeKind.Utc).AddTicks(770));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 16, 15, 48, 136, DateTimeKind.Utc).AddTicks(775));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 16, 15, 48, 136, DateTimeKind.Utc).AddTicks(778));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 16, 15, 48, 136, DateTimeKind.Utc).AddTicks(782));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 16, 15, 48, 136, DateTimeKind.Utc).AddTicks(785));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 16, 15, 48, 136, DateTimeKind.Utc).AddTicks(789));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 16, 15, 48, 136, DateTimeKind.Utc).AddTicks(793));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 16, 15, 48, 136, DateTimeKind.Utc).AddTicks(796));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 16, 15, 48, 136, DateTimeKind.Utc).AddTicks(803));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 16, 15, 48, 136, DateTimeKind.Utc).AddTicks(807));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 16, 15, 48, 136, DateTimeKind.Utc).AddTicks(810));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 16, 15, 48, 136, DateTimeKind.Utc).AddTicks(813));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 16, 15, 48, 135, DateTimeKind.Utc).AddTicks(9789));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 16, 15, 48, 135, DateTimeKind.Utc).AddTicks(9797));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 16, 15, 48, 135, DateTimeKind.Utc).AddTicks(9803));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 16, 15, 48, 135, DateTimeKind.Utc).AddTicks(9810));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 16, 15, 48, 135, DateTimeKind.Utc).AddTicks(9816));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 16, 15, 48, 135, DateTimeKind.Utc).AddTicks(9822));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 16, 15, 48, 135, DateTimeKind.Utc).AddTicks(9829));
        }
    }
}
