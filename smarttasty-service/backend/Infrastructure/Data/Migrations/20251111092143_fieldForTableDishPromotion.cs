using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class fieldForTableDishPromotion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "AppliedPrice",
                table: "DishPromotions",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "OriginalPrice",
                table: "DishPromotions",
                type: "real",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 11, 9, 21, 43, 57, DateTimeKind.Utc).AddTicks(9404), new DateTime(2025, 11, 11, 9, 21, 43, 57, DateTimeKind.Utc).AddTicks(9403) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 1, 11, 9, 21, 43, 57, DateTimeKind.Utc).AddTicks(9413), new DateTime(2025, 11, 11, 9, 21, 43, 57, DateTimeKind.Utc).AddTicks(9412) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 11, 9, 21, 43, 57, DateTimeKind.Utc).AddTicks(9415), new DateTime(2025, 11, 11, 9, 21, 43, 57, DateTimeKind.Utc).AddTicks(9415) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 2, 11, 9, 21, 43, 57, DateTimeKind.Utc).AddTicks(9417), new DateTime(2025, 11, 11, 9, 21, 43, 57, DateTimeKind.Utc).AddTicks(9417) });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 9, 21, 43, 57, DateTimeKind.Utc).AddTicks(9306));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 9, 21, 43, 57, DateTimeKind.Utc).AddTicks(9312));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 9, 21, 43, 57, DateTimeKind.Utc).AddTicks(9315));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 9, 21, 43, 57, DateTimeKind.Utc).AddTicks(9318));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 9, 21, 43, 57, DateTimeKind.Utc).AddTicks(9320));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 9, 21, 43, 57, DateTimeKind.Utc).AddTicks(9322));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 9, 21, 43, 57, DateTimeKind.Utc).AddTicks(9444));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 9, 21, 43, 57, DateTimeKind.Utc).AddTicks(9445));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 9, 21, 43, 57, DateTimeKind.Utc).AddTicks(9447));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 9, 21, 43, 57, DateTimeKind.Utc).AddTicks(9448));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 9, 21, 43, 57, DateTimeKind.Utc).AddTicks(9449));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 9, 21, 43, 57, DateTimeKind.Utc).AddTicks(9451));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 9, 21, 43, 57, DateTimeKind.Utc).AddTicks(9452));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 9, 21, 43, 57, DateTimeKind.Utc).AddTicks(9453));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 9, 21, 43, 57, DateTimeKind.Utc).AddTicks(9454));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 9, 21, 43, 57, DateTimeKind.Utc).AddTicks(9492));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 9, 21, 43, 57, DateTimeKind.Utc).AddTicks(9494));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 9, 21, 43, 57, DateTimeKind.Utc).AddTicks(9495));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 9, 21, 43, 57, DateTimeKind.Utc).AddTicks(8768));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 9, 21, 43, 57, DateTimeKind.Utc).AddTicks(8868));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 9, 21, 43, 57, DateTimeKind.Utc).AddTicks(8871));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 9, 21, 43, 57, DateTimeKind.Utc).AddTicks(8874));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 9, 21, 43, 57, DateTimeKind.Utc).AddTicks(8876));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 9, 21, 43, 57, DateTimeKind.Utc).AddTicks(8879));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 9, 21, 43, 57, DateTimeKind.Utc).AddTicks(8881));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppliedPrice",
                table: "DishPromotions");

            migrationBuilder.DropColumn(
                name: "OriginalPrice",
                table: "DishPromotions");

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
    }
}
