using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomebreweryShoppingAssistant.Migrations
{
    /// <inheritdoc />
    public partial class ChangedToProductCheckHistoryAndShopCheckHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shop_LastCheck_LastCheckID",
                table: "Shop");

            migrationBuilder.DropTable(
                name: "LastCheck");

            migrationBuilder.RenameColumn(
                name: "LastCheckID",
                table: "Shop",
                newName: "ProductCheckHistoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Shop_LastCheckID",
                table: "Shop",
                newName: "IX_Shop_ProductCheckHistoryID");

            migrationBuilder.AddColumn<int>(
                name: "ProductCheckHistoryID",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductLink",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ProductCheckHistory",
                columns: table => new
                {
                    ProductCheckHistoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    ShopID = table.Column<int>(type: "int", nullable: false),
                    CheckDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCheckHistory", x => x.ProductCheckHistoryID);
                });

            migrationBuilder.CreateTable(
                name: "ShopCheckHistory",
                columns: table => new
                {
                    ShopCheckHistoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopID = table.Column<int>(type: "int", nullable: false),
                    CheckDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopCheckHistory", x => x.ShopCheckHistoryID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductCheckHistoryID",
                table: "Product",
                column: "ProductCheckHistoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductCheckHistory_ProductCheckHistoryID",
                table: "Product",
                column: "ProductCheckHistoryID",
                principalTable: "ProductCheckHistory",
                principalColumn: "ProductCheckHistoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Shop_ProductCheckHistory_ProductCheckHistoryID",
                table: "Shop",
                column: "ProductCheckHistoryID",
                principalTable: "ProductCheckHistory",
                principalColumn: "ProductCheckHistoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductCheckHistory_ProductCheckHistoryID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Shop_ProductCheckHistory_ProductCheckHistoryID",
                table: "Shop");

            migrationBuilder.DropTable(
                name: "ProductCheckHistory");

            migrationBuilder.DropTable(
                name: "ShopCheckHistory");

            migrationBuilder.DropIndex(
                name: "IX_Product_ProductCheckHistoryID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductCheckHistoryID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductLink",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "ProductCheckHistoryID",
                table: "Shop",
                newName: "LastCheckID");

            migrationBuilder.RenameIndex(
                name: "IX_Shop_ProductCheckHistoryID",
                table: "Shop",
                newName: "IX_Shop_LastCheckID");

            migrationBuilder.CreateTable(
                name: "LastCheck",
                columns: table => new
                {
                    LastCheckID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    ShopID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LastCheck", x => x.LastCheckID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Shop_LastCheck_LastCheckID",
                table: "Shop",
                column: "LastCheckID",
                principalTable: "LastCheck",
                principalColumn: "LastCheckID");
        }
    }
}
