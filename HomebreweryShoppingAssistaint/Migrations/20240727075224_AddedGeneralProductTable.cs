using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomebreweryShoppingAssistaint.Migrations
{
    /// <inheritdoc />
    public partial class AddedGeneralProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryID",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Product",
                newName: "GeneralProductID");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CategoryID",
                table: "Product",
                newName: "IX_Product_GeneralProductID");

            migrationBuilder.AddColumn<int>(
                name: "ProductHarvestYear",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GeneralProduct",
                columns: table => new
                {
                    GeneralProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralProduct", x => x.GeneralProductID);
                    table.ForeignKey(
                        name: "FK_GeneralProduct_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeneralProduct_CategoryID",
                table: "GeneralProduct",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_GeneralProduct_GeneralProductID",
                table: "Product",
                column: "GeneralProductID",
                principalTable: "GeneralProduct",
                principalColumn: "GeneralProductID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_GeneralProduct_GeneralProductID",
                table: "Product");

            migrationBuilder.DropTable(
                name: "GeneralProduct");

            migrationBuilder.DropColumn(
                name: "ProductHarvestYear",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "GeneralProductID",
                table: "Product",
                newName: "CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Product_GeneralProductID",
                table: "Product",
                newName: "IX_Product_CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryID",
                table: "Product",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
