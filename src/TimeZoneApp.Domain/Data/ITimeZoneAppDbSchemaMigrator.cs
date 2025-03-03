using System.Threading.Tasks;

namespace TimeZoneApp.Data;

public interface ITimeZoneAppDbSchemaMigrator
{
    Task MigrateAsync();
}
