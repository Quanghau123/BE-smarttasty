using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class _2_RestaurantSeeder_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 1, 32, 662, DateTimeKind.Utc).AddTicks(559));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 1, 32, 662, DateTimeKind.Utc).AddTicks(562));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 1, 32, 662, DateTimeKind.Utc).AddTicks(565));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "CreatedAt", "Email", "IsActive", "Phone", "Role", "UserName", "UserPassword" },
                values: new object[,]
                {
                    { 4, "987 Business Street", new DateTime(2025, 9, 18, 15, 1, 32, 662, DateTimeKind.Utc).AddTicks(567), "test1@gmail.com", true, "0829949293", 1, "business", "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86" },
                    { 5, "654 User Street", new DateTime(2025, 9, 18, 15, 1, 32, 662, DateTimeKind.Utc).AddTicks(569), "test2@gmail.com", true, "0395992018", 2, "user", "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86" },
                    { 6, "321 Business Street", new DateTime(2025, 9, 18, 15, 1, 32, 662, DateTimeKind.Utc).AddTicks(572), "test3@gmail.com", true, "0826649293", 1, "business", "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86" },
                    { 7, "136 User Street", new DateTime(2025, 9, 18, 15, 1, 32, 662, DateTimeKind.Utc).AddTicks(574), "test4@gmail.com", true, "0395042018", 2, "user", "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 14, 49, 25, 83, DateTimeKind.Utc).AddTicks(161));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 14, 49, 25, 83, DateTimeKind.Utc).AddTicks(165));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 14, 49, 25, 83, DateTimeKind.Utc).AddTicks(168));
        }
    }
}
