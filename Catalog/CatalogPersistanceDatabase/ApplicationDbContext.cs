using CatalogDomain;
using CatalogPersistanceDatabase.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace CatalogPersistanceDatabase
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductStock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ProductConfiguration().Configure(modelBuilder.Entity<Product>());
            new ProductStockConfiguration().Configure(modelBuilder.Entity<ProductStock>());
        }
    }
}