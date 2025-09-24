using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrderService_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_ShipperId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ShipperId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8);

            migrationBuilder.DropColumn(
                name: "ShipperId",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 19, 4, 47, 33, 667, DateTimeKind.Utc).AddTicks(484), new DateTime(2025, 9, 19, 4, 47, 33, 667, DateTimeKind.Utc).AddTicks(475) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 19, 4, 47, 33, 667, DateTimeKind.Utc).AddTicks(524), new DateTime(2025, 9, 19, 4, 47, 33, 667, DateTimeKind.Utc).AddTicks(512) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 19, 4, 47, 33, 667, DateTimeKind.Utc).AddTicks(533), new DateTime(2025, 9, 19, 4, 47, 33, 667, DateTimeKind.Utc).AddTicks(532) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 19, 4, 47, 33, 667, DateTimeKind.Utc).AddTicks(542), new DateTime(2025, 9, 19, 4, 47, 33, 667, DateTimeKind.Utc).AddTicks(540) });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 4, 47, 33, 657, DateTimeKind.Utc).AddTicks(3126));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 4, 47, 33, 657, DateTimeKind.Utc).AddTicks(3135));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 4, 47, 33, 657, DateTimeKind.Utc).AddTicks(3141));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 4, 47, 33, 657, DateTimeKind.Utc).AddTicks(3147));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 4, 47, 33, 657, DateTimeKind.Utc).AddTicks(3153));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 4, 47, 33, 657, DateTimeKind.Utc).AddTicks(3159));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 4, 47, 33, 657, DateTimeKind.Utc).AddTicks(2348));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 4, 47, 33, 657, DateTimeKind.Utc).AddTicks(2356));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 4, 47, 33, 657, DateTimeKind.Utc).AddTicks(2363));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 4, 47, 33, 657, DateTimeKind.Utc).AddTicks(2370));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 4, 47, 33, 657, DateTimeKind.Utc).AddTicks(2377));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 4, 47, 33, 657, DateTimeKind.Utc).AddTicks(2523));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 4, 47, 33, 657, DateTimeKind.Utc).AddTicks(2530));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShipperId",
                table: "Orders",
                type: "integer",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShipperId",
                table: "Orders",
                column: "ShipperId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_ShipperId",
                table: "Orders",
                column: "ShipperId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
