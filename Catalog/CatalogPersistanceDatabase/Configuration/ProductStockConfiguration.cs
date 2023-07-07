using CatalogDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CatalogPersistanceDatabase.Configuration
{
    internal class ProductStockConfiguration : IEntityTypeConfiguration<ProductStock>
    {
        public void Configure(EntityTypeBuilder<ProductStock> modelBuilder)
        {
            modelBuilder.HasKey(x => x.ProductStockId);
            modelBuilder.Property(x => x.ProductId).IsRequired();
            modelBuilder.Property(x => x.Stock).IsRequired();
        }
    }
}
