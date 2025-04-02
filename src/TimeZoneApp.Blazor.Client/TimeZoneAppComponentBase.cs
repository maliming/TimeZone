using TimeZoneApp.Localization;
using Volo.Abp.AspNetCore.Components;

namespace TimeZoneApp.Blazor.Client;

public abstract class TimeZoneAppComponentBase : AbpComponentBase
{
    protected TimeZoneAppComponentBase()
    {
        LocalizationResource = typeof(TimeZoneAppResource);
    }
}
