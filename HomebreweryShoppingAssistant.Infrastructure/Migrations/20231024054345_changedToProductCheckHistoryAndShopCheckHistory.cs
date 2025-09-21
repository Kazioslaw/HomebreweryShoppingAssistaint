using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomebreweryShoppingAssistant.Migrations
{
    /// <inheritdoc />
    public partial class changedToProductCheckHistoryAndShopCheckHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shop_LastCheck_LastCheckID",
                table: "Shop");

            migrationBuilder.DropTable(
                name: "LastCheck");

            migrationBuilder.DropIndex(
                name: "IX_Shop_LastCheckID",
                table: "Shop");

            migrationBuilder.DropColumn(
                name: "LastCheckID",
                table: "Shop");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Category",
                newName: "CategoryID");

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

            migrationBuilder.CreateTable(
                name: "ProductCheckHistory",
                columns: table => new
                {
                    ProductCheckHistoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
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
                    CheckDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShopID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopCheckHistory", x => x.ShopCheckHistoryID);
                    table.ForeignKey(
                        name: "FK_ShopCheckHistory_Shop_ShopID",
                        column: x => x.ShopID,
                        principalTable: "Shop",
                        principalColumn: "ShopID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CompanyID",
                table: "Product",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductCheckHistoryID",
                table: "Product",
                column: "ProductCheckHistoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ShopCheckHistory_ShopID",
                table: "ShopCheckHistory",
                column: "ShopID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Company_CompanyID",
                table: "Product",
                column: "CompanyID",
                principalTable: "Company",
                principalColumn: "CompanyID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductCheckHistory_ProductCheckHistoryID",
                table: "Product",
                column: "ProductCheckHistoryID",
                principalTable: "ProductCheckHistory",
                principalColumn: "ProductCheckHistoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Company_CompanyID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductCheckHistory_ProductCheckHistoryID",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "ProductCheckHistory");

            migrationBuilder.DropTable(
                name: "ShopCheckHistory");

            migrationBuilder.DropIndex(
                name: "IX_Product_CompanyID",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_ProductCheckHistoryID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductCheckHistoryID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductLink",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Category",
                newName: "CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "LastCheckID",
                table: "Shop",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LastCheck",
                columns: table => new
                {
                    LastCheckID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastCheckDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    ShopID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LastCheck", x => x.LastCheckID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shop_LastCheckID",
                table: "Shop",
                column: "LastCheckID");

            migrationBuilder.AddForeignKey(
                name: "FK_Shop_LastCheck_LastCheckID",
                table: "Shop",
                column: "LastCheckID",
                principalTable: "LastCheck",
                principalColumn: "LastCheckID");
        }
    }
}
