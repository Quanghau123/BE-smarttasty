using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedMoreBusinessUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ZaloPayPayments_PaymentId",
                table: "ZaloPayPayments");

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(8984), new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(8982) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9004), new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9003) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 1, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9013), new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9012) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9019), new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9018) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 2, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9025), new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9024) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 2, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9032), new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9031) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 1, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9038), new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9037) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 1, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9044), new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9043) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 2, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9050), new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9049) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 2, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9056), new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9055) });

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9687));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9692));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9696));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9700));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9703));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9707));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9711));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9714));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9717));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9721));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9724));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9727));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9730));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9734));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9737));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9740));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9743));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9746));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9749));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9753));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9756));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9759));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9762));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9765));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9768));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9528));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9534));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9538));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9543));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9547));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9551));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9556));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9561));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9565));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9569));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9574));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9578));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9582));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9586));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9590));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(8318));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(8329));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(8336));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(8342));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(8348));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(8354));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(8360));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(8366));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(8372));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(8378));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(8384));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(8390));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(8396));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(8402));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(8408));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(8414));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(8419));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(8426));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(8432));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(8438));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9159));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9164));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9168));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9172));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9176));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9180));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9185));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9188));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9191));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9195));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9198));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9201));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9205));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9208));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9214));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9218));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9221));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9225));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9228));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9231));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9234));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9238));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9241));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9244));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9248));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9251));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9254));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9257));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9261));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9264));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9267));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9271));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9274));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9278));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9281));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9284));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9301));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9304));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9308));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9311));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9315));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9318));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9321));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9325));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9328));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9332));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9335));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9338));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9342));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(9345));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(7624));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(7633));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(7639));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(7651));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(7657));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(7663));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(7669));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(7676));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(7682));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(7688));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(7694));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(7700));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(7706));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(7730));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(7736));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(7742));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(7749));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(7755));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(7761));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "BusinessOwnerId", "CreatedAt", "Email", "IsActive", "Phone", "Role", "UserName", "UserPassword" },
                values: new object[,]
                {
                    { 21, "21 Business Street", null, new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(7767), "business21@gmail.com", true, "0826100021", 1, "business21", "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86" },
                    { 22, "22 Business Street", null, new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(7773), "business22@gmail.com", true, "0826100022", 1, "business22", "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86" },
                    { 23, "23 Business Street", null, new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(7779), "business23@gmail.com", true, "0826100023", 1, "business23", "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86" },
                    { 24, "24 Business Street", null, new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(7797), "business24@gmail.com", true, "0826100024", 1, "business24", "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86" },
                    { 25, "25 Business Street", null, new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(7803), "business25@gmail.com", true, "0826100025", 1, "business25", "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86" },
                    { 26, "26 Business Street", null, new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(7809), "business26@gmail.com", true, "0826100026", 1, "business26", "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86" },
                    { 27, "27 Business Street", null, new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(7815), "business27@gmail.com", true, "0826100027", 1, "business27", "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86" },
                    { 28, "28 Business Street", null, new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(7821), "business28@gmail.com", true, "0826100028", 1, "business28", "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86" },
                    { 29, "29 Business Street", null, new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(7827), "business29@gmail.com", true, "0826100029", 1, "business29", "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86" },
                    { 30, "30 Business Street", null, new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(7833), "business30@gmail.com", true, "0826100030", 1, "business30", "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ZaloPayPayments_PaymentId",
                table: "ZaloPayPayments",
                column: "PaymentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ZaloPayPayments_PaymentId",
                table: "ZaloPayPayments");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 30);

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8878), new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8878) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8887), new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8887) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 1, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8890), new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8890) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8893), new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8892) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 2, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8895), new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8894) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 2, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8897), new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8897) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 1, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8899), new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8899) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 1, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8902), new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8901) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 2, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8904), new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8904) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 2, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8907), new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8907) });

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9137));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9139));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9141));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9142));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9143));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9145));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9147));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9148));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9150));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9151));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9152));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9154));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9155));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9157));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9158));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9159));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9161));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9162));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9164));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9165));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9166));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9168));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9169));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9171));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9172));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9070));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9072));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9074));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9076));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9078));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9079));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9081));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9083));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9085));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9087));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9089));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9091));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9092));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9094));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9096));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8619));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8622));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8625));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8627));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8630));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8632));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8635));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8637));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8646));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8648));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8651));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8653));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8655));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8658));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8660));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8663));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8665));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8667));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8670));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8672));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8949));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8951));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8953));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8954));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8956));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8957));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8959));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8960));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8962));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8963));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8965));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8966));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8967));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8969));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8971));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8973));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8974));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8975));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8977));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8978));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8979));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8981));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8982));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8983));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8985));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8986));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8988));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8990));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8991));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8992));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8994));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8995));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8996));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8998));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8999));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9000));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9002));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9003));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9004));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9006));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9008));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9010));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9011));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9012));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9014));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9015));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9016));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9018));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8356));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8359));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8362));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8365));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8378));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8380));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8383));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8386));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8388));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8391));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8393));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8396));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8399));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8401));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8404));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8406));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8409));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8411));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8414));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8416));

            migrationBuilder.CreateIndex(
                name: "IX_ZaloPayPayments_PaymentId",
                table: "ZaloPayPayments",
                column: "PaymentId",
                unique: true);
        }
    }
}
