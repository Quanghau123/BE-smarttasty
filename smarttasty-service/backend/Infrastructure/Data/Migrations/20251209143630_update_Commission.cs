using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backend.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class update_Commission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderCommission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    RestaurantId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    PaymentMethod = table.Column<int>(type: "integer", nullable: false),
                    FinalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    CommissionRate = table.Column<decimal>(type: "numeric", nullable: false),
                    CommissionAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderCommission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderCommission_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderCommission_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderCommission_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 1, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4078), new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4074) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 1, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4103), new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4101) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 2, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4113), new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4111) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 1, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4122), new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4120) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 3, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4130), new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4129) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 3, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4138), new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4137) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 2, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4146), new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4145) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 2, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4155), new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4153) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 3, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4162), new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4161) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 3, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4170), new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4168) });

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(5183));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(5189));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(5195));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(5199));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(5203));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(5208));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(5213));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(5217));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(5221));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(5226));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(5230));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(5234));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(5238));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(5243));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(5247));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(5251));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(5277));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(5282));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(5287));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(5292));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(5296));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(5301));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(5306));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(5310));

            migrationBuilder.UpdateData(
                table: "RecipeReviews",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(5315));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4910));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4919));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4926));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4933));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4939));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4946));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4953));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4958));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4965));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4972));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4979));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4984));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4990));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4997));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(5003));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(2676));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(2689));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(2700));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(2709));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(2718));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(2727));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(2735));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(2744));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(2752));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(2761));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(2769));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(2776));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(2785));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(2793));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(2823));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(2831));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(2838));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(2846));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(2855));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(2863));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4349));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4356));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4379));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4383));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4387));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4392));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4397));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4402));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4406));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4410));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4415));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4419));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4424));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4429));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4433));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4437));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4441));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4445));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4450));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4454));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4459));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4463));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4467));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4472));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4476));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4481));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4485));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4490));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4495));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4499));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4504));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4509));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4513));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4518));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4522));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4527));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4531));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4535));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4540));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4545));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4549));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4553));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4557));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4562));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4567));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4571));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4576));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4580));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4585));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(4589));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(1527));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(1541));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(1550));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(1560));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(1569));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(1578));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(1595));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(1604));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(1613));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(1622));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(1631));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(1641));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(1650));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(1683));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(1693));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(1703));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(1739));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(1748));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(1757));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(1765));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(1773));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(1781));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(1790));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(1798));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(1806));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(1815));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(1823));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(1832));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 9, 14, 36, 29, 132, DateTimeKind.Utc).AddTicks(1841));

            migrationBuilder.CreateIndex(
                name: "IX_OrderCommission_OrderId",
                table: "OrderCommission",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderCommission_RestaurantId",
                table: "OrderCommission",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderCommission_UserId",
                table: "OrderCommission",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderCommission");

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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(7767));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(7773));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(7779));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(7797));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(7803));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(7809));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(7815));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(7821));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(7827));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 3, 54, 53, 602, DateTimeKind.Utc).AddTicks(7833));
        }
    }
}
