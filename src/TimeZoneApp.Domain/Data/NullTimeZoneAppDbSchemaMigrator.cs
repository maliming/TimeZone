using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace TimeZoneApp.Data;

/* This is used if database provider does't define
 * ITimeZoneAppDbSchemaMigrator implementation.
 */
public class NullTimeZoneAppDbSchemaMigrator : ITimeZoneAppDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
