using TimeZoneApp.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace TimeZoneApp.Web.Pages;

public abstract class TimeZoneAppPageModel : AbpPageModel
{
    protected TimeZoneAppPageModel()
    {
        LocalizationResourceType = typeof(TimeZoneAppResource);
    }
}
