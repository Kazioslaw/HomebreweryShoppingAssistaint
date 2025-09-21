using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomebreweryShoppingAssistant.Migrations
{
    /// <inheritdoc />
    public partial class DeletedCategoryIDFromLastCheck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_LastCheck_LastCheckID",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_LastCheck_LastCheckID",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_LastCheckID",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Category_LastCheckID",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "LastCheckID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "LastCheck");

            migrationBuilder.DropColumn(
                name: "LastCheckID",
                table: "Category");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LastCheckID",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "LastCheck",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LastCheckID",
                table: "Category",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_LastCheckID",
                table: "Product",
                column: "LastCheckID");

            migrationBuilder.CreateIndex(
                name: "IX_Category_LastCheckID",
                table: "Category",
                column: "LastCheckID");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_LastCheck_LastCheckID",
                table: "Category",
                column: "LastCheckID",
                principalTable: "LastCheck",
                principalColumn: "LastCheckID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_LastCheck_LastCheckID",
                table: "Product",
                column: "LastCheckID",
                principalTable: "LastCheck",
                principalColumn: "LastCheckID");
        }
    }
}
