using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pShopSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace pShopSolution.Data.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDeatails");

            builder.HasKey(x => new { x.OrderId, x.ProductId });

            builder.HasOne(p => p.Order).WithMany(y => y.OrderDetails).HasForeignKey(h => h.OrderId);

            builder.HasOne(p => p.Product).WithMany(y => y.OrderDetails).HasForeignKey(h => h.ProductId);
        }
    }
}
