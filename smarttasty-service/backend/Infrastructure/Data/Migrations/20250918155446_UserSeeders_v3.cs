using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserSeeders_v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 18, 15, 54, 45, 786, DateTimeKind.Utc).AddTicks(1494), new DateTime(2025, 9, 18, 15, 54, 45, 786, DateTimeKind.Utc).AddTicks(1493) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 18, 15, 54, 45, 786, DateTimeKind.Utc).AddTicks(1502), new DateTime(2025, 9, 18, 15, 54, 45, 786, DateTimeKind.Utc).AddTicks(1502) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 18, 15, 54, 45, 786, DateTimeKind.Utc).AddTicks(1504), new DateTime(2025, 9, 18, 15, 54, 45, 786, DateTimeKind.Utc).AddTicks(1504) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 18, 15, 54, 45, 786, DateTimeKind.Utc).AddTicks(1507), new DateTime(2025, 9, 18, 15, 54, 45, 786, DateTimeKind.Utc).AddTicks(1506) });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 54, 45, 786, DateTimeKind.Utc).AddTicks(1396));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 54, 45, 786, DateTimeKind.Utc).AddTicks(1399));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 54, 45, 786, DateTimeKind.Utc).AddTicks(1401));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 54, 45, 786, DateTimeKind.Utc).AddTicks(1404));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 54, 45, 786, DateTimeKind.Utc).AddTicks(1406));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 54, 45, 786, DateTimeKind.Utc).AddTicks(1408));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 54, 45, 786, DateTimeKind.Utc).AddTicks(1082));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 54, 45, 786, DateTimeKind.Utc).AddTicks(1086));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 54, 45, 786, DateTimeKind.Utc).AddTicks(1088));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 54, 45, 786, DateTimeKind.Utc).AddTicks(1091));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 54, 45, 786, DateTimeKind.Utc).AddTicks(1093));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 54, 45, 786, DateTimeKind.Utc).AddTicks(1095));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 54, 45, 786, DateTimeKind.Utc).AddTicks(1098));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "CreatedAt", "Email", "IsActive", "Phone", "Role", "UserName", "UserPassword" },
                values: new object[] { 8, "136 shipper Street", new DateTime(2025, 9, 18, 15, 54, 45, 786, DateTimeKind.Utc).AddTicks(1147), "test5@gmail.com", true, "0395022018", 3, "shipper", "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 18, 15, 25, 57, 692, DateTimeKind.Utc).AddTicks(9210), new DateTime(2025, 9, 18, 15, 25, 57, 692, DateTimeKind.Utc).AddTicks(9209) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 18, 15, 25, 57, 692, DateTimeKind.Utc).AddTicks(9218), new DateTime(2025, 9, 18, 15, 25, 57, 692, DateTimeKind.Utc).AddTicks(9218) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 18, 15, 25, 57, 692, DateTimeKind.Utc).AddTicks(9221), new DateTime(2025, 9, 18, 15, 25, 57, 692, DateTimeKind.Utc).AddTicks(9221) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 18, 15, 25, 57, 692, DateTimeKind.Utc).AddTicks(9224), new DateTime(2025, 9, 18, 15, 25, 57, 692, DateTimeKind.Utc).AddTicks(9224) });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 25, 57, 692, DateTimeKind.Utc).AddTicks(9120));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 25, 57, 692, DateTimeKind.Utc).AddTicks(9123));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 25, 57, 692, DateTimeKind.Utc).AddTicks(9126));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 25, 57, 692, DateTimeKind.Utc).AddTicks(9129));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 25, 57, 692, DateTimeKind.Utc).AddTicks(9132));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 25, 57, 692, DateTimeKind.Utc).AddTicks(9134));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 25, 57, 692, DateTimeKind.Utc).AddTicks(8848));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 25, 57, 692, DateTimeKind.Utc).AddTicks(8853));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 25, 57, 692, DateTimeKind.Utc).AddTicks(8856));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 25, 57, 692, DateTimeKind.Utc).AddTicks(8858));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 25, 57, 692, DateTimeKind.Utc).AddTicks(8896));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 25, 57, 692, DateTimeKind.Utc).AddTicks(8899));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 18, 15, 25, 57, 692, DateTimeKind.Utc).AddTicks(8901));
        }
    }
}
