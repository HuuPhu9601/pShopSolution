using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pShopSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace pShopSolution.Data.Configurations
{
    public class LanguageConfiguration : IEntityTypeConfiguration<language>
    {
        public void Configure(EntityTypeBuilder<language> builder)
        {
            builder.ToTable("Languages");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().IsUnicode(false).HasMaxLength(5);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(20);
        }
    }
}
