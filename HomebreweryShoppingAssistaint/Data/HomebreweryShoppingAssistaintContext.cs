using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HomebreweryShoppingAssistaint.Models;

namespace HomebreweryShoppingAssistaint.Data
{
    public class HomebreweryShoppingAssistaintContext : DbContext
    {
        public HomebreweryShoppingAssistaintContext (DbContextOptions<HomebreweryShoppingAssistaintContext> options)
            : base(options)
        {
        }

        public DbSet<HomebreweryShoppingAssistaint.Models.Category> Category { get; set; } = default!;

        public DbSet<HomebreweryShoppingAssistaint.Models.Product> Product { get; set; } = default!;

        public DbSet<HomebreweryShoppingAssistaint.Models.Shop> Shop { get; set; } = default!;

        public DbSet<HomebreweryShoppingAssistaint.Models.ProductCheckHistory> ProductLastCheck { get; set; } = default!;

        public DbSet<HomebreweryShoppingAssistaint.Models.ShopCheckHistory> ShopLastCheck { get; set; } = default!;
    }
}
