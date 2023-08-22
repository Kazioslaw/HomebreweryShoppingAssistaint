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

        public DbSet<Category> Category { get; set; } = default!;

        public DbSet<Product> Product { get; set; } = default!;

        public DbSet<Shop> Shop { get; set; } = default!;

        public DbSet<HomebreweryShoppingAssistaint.Models.LastCheck> LastCheck { get; set; } = default!;

        //public DbSet<HomebreweryShoppingAssistaint.Models.LastCheck> LastCheck { get; set; } = default!;
    }
}
