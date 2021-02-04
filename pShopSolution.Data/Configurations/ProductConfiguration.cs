using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pShopSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace pShopSolution.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<product>
    {
        public void Configure(EntityTypeBuilder<product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(z => z.Id);

            builder.Property(z => z.price).IsRequired();

            builder.Property(z => z.OriginalPrice).IsRequired();

            builder.Property(z => z.Stock).IsRequired().HasDefaultValue(0);

            builder.Property(z => z.ViewCount).IsRequired();

            

        }
    }
}
