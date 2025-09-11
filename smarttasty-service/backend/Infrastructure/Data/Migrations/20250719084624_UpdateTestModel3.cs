using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTestModel3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Tests");

            migrationBuilder.AddColumn<List<string>>(
                name: "Images",
                table: "Tests",
                type: "text[]",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Images",
                table: "Tests");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Tests",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
