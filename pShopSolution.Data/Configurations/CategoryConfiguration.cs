using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pShopSolution.Data.Entities;
using pShopSolution.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace pShopSolution.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<category>
    {
        public void Configure(EntityTypeBuilder<category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Status).HasDefaultValue(status.Active);
        }
    }
}
