using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HomebreweryShoppingAssistant.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "Shop",
                columns: new[] { "ShopID", "ShopLink", "ShopName" },
                values: new object[,]
                {
                    { 1, "https://alepiwo.pl", 1 },
                    { 2, "https://browamator.pl", 2 },
                    { 3, "https://www.browar.biz/centrumpiwowarstwa", 3 },
                    { 4, "https://homebrewing.pl/", 4 },
                    { 5, "https://twojbrowar.pl/pl/", 5 }
                });

            migrationBuilder.InsertData(
                table: "Delivery",
                columns: new[] { "DeliveryID", "DeliveryName", "DeliveryPrice", "DeliveryWeight", "ShopID" },
                values: new object[,]
                {
                    { 1, 5, 15.99m, 0.99m, 3 },
                    { 2, 5, 18.55m, 4.99m, 3 },
                    { 3, 5, 22.03m, 29.99m, 3 },
                    { 4, 5, 44.08m, 59.99m, 3 },
                    { 5, 5, 66.12m, 89.99m, 3 },
                    { 6, 5, 88.16m, 119.99m, 3 },
                    { 7, 5, 110.20m, 149.99m, 3 },
                    { 8, 5, 132.24m, 179.99m, 3 },
                    { 9, 5, 154.28m, 209.99m, 3 },
                    { 10, 5, 176.32m, 239.99m, 3 },
                    { 11, 6, 23.19m, 4.99m, 3 },
                    { 12, 6, 27.83m, 29.99m, 3 },
                    { 13, 6, 49.88m, 59.99m, 3 },
                    { 14, 6, 71.92m, 89.99m, 3 },
                    { 15, 6, 93.96m, 119.99m, 3 },
                    { 16, 6, 116.00m, 149.99m, 3 },
                    { 17, 6, 138.04m, 179.99m, 3 },
                    { 18, 6, 160.08m, 209.99m, 3 },
                    { 19, 6, 182.12m, 239.99m, 3 },
                    { 20, 3, 22.90m, 15m, 4 },
                    { 21, 3, 24.90m, 30m, 4 },
                    { 22, 3, 49.80m, 60m, 4 },
                    { 23, 3, 68.70m, 90m, 4 },
                    { 24, 3, 91.20m, 120m, 4 },
                    { 25, 3, 114.50m, 150m, 4 },
                    { 26, 3, 137.40m, 180m, 4 },
                    { 27, 1, 24.90m, 20m, 4 },
                    { 28, 2, 14.95m, 13m, 4 },
                    { 29, 1, 17.50m, 25m, 5 },
                    { 30, 3, 23.90m, 30m, 5 },
                    { 31, 4, 29.90m, 30m, 5 },
                    { 32, 5, 25.90m, 30m, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Delivery",
                keyColumn: "DeliveryID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Delivery",
                keyColumn: "DeliveryID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Delivery",
                keyColumn: "DeliveryID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Delivery",
                keyColumn: "DeliveryID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Delivery",
                keyColumn: "DeliveryID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Delivery",
                keyColumn: "DeliveryID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Delivery",
                keyColumn: "DeliveryID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Delivery",
                keyColumn: "DeliveryID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Delivery",
                keyColumn: "DeliveryID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Delivery",
                keyColumn: "DeliveryID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Delivery",
                keyColumn: "DeliveryID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Delivery",
                keyColumn: "DeliveryID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Delivery",
                keyColumn: "DeliveryID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Delivery",
                keyColumn: "DeliveryID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Delivery",
                keyColumn: "DeliveryID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Delivery",
                keyColumn: "DeliveryID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Delivery",
                keyColumn: "DeliveryID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Delivery",
                keyColumn: "DeliveryID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Delivery",
                keyColumn: "DeliveryID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Delivery",
                keyColumn: "DeliveryID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Delivery",
                keyColumn: "DeliveryID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Delivery",
                keyColumn: "DeliveryID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Delivery",
                keyColumn: "DeliveryID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Delivery",
                keyColumn: "DeliveryID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Delivery",
                keyColumn: "DeliveryID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Delivery",
                keyColumn: "DeliveryID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Delivery",
                keyColumn: "DeliveryID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Delivery",
                keyColumn: "DeliveryID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Delivery",
                keyColumn: "DeliveryID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Delivery",
                keyColumn: "DeliveryID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Delivery",
                keyColumn: "DeliveryID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Delivery",
                keyColumn: "DeliveryID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Shop",
                keyColumn: "ShopID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Shop",
                keyColumn: "ShopID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Shop",
                keyColumn: "ShopID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Shop",
                keyColumn: "ShopID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Shop",
                keyColumn: "ShopID",
                keyValue: 5);
        }
    }
}
