using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomebreweryShoppingAssistant.Migrations
{
	/// <inheritdoc />
	public partial class InitialCreate : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "LastCheck",
				columns: table => new
				{
					LastCheckID = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					ProductID = table.Column<int>(type: "int", nullable: false),
					CategoryID = table.Column<int>(type: "int", nullable: false),
					ShopID = table.Column<int>(type: "int", nullable: false),
					CheckDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_LastCheck", x => x.LastCheckID);
				});

			migrationBuilder.CreateTable(
				name: "Category",
				columns: table => new
				{
					CategoryID = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					CategoryName = table.Column<int>(type: "int", nullable: false),
					LastCheckID = table.Column<int>(type: "int", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Category", x => x.CategoryID);
					table.ForeignKey(
						name: "FK_Category_LastCheck_LastCheckID",
						column: x => x.LastCheckID,
						principalTable: "LastCheck",
						principalColumn: "LastCheckID");
				});

			migrationBuilder.CreateTable(
				name: "Shop",
				columns: table => new
				{
					ShopID = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					ShopName = table.Column<int>(type: "int", nullable: false),
					ShopLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
					LastCheckID = table.Column<int>(type: "int", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Shop", x => x.ShopID);
					table.ForeignKey(
						name: "FK_Shop_LastCheck_LastCheckID",
						column: x => x.LastCheckID,
						principalTable: "LastCheck",
						principalColumn: "LastCheckID");
				});

			migrationBuilder.CreateTable(
				name: "Product",
				columns: table => new
				{
					ProductID = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
					ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
					ProductPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Product30DaysPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
					CategoryID = table.Column<int>(type: "int", nullable: false),
					ShopID = table.Column<int>(type: "int", nullable: false),
					LastCheckID = table.Column<int>(type: "int", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Product", x => x.ProductID);
					table.ForeignKey(
						name: "FK_Product_Category_CategoryID",
						column: x => x.CategoryID,
						principalTable: "Category",
						principalColumn: "CategoryID",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Product_LastCheck_LastCheckID",
						column: x => x.LastCheckID,
						principalTable: "LastCheck",
						principalColumn: "LastCheckID");
					table.ForeignKey(
						name: "FK_Product_Shop_ShopID",
						column: x => x.ShopID,
						principalTable: "Shop",
						principalColumn: "ShopID",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Category_LastCheckID",
				table: "Category",
				column: "LastCheckID");

			migrationBuilder.CreateIndex(
				name: "IX_Product_CategoryID",
				table: "Product",
				column: "CategoryID");

			migrationBuilder.CreateIndex(
				name: "IX_Product_LastCheckID",
				table: "Product",
				column: "LastCheckID");

			migrationBuilder.CreateIndex(
				name: "IX_Product_ShopID",
				table: "Product",
				column: "ShopID");

			migrationBuilder.CreateIndex(
				name: "IX_Shop_LastCheckID",
				table: "Shop",
				column: "LastCheckID");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Product");

			migrationBuilder.DropTable(
				name: "Category");

			migrationBuilder.DropTable(
				name: "Shop");

			migrationBuilder.DropTable(
				name: "LastCheck");
		}
	}
}
