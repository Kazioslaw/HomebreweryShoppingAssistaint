using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomebreweryShoppingAssistant.Migrations
{
    /// <inheritdoc />
    public partial class AddedFermenters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Delivery_Shop_ShopID",
                table: "Delivery");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductCheckHistory_ProductCheckHistoryID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Shop_ShopID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopCheckHistory_Shop_ShopID",
                table: "ShopCheckHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShopCheckHistory",
                table: "ShopCheckHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shop",
                table: "Shop");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCheckHistory",
                table: "ProductCheckHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_CategoryID",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Delivery",
                table: "Delivery");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "ShopCheckHistory",
                newName: "ShopCheckHistories");

            migrationBuilder.RenameTable(
                name: "Shop",
                newName: "Shops");

            migrationBuilder.RenameTable(
                name: "ProductCheckHistory",
                newName: "ProductCheckHistories");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Delivery",
                newName: "Deliveries");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_ShopCheckHistory_ShopID",
                table: "ShopCheckHistories",
                newName: "IX_ShopCheckHistories_ShopID");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ShopID",
                table: "Products",
                newName: "IX_Products_ShopID");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ProductCheckHistoryID",
                table: "Products",
                newName: "IX_Products_ProductCheckHistoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Delivery_ShopID",
                table: "Deliveries",
                newName: "IX_Deliveries_ShopID");

            migrationBuilder.AddColumn<int>(
                name: "GeneralProductID",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShopCheckHistories",
                table: "ShopCheckHistories",
                column: "ShopCheckHistoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shops",
                table: "Shops",
                column: "ShopID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCheckHistories",
                table: "ProductCheckHistories",
                column: "ProductCheckHistoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Deliveries",
                table: "Deliveries",
                column: "DeliveryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "CategoryID");

            migrationBuilder.CreateTable(
                name: "Fermenters",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fermenters", x => x.Id);
                });

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
                        name: "FK_GeneralProduct_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_GeneralProductID",
                table: "Products",
                column: "GeneralProductID");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralProduct_CategoryID",
                table: "GeneralProduct",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Shops_ShopID",
                table: "Deliveries",
                column: "ShopID",
                principalTable: "Shops",
                principalColumn: "ShopID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_GeneralProduct_GeneralProductID",
                table: "Products",
                column: "GeneralProductID",
                principalTable: "GeneralProduct",
                principalColumn: "GeneralProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCheckHistories_ProductCheckHistoryID",
                table: "Products",
                column: "ProductCheckHistoryID",
                principalTable: "ProductCheckHistories",
                principalColumn: "ProductCheckHistoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Shops_ShopID",
                table: "Products",
                column: "ShopID",
                principalTable: "Shops",
                principalColumn: "ShopID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCheckHistories_Shops_ShopID",
                table: "ShopCheckHistories",
                column: "ShopID",
                principalTable: "Shops",
                principalColumn: "ShopID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Shops_ShopID",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_GeneralProduct_GeneralProductID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCheckHistories_ProductCheckHistoryID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Shops_ShopID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopCheckHistories_Shops_ShopID",
                table: "ShopCheckHistories");

            migrationBuilder.DropTable(
                name: "Fermenters");

            migrationBuilder.DropTable(
                name: "GeneralProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shops",
                table: "Shops");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShopCheckHistories",
                table: "ShopCheckHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_GeneralProductID",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCheckHistories",
                table: "ProductCheckHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Deliveries",
                table: "Deliveries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "GeneralProductID",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Shops",
                newName: "Shop");

            migrationBuilder.RenameTable(
                name: "ShopCheckHistories",
                newName: "ShopCheckHistory");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "ProductCheckHistories",
                newName: "ProductCheckHistory");

            migrationBuilder.RenameTable(
                name: "Deliveries",
                newName: "Delivery");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_ShopCheckHistories_ShopID",
                table: "ShopCheckHistory",
                newName: "IX_ShopCheckHistory_ShopID");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ShopID",
                table: "Product",
                newName: "IX_Product_ShopID");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductCheckHistoryID",
                table: "Product",
                newName: "IX_Product_ProductCheckHistoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Deliveries_ShopID",
                table: "Delivery",
                newName: "IX_Delivery_ShopID");

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shop",
                table: "Shop",
                column: "ShopID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShopCheckHistory",
                table: "ShopCheckHistory",
                column: "ShopCheckHistoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "ProductID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCheckHistory",
                table: "ProductCheckHistory",
                column: "ProductCheckHistoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Delivery",
                table: "Delivery",
                column: "DeliveryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryID",
                table: "Product",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Delivery_Shop_ShopID",
                table: "Delivery",
                column: "ShopID",
                principalTable: "Shop",
                principalColumn: "ShopID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryID",
                table: "Product",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductCheckHistory_ProductCheckHistoryID",
                table: "Product",
                column: "ProductCheckHistoryID",
                principalTable: "ProductCheckHistory",
                principalColumn: "ProductCheckHistoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Shop_ShopID",
                table: "Product",
                column: "ShopID",
                principalTable: "Shop",
                principalColumn: "ShopID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCheckHistory_Shop_ShopID",
                table: "ShopCheckHistory",
                column: "ShopID",
                principalTable: "Shop",
                principalColumn: "ShopID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
