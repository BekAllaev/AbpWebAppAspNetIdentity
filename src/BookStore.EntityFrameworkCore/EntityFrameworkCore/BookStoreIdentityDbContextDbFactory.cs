using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using OMSBlazor.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.EntityFrameworkCore
{
    public class BookStoreIdentityDbContextDbFactory : IDesignTimeDbContextFactory<BookStoreIdentityDbContext>
    {
        public BookStoreIdentityDbContext CreateDbContext(string[] args)
        {
            BookStoreEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<BookStoreIdentityDbContext>()
                .UseSqlite(configuration.GetConnectionString("AbpIdentity"));

            return new BookStoreIdentityDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../BookStore.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
