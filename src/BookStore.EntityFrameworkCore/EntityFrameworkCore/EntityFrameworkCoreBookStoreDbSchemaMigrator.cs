using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BookStore.Data;
using Volo.Abp.DependencyInjection;
using OMSBlazor.EntityFrameworkCore;

namespace BookStore.EntityFrameworkCore;

public class EntityFrameworkCoreBookStoreDbSchemaMigrator
    : IBookStoreDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreBookStoreDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the BookStoreDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<NorthwindDbContext>()
            .Database
            .MigrateAsync();

        await _serviceProvider
            .GetRequiredService<BookStoreIdentityDbContext>()
            .Database
            .MigrateAsync();
    }
}
