using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coolblue_assesment.Models;
using Microsoft.EntityFrameworkCore;

namespace coolblue_assesment.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<ProductType> ProductType => Set<ProductType>();
        public DbSet<Product> Product => Set<Product>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne<ProductType>(p => p.ProductType)
                .WithMany(p => p.Products);
        }
    }
}