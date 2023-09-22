using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomebreweryShoppingAssistaint.Migrations
{
    /// <inheritdoc />
    public partial class ChangedToProductLastCheckAndShopLastCheck : Migration
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
                newName: "ProductLastCheckID");

            migrationBuilder.RenameIndex(
                name: "IX_Shop_LastCheckID",
                table: "Shop",
                newName: "IX_Shop_ProductLastCheckID");

            migrationBuilder.AddColumn<int>(
                name: "ProductLastCheckID",
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
                name: "ProductLastCheck",
                columns: table => new
                {
                    ProductLastCheckID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    ShopID = table.Column<int>(type: "int", nullable: false),
                    LastCheckDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLastCheck", x => x.ProductLastCheckID);
                });

            migrationBuilder.CreateTable(
                name: "ShopLastCheck",
                columns: table => new
                {
                    ShopLastCheckID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopID = table.Column<int>(type: "int", nullable: false),
                    LastCheckDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopLastCheck", x => x.ShopLastCheckID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductLastCheckID",
                table: "Product",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductLastCheck_ProductLastCheckID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Shop_ProductLastCheck_ProductLastCheckID",
                table: "Shop");

            migrationBuilder.DropTable(
                name: "ProductLastCheck");

            migrationBuilder.DropTable(
                name: "ShopLastCheck");

            migrationBuilder.DropIndex(
                name: "IX_Product_ProductLastCheckID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductLastCheckID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductLink",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "ProductLastCheckID",
                table: "Shop",
                newName: "LastCheckID");

            migrationBuilder.RenameIndex(
                name: "IX_Shop_ProductLastCheckID",
                table: "Shop",
                newName: "IX_Shop_LastCheckID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Shop_LastCheck_LastCheckID",
                table: "Shop",
                column: "LastCheckID",
                principalTable: "LastCheck",
                principalColumn: "LastCheckID");
        }
    }
}
