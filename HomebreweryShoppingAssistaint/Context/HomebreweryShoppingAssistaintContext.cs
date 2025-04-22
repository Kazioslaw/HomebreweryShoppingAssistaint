using HomebreweryShoppingAssistaint.Models;
using Microsoft.EntityFrameworkCore;

namespace HomebreweryShoppingAssistaint.Data
{
    public class HomebreweryShoppingAssistaintContext : DbContext
    {
        public HomebreweryShoppingAssistaintContext(DbContextOptions<HomebreweryShoppingAssistaintContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } = default!;

        public DbSet<Product> Products { get; set; } = default!;

        public DbSet<Shop> Shops { get; set; } = default!;

        public DbSet<ProductCheckHistory> ProductCheckHistories { get; set; } = default!;

        public DbSet<ShopCheckHistory> ShopCheckHistories { get; set; } = default!;

        public DbSet<Delivery> Deliveries { get; set; }

        public DbSet<Fermenter> Fermenters { get; set; }

        //public DbSet<Company> Company { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shop>().HasData(new Shop { ShopID = (int)ShopNameEnum.AlePiwo, ShopName = ShopNameEnum.AlePiwo, ShopLink = "https://alepiwo.pl" },
                    new Shop { ShopID = (int)ShopNameEnum.Browamator, ShopName = ShopNameEnum.Browamator, ShopLink = "https://browamator.pl" },
                    new Shop { ShopID = (int)ShopNameEnum.CentrumPiwowarstwa, ShopName = ShopNameEnum.CentrumPiwowarstwa, ShopLink = "https://www.browar.biz/centrumpiwowarstwa" },
                    new Shop { ShopID = (int)ShopNameEnum.Homebrewing, ShopName = ShopNameEnum.Homebrewing, ShopLink = "https://homebrewing.pl/" },
                    new Shop { ShopID = (int)ShopNameEnum.TwojBrowar, ShopName = ShopNameEnum.TwojBrowar, ShopLink = "https://twojbrowar.pl/pl/" });

            modelBuilder.Entity<Category>().HasData(
                    new Category { CategoryID = (int)ProductCategory.Chmiel, CategoryName = ProductCategory.Chmiel },
                    new Category { CategoryID = (int)ProductCategory.Drożdże, CategoryName = ProductCategory.Drożdże },
                    new Category { CategoryID = (int)ProductCategory.Słód, CategoryName = ProductCategory.Słód },
                    new Category { CategoryID = (int)ProductCategory.Inne, CategoryName = ProductCategory.Inne });

