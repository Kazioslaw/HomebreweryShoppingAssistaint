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

        public DbSet<Category> Category { get; set; } = default!;

        public DbSet<Product> Product { get; set; } = default!;

        public DbSet<Shop> Shop { get; set; } = default!;

        public DbSet<ProductCheckHistory> ProductCheckHistory { get; set; } = default!;

        public DbSet<ShopCheckHistory> ShopCheckHistory { get; set; } = default!;
    }
}
