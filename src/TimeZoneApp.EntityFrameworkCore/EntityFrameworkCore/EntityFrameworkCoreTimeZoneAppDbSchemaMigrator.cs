using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TimeZoneApp.Data;
using Volo.Abp.DependencyInjection;

namespace TimeZoneApp.EntityFrameworkCore;

public class EntityFrameworkCoreTimeZoneAppDbSchemaMigrator
    : ITimeZoneAppDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreTimeZoneAppDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the TimeZoneAppDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<TimeZoneAppDbContext>()
            .Database
            .MigrateAsync();
    }
}
