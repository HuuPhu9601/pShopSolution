using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace pShopSolution.Data.EF
{
    public class PShopDbContextfactory : IDesignTimeDbContextFactory<pShopDBContext>
    {
        public pShopDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            var connectionString = configuration.GetConnectionString("pShopSolutionDatabase");

            var optionsBuilder = new DbContextOptionsBuilder<pShopDBContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new pShopDBContext(optionsBuilder.Options);
        }
    }
}
