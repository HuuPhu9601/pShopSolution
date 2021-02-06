using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pShopSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace pShopSolution.Data.Configurations
{
    public class ProductInCategoryConfiguration : IEntityTypeConfiguration<ProductInCategory>
    {
        public void Configure(EntityTypeBuilder<ProductInCategory> builder)
        {
            builder.HasKey(p => new { p.ProductId, p.CategoryId });

            builder.ToTable("ProductInCategory");

            builder.HasOne(p => p.Product).WithMany(h => h.ProductInCategories).HasForeignKey(y => y.ProductId);

            builder.HasOne(p => p.Category).WithMany(h => h.ProductInCategories).HasForeignKey(y => y.CategoryId);

        }
    }
}