            modelBuilder.Entity<Delivery>().HasData(// CentrumPiwowarstwa
                    new Delivery { DeliveryID = 1, DeliveryName = DeliverySupplier.DPD, DeliveryWeight = 0.99m, DeliveryPrice = 15.99m, ShopID = 3 },
                    new Delivery { DeliveryID = 2, DeliveryName = DeliverySupplier.DPD, DeliveryWeight = 4.99m, DeliveryPrice = 18.55m, ShopID = 3 },
                    new Delivery { DeliveryID = 3, DeliveryName = DeliverySupplier.DPD, DeliveryWeight = 29.99m, DeliveryPrice = 22.03m, ShopID = 3 },
                    new Delivery { DeliveryID = 4, DeliveryName = DeliverySupplier.DPD, DeliveryWeight = 59.99m, DeliveryPrice = 44.08m, ShopID = 3 },
                    new Delivery { DeliveryID = 5, DeliveryName = DeliverySupplier.DPD, DeliveryWeight = 89.99m, DeliveryPrice = 66.12m, ShopID = 3 },
                    new Delivery { DeliveryID = 6, DeliveryName = DeliverySupplier.DPD, DeliveryWeight = 119.99m, DeliveryPrice = 88.16m, ShopID = 3 },
                    new Delivery { DeliveryID = 7, DeliveryName = DeliverySupplier.DPD, DeliveryWeight = 149.99m, DeliveryPrice = 110.20m, ShopID = 3 },
                    new Delivery { DeliveryID = 8, DeliveryName = DeliverySupplier.DPD, DeliveryWeight = 179.99m, DeliveryPrice = 132.24m, ShopID = 3 },
                    new Delivery { DeliveryID = 9, DeliveryName = DeliverySupplier.DPD, DeliveryWeight = 209.99m, DeliveryPrice = 154.28m, ShopID = 3 },
                    new Delivery { DeliveryID = 10, DeliveryName = DeliverySupplier.DPD, DeliveryWeight = 239.99m, DeliveryPrice = 176.32m, ShopID = 3 },

                    new Delivery { DeliveryID = 11, DeliveryName = DeliverySupplier.DPD_Pobraniowa, DeliveryWeight = 4.99m, DeliveryPrice = 23.19m, ShopID = 3 },
                    new Delivery { DeliveryID = 12, DeliveryName = DeliverySupplier.DPD_Pobraniowa, DeliveryWeight = 29.99m, DeliveryPrice = 27.83m, ShopID = 3 },
                    new Delivery { DeliveryID = 13, DeliveryName = DeliverySupplier.DPD_Pobraniowa, DeliveryWeight = 59.99m, DeliveryPrice = 49.88m, ShopID = 3 },
                    new Delivery { DeliveryID = 14, DeliveryName = DeliverySupplier.DPD_Pobraniowa, DeliveryWeight = 89.99m, DeliveryPrice = 71.92m, ShopID = 3 },
                    new Delivery { DeliveryID = 15, DeliveryName = DeliverySupplier.DPD_Pobraniowa, DeliveryWeight = 119.99m, DeliveryPrice = 93.96m, ShopID = 3 },
                    new Delivery { DeliveryID = 16, DeliveryName = DeliverySupplier.DPD_Pobraniowa, DeliveryWeight = 149.99m, DeliveryPrice = 116.00m, ShopID = 3 },
                    new Delivery { DeliveryID = 17, DeliveryName = DeliverySupplier.DPD_Pobraniowa, DeliveryWeight = 179.99m, DeliveryPrice = 138.04m, ShopID = 3 },
                    new Delivery { DeliveryID = 18, DeliveryName = DeliverySupplier.DPD_Pobraniowa, DeliveryWeight = 209.99m, DeliveryPrice = 160.08m, ShopID = 3 },
                    new Delivery { DeliveryID = 19, DeliveryName = DeliverySupplier.DPD_Pobraniowa, DeliveryWeight = 239.99m, DeliveryPrice = 182.12m, ShopID = 3 },

                    // Homebrewing
                    new Delivery { DeliveryID = 20, DeliveryName = DeliverySupplier.GLS, DeliveryWeight = 15, DeliveryPrice = 22.90m, ShopID = 4 },
                    new Delivery { DeliveryID = 21, DeliveryName = DeliverySupplier.GLS, DeliveryWeight = 30, DeliveryPrice = 24.90m, ShopID = 4 },
                    new Delivery { DeliveryID = 22, DeliveryName = DeliverySupplier.GLS, DeliveryWeight = 60, DeliveryPrice = 49.80m, ShopID = 4 },
                    new Delivery { DeliveryID = 23, DeliveryName = DeliverySupplier.GLS, DeliveryWeight = 90, DeliveryPrice = 68.70m, ShopID = 4 },
                    new Delivery { DeliveryID = 24, DeliveryName = DeliverySupplier.GLS, DeliveryWeight = 120, DeliveryPrice = 91.20m, ShopID = 4 },
                    new Delivery { DeliveryID = 25, DeliveryName = DeliverySupplier.GLS, DeliveryWeight = 150, DeliveryPrice = 114.50m, ShopID = 4 },
                    new Delivery { DeliveryID = 26, DeliveryName = DeliverySupplier.GLS, DeliveryWeight = 180, DeliveryPrice = 137.40m, ShopID = 4 },

                    new Delivery { DeliveryID = 27, DeliveryName = DeliverySupplier.Inpost, DeliveryWeight = 20, DeliveryPrice = 24.90m, ShopID = 4 },
                    new Delivery { DeliveryID = 28, DeliveryName = DeliverySupplier.Inpost_Paczkomat, DeliveryWeight = 13, DeliveryPrice = 14.95m, ShopID = 4 },

                    // TwojBrowar
                    new Delivery { DeliveryID = 29, DeliveryName = DeliverySupplier.Inpost, DeliveryWeight = 25, DeliveryPrice = 17.50m, ShopID = 5 },
                    new Delivery { DeliveryID = 30, DeliveryName = DeliverySupplier.GLS, DeliveryWeight = 30, DeliveryPrice = 23.90m, ShopID = 5 },
                    new Delivery { DeliveryID = 31, DeliveryName = DeliverySupplier.GLS_Pobraniowa, DeliveryWeight = 30, DeliveryPrice = 29.90m, ShopID = 5 },
                    new Delivery { DeliveryID = 32, DeliveryName = DeliverySupplier.DPD, DeliveryWeight = 30, DeliveryPrice = 25.90m, ShopID = 5 });
        }
    }
}
