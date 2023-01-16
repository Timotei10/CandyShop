using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CandyShop.Models;

namespace CandyShop.Data
{
    public class CandyShopContext : DbContext
    {
        public CandyShopContext (DbContextOptions<CandyShopContext> options)
            : base(options)
        {
        }

        public DbSet<CandyShop.Models.Product> Product { get; set; } = default!;

        public DbSet<CandyShop.Models.Origin> Origin { get; set; }

        public DbSet<CandyShop.Models.Category> Category { get; set; }
    }
}
