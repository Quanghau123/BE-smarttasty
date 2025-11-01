using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddStaffManagement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BusinessOwnerId",
                table: "Users",
                type: "integer",
                nullable: true);

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
                columns: new[] { "BusinessOwnerId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 11, 1, 18, 55, 47, 912, DateTimeKind.Utc).AddTicks(1060) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "BusinessOwnerId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 11, 1, 18, 55, 47, 912, DateTimeKind.Utc).AddTicks(1063) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "BusinessOwnerId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 11, 1, 18, 55, 47, 912, DateTimeKind.Utc).AddTicks(1066) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "BusinessOwnerId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 11, 1, 18, 55, 47, 912, DateTimeKind.Utc).AddTicks(1069) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "BusinessOwnerId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 11, 1, 18, 55, 47, 912, DateTimeKind.Utc).AddTicks(1071) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "BusinessOwnerId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 11, 1, 18, 55, 47, 912, DateTimeKind.Utc).AddTicks(1073) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "BusinessOwnerId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 11, 1, 18, 55, 47, 912, DateTimeKind.Utc).AddTicks(1133) });

            migrationBuilder.CreateIndex(
                name: "IX_Users_BusinessOwnerId",
                table: "Users",
                column: "BusinessOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_BusinessOwnerId",
                table: "Users",
                column: "BusinessOwnerId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_BusinessOwnerId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_BusinessOwnerId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BusinessOwnerId",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8308), new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8305) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 1, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8317), new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8317) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8320), new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8320) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8323), new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8322) });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8207));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8210));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8213));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8215));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8218));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8220));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8350));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8351));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8353));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8355));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8356));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8357));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8359));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8360));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8361));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8363));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8364));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8365));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(7955));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(7958));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(7960));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8007));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8010));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8012));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 12, 35, 13, 613, DateTimeKind.Utc).AddTicks(8014));
        }
    }
}
