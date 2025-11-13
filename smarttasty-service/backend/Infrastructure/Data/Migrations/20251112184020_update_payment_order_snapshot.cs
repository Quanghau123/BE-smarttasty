using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class update_payment_order_snapshot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrderSnapshotJson",
                table: "Payments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 12, 18, 40, 19, 725, DateTimeKind.Utc).AddTicks(7846), new DateTime(2025, 11, 12, 18, 40, 19, 725, DateTimeKind.Utc).AddTicks(7845) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 1, 12, 18, 40, 19, 725, DateTimeKind.Utc).AddTicks(7856), new DateTime(2025, 11, 12, 18, 40, 19, 725, DateTimeKind.Utc).AddTicks(7855) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 12, 18, 40, 19, 725, DateTimeKind.Utc).AddTicks(7859), new DateTime(2025, 11, 12, 18, 40, 19, 725, DateTimeKind.Utc).AddTicks(7858) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 2, 12, 18, 40, 19, 725, DateTimeKind.Utc).AddTicks(7861), new DateTime(2025, 11, 12, 18, 40, 19, 725, DateTimeKind.Utc).AddTicks(7861) });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 18, 40, 19, 725, DateTimeKind.Utc).AddTicks(7751));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 18, 40, 19, 725, DateTimeKind.Utc).AddTicks(7754));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 18, 40, 19, 725, DateTimeKind.Utc).AddTicks(7757));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 18, 40, 19, 725, DateTimeKind.Utc).AddTicks(7759));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 18, 40, 19, 725, DateTimeKind.Utc).AddTicks(7761));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 18, 40, 19, 725, DateTimeKind.Utc).AddTicks(7763));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 18, 40, 19, 725, DateTimeKind.Utc).AddTicks(7890));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 18, 40, 19, 725, DateTimeKind.Utc).AddTicks(7892));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 18, 40, 19, 725, DateTimeKind.Utc).AddTicks(7893));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 18, 40, 19, 725, DateTimeKind.Utc).AddTicks(7894));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 18, 40, 19, 725, DateTimeKind.Utc).AddTicks(7896));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 18, 40, 19, 725, DateTimeKind.Utc).AddTicks(7897));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 18, 40, 19, 725, DateTimeKind.Utc).AddTicks(7898));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 18, 40, 19, 725, DateTimeKind.Utc).AddTicks(7900));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 18, 40, 19, 725, DateTimeKind.Utc).AddTicks(7901));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 18, 40, 19, 725, DateTimeKind.Utc).AddTicks(7902));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 18, 40, 19, 725, DateTimeKind.Utc).AddTicks(7904));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 18, 40, 19, 725, DateTimeKind.Utc).AddTicks(7905));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 18, 40, 19, 725, DateTimeKind.Utc).AddTicks(7509));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 18, 40, 19, 725, DateTimeKind.Utc).AddTicks(7512));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 18, 40, 19, 725, DateTimeKind.Utc).AddTicks(7515));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 18, 40, 19, 725, DateTimeKind.Utc).AddTicks(7517));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 18, 40, 19, 725, DateTimeKind.Utc).AddTicks(7519));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 18, 40, 19, 725, DateTimeKind.Utc).AddTicks(7521));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 18, 40, 19, 725, DateTimeKind.Utc).AddTicks(7574));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderSnapshotJson",
                table: "Payments");

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 12, 4, 23, 21, 193, DateTimeKind.Utc).AddTicks(8954), new DateTime(2025, 11, 12, 4, 23, 21, 193, DateTimeKind.Utc).AddTicks(8952) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 1, 12, 4, 23, 21, 193, DateTimeKind.Utc).AddTicks(8965), new DateTime(2025, 11, 12, 4, 23, 21, 193, DateTimeKind.Utc).AddTicks(8965) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 12, 4, 23, 21, 193, DateTimeKind.Utc).AddTicks(8969), new DateTime(2025, 11, 12, 4, 23, 21, 193, DateTimeKind.Utc).AddTicks(8968) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 2, 12, 4, 23, 21, 193, DateTimeKind.Utc).AddTicks(9025), new DateTime(2025, 11, 12, 4, 23, 21, 193, DateTimeKind.Utc).AddTicks(9024) });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 4, 23, 21, 193, DateTimeKind.Utc).AddTicks(8816));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 4, 23, 21, 193, DateTimeKind.Utc).AddTicks(8822));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 4, 23, 21, 193, DateTimeKind.Utc).AddTicks(8825));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 4, 23, 21, 193, DateTimeKind.Utc).AddTicks(8829));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 4, 23, 21, 193, DateTimeKind.Utc).AddTicks(8832));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 4, 23, 21, 193, DateTimeKind.Utc).AddTicks(8836));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 4, 23, 21, 193, DateTimeKind.Utc).AddTicks(9077));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 4, 23, 21, 193, DateTimeKind.Utc).AddTicks(9080));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 4, 23, 21, 193, DateTimeKind.Utc).AddTicks(9082));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 4, 23, 21, 193, DateTimeKind.Utc).AddTicks(9084));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 4, 23, 21, 193, DateTimeKind.Utc).AddTicks(9086));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 4, 23, 21, 193, DateTimeKind.Utc).AddTicks(9089));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 4, 23, 21, 193, DateTimeKind.Utc).AddTicks(9090));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 4, 23, 21, 193, DateTimeKind.Utc).AddTicks(9092));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 4, 23, 21, 193, DateTimeKind.Utc).AddTicks(9094));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 4, 23, 21, 193, DateTimeKind.Utc).AddTicks(9096));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 4, 23, 21, 193, DateTimeKind.Utc).AddTicks(9098));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 4, 23, 21, 193, DateTimeKind.Utc).AddTicks(9100));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 4, 23, 21, 193, DateTimeKind.Utc).AddTicks(8544));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 4, 23, 21, 193, DateTimeKind.Utc).AddTicks(8549));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 4, 23, 21, 193, DateTimeKind.Utc).AddTicks(8553));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 4, 23, 21, 193, DateTimeKind.Utc).AddTicks(8556));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 4, 23, 21, 193, DateTimeKind.Utc).AddTicks(8559));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 4, 23, 21, 193, DateTimeKind.Utc).AddTicks(8563));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 4, 23, 21, 193, DateTimeKind.Utc).AddTicks(8566));
        }
    }
}
