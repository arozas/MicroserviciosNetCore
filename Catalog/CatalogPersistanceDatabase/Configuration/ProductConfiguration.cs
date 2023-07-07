using CatalogDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogPersistanceDatabase.Configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> modelBuilder)
        {
            modelBuilder.HasKey(x => x.ProductId);
            modelBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Property(x => x.Description).IsRequired().HasMaxLength(500);
        }
    }
}
