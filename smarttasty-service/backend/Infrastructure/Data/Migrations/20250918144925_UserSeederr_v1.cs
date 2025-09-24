using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserSeederr_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "CreatedAt", "Email", "IsActive", "Phone", "Role", "UserName", "UserPassword" },
                values: new object[] { 3, "789 User Street", new DateTime(2025, 9, 18, 14, 49, 25, 83, DateTimeKind.Utc).AddTicks(168), "phatqq0@gmail.com", true, "0395042018", 2, "user", "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 14, 47, 26, 74, DateTimeKind.Utc).AddTicks(3118));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 14, 47, 26, 74, DateTimeKind.Utc).AddTicks(3127));
        }
    }
}
