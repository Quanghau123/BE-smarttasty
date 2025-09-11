using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatedishpromotion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DishPromotions",
                table: "DishPromotions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishPromotions",
                table: "DishPromotions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DishPromotions_DishId",
                table: "DishPromotions",
                column: "DishId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DishPromotions",
                table: "DishPromotions");

            migrationBuilder.DropIndex(
                name: "IX_DishPromotions_DishId",
                table: "DishPromotions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishPromotions",
                table: "DishPromotions",
                columns: new[] { "DishId", "PromotionId" });
        }
    }
}
