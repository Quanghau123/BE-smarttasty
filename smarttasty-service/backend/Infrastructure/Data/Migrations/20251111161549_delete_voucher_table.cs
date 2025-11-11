using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backend.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class delete_voucher_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vouchers");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PromotionId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExpiredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsUsed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vouchers_Promotions_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "Promotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vouchers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.SetNull);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Vouchers_PromotionId",
                table: "Vouchers",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_Vouchers_UserId",
                table: "Vouchers",
                column: "UserId");
        }
    }
}
