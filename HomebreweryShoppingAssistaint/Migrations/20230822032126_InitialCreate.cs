using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomebreweryShoppingAssistaint.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LastCheckID",
                table: "Category",
                type: "int",
                nullable: true);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_LastCheck_LastCheckID",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Category_LastCheckID",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "LastCheckID",
                table: "Category");
        }
    }
}
