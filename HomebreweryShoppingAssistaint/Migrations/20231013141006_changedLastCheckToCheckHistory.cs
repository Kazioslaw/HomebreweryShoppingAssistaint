using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomebreweryShoppingAssistaint.Migrations
{
    /// <inheritdoc />
    public partial class changedLastCheckToCheckHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductLastCheck_ProductLastCheckID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Shop_ProductLastCheck_ProductLastCheckID",
                table: "Shop");

            migrationBuilder.DropIndex(
                name: "IX_Shop_ProductLastCheckID",
                table: "Shop");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductLastCheck",
                table: "ProductLastCheck");

            migrationBuilder.DropColumn(
                name: "ProductLastCheckID",
                table: "Shop");

            migrationBuilder.DropColumn(
                name: "ProductLastCheckID",
                table: "ProductLastCheck");

            migrationBuilder.RenameColumn(
                name: "LastCheckDateTime",
                table: "ShopLastCheck",
                newName: "CheckDateTime");

            migrationBuilder.RenameColumn(
                name: "ShopLastCheckID",
                table: "ShopLastCheck",
                newName: "ShopCheckHistoryID");

            migrationBuilder.RenameColumn(
                name: "ShopID",
                table: "ProductLastCheck",
                newName: "ProductCheckHistoryID");

            migrationBuilder.RenameColumn(
                name: "LastCheckDateTime",
                table: "ProductLastCheck",
                newName: "CheckDateTime");

            migrationBuilder.RenameColumn(
                name: "ProductLastCheckID",
                table: "Product",
                newName: "ProductCheckHistoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ProductLastCheckID",
                table: "Product",
                newName: "IX_Product_ProductCheckHistoryID");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Category",
                newName: "CategoryID");

            migrationBuilder.AlterColumn<int>(
                name: "ProductCheckHistoryID",
                table: "ProductLastCheck",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CompanyID",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductLastCheck",
                table: "ProductLastCheck",
                column: "ProductCheckHistoryID");

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopLastCheck_ShopID",
                table: "ShopLastCheck",
                column: "ShopID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CompanyID",
                table: "Product",
                column: "CompanyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Company_CompanyID",
                table: "Product",
                column: "CompanyID",
                principalTable: "Company",
                principalColumn: "CompanyID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductLastCheck_ProductCheckHistoryID",
                table: "Product",
                column: "ProductCheckHistoryID",
                principalTable: "ProductLastCheck",
                principalColumn: "ProductCheckHistoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopLastCheck_Shop_ShopID",
                table: "ShopLastCheck",
                column: "ShopID",
                principalTable: "Shop",
                principalColumn: "ShopID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Company_CompanyID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductLastCheck_ProductCheckHistoryID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopLastCheck_Shop_ShopID",
                table: "ShopLastCheck");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropIndex(
                name: "IX_ShopLastCheck_ShopID",
                table: "ShopLastCheck");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductLastCheck",
                table: "ProductLastCheck");

            migrationBuilder.DropIndex(
                name: "IX_Product_CompanyID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "CheckDateTime",
                table: "ShopLastCheck",
                newName: "LastCheckDateTime");

            migrationBuilder.RenameColumn(
                name: "ShopCheckHistoryID",
                table: "ShopLastCheck",
                newName: "ShopLastCheckID");

            migrationBuilder.RenameColumn(
                name: "CheckDateTime",
                table: "ProductLastCheck",
                newName: "LastCheckDateTime");

            migrationBuilder.RenameColumn(
                name: "ProductCheckHistoryID",
                table: "ProductLastCheck",
                newName: "ShopID");

            migrationBuilder.RenameColumn(
                name: "ProductCheckHistoryID",
                table: "Product",
                newName: "ProductLastCheckID");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ProductCheckHistoryID",
                table: "Product",
                newName: "IX_Product_ProductLastCheckID");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Category",
                newName: "CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "ProductLastCheckID",
                table: "Shop",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShopID",
                table: "ProductLastCheck",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ProductLastCheckID",
                table: "ProductLastCheck",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductLastCheck",
                table: "ProductLastCheck",
                column: "ProductLastCheckID");

            migrationBuilder.CreateIndex(
                name: "IX_Shop_ProductLastCheckID",
                table: "Shop",
                column: "ProductLastCheckID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductLastCheck_ProductLastCheckID",
                table: "Product",
                column: "ProductLastCheckID",
                principalTable: "ProductLastCheck",
                principalColumn: "ProductLastCheckID");

            migrationBuilder.AddForeignKey(
                name: "FK_Shop_ProductLastCheck_ProductLastCheckID",
                table: "Shop",
                column: "ProductLastCheckID",
                principalTable: "ProductLastCheck",
                principalColumn: "ProductLastCheckID");
        }
    }
}
