using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePromotionDateType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 11, 19, 35, 21, 285, DateTimeKind.Utc).AddTicks(4929), new DateTime(2025, 11, 11, 19, 35, 21, 285, DateTimeKind.Utc).AddTicks(4929) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 1, 11, 19, 35, 21, 285, DateTimeKind.Utc).AddTicks(4945), new DateTime(2025, 11, 11, 19, 35, 21, 285, DateTimeKind.Utc).AddTicks(4940) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 11, 19, 35, 21, 285, DateTimeKind.Utc).AddTicks(4948), new DateTime(2025, 11, 11, 19, 35, 21, 285, DateTimeKind.Utc).AddTicks(4947) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 2, 11, 19, 35, 21, 285, DateTimeKind.Utc).AddTicks(4951), new DateTime(2025, 11, 11, 19, 35, 21, 285, DateTimeKind.Utc).AddTicks(4950) });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 35, 21, 285, DateTimeKind.Utc).AddTicks(4736));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 35, 21, 285, DateTimeKind.Utc).AddTicks(4741));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 35, 21, 285, DateTimeKind.Utc).AddTicks(4745));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 35, 21, 285, DateTimeKind.Utc).AddTicks(4749));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 35, 21, 285, DateTimeKind.Utc).AddTicks(4752));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 35, 21, 285, DateTimeKind.Utc).AddTicks(4755));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 35, 21, 285, DateTimeKind.Utc).AddTicks(4992));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 35, 21, 285, DateTimeKind.Utc).AddTicks(4995));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 35, 21, 285, DateTimeKind.Utc).AddTicks(4996));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 35, 21, 285, DateTimeKind.Utc).AddTicks(4998));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 35, 21, 285, DateTimeKind.Utc).AddTicks(5000));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 35, 21, 285, DateTimeKind.Utc).AddTicks(5001));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 35, 21, 285, DateTimeKind.Utc).AddTicks(5003));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 35, 21, 285, DateTimeKind.Utc).AddTicks(5005));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 35, 21, 285, DateTimeKind.Utc).AddTicks(5006));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 35, 21, 285, DateTimeKind.Utc).AddTicks(5008));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 35, 21, 285, DateTimeKind.Utc).AddTicks(5009));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 35, 21, 285, DateTimeKind.Utc).AddTicks(5011));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 35, 21, 285, DateTimeKind.Utc).AddTicks(4307));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 35, 21, 285, DateTimeKind.Utc).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 35, 21, 285, DateTimeKind.Utc).AddTicks(4337));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 35, 21, 285, DateTimeKind.Utc).AddTicks(4341));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 35, 21, 285, DateTimeKind.Utc).AddTicks(4344));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 35, 21, 285, DateTimeKind.Utc).AddTicks(4348));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 19, 35, 21, 285, DateTimeKind.Utc).AddTicks(4351));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 11, 19, 8, 3, 342, DateTimeKind.Utc).AddTicks(4806), new DateTime(2025, 11, 11, 19, 8, 3, 342, DateTimeKind.Utc).AddTicks(4806) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 1, 11, 19, 8, 3, 342, DateTimeKind.Utc).AddTicks(4815), new DateTime(2025, 11, 11, 19, 8, 3, 342, DateTimeKind.Utc).AddTicks(4815) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 11, 19, 8, 3, 342, DateTimeKind.Utc).AddTicks(4818), new DateTime(2025, 11, 11, 19, 8, 3, 342, DateTimeKind.Utc).AddTicks(4818) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 2, 11, 19, 8, 3, 342, DateTimeKind.Utc).AddTicks(4820), new DateTime(2025, 11, 11, 19, 8, 3, 342, DateTimeKind.Utc).AddTicks(4820) });

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
    }
}
