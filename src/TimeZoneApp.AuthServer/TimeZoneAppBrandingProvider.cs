using Microsoft.Extensions.Localization;
using TimeZoneApp.Localization;
using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace TimeZoneApp;

[Dependency(ReplaceServices = true)]
public class TimeZoneAppBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<TimeZoneAppResource> _localizer;

    public TimeZoneAppBrandingProvider(IStringLocalizer<TimeZoneAppResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
