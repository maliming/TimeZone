using TimeZoneApp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace TimeZoneApp.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class TimeZoneAppController : AbpControllerBase
{
    protected TimeZoneAppController()
    {
        LocalizationResource = typeof(TimeZoneAppResource);
    }
}
