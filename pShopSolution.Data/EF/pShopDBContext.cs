using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using pShopSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace pShopSolution.Data.EF
{
    public class pShopDBContext : DbContext
    {
        public pShopDBContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new CartConfiguration());

            //modelBuilder.ApplyConfiguration(new AppConfigConfiguration());
            //modelBuilder.ApplyConfiguration(new ProductConfiguration());
            //modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            //modelBuilder.ApplyConfiguration(new ProductInCategoryConfiguration());
            //modelBuilder.ApplyConfiguration(new OrderConfiguration());

            //modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            //modelBuilder.ApplyConfiguration(new CategoryTranslationConfiguration());
            //modelBuilder.ApplyConfiguration(new ContactConfiguration());
            //modelBuilder.ApplyConfiguration(new LanguageConfiguration());
            //modelBuilder.ApplyConfiguration(new ProductTranslationConfiguration());
            //modelBuilder.ApplyConfiguration(new PromotionConfiguration());
            //modelBuilder.ApplyConfiguration(new TransactionConfiguration());
        }

        public DbSet<product> Products { get; set; }
        public DbSet<category> Categories { get; set; }

        public DbSet<AppConfig> AppConfigs { get; set; }


        public DbSet<cart> Carts { get; set; }

        public DbSet<categoryTranslation> CategoryTranslations { get; set; }
        public DbSet<ProductInCategory> ProductInCategories { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<language> Languages { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ProductTranslation> ProductTranslations { get; set; }

        public DbSet<Promotion> Promotions { get; set; }


        public DbSet<Transaction> Transactions { get; set; }
    }
}
