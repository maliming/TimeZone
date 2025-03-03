using System;
using System.Collections.Generic;
using System.Text;
using TimeZoneApp.Localization;
using Volo.Abp.Application.Services;

namespace TimeZoneApp;

/* Inherit your application services from this class.
 */
public abstract class TimeZoneAppAppService : ApplicationService
{
    protected TimeZoneAppAppService()
    {
        LocalizationResource = typeof(TimeZoneAppResource);
    }
}
