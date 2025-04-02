using Volo.Abp.AspNetCore.Components.Web;
using Volo.Abp.BlazoriseUI;
using Volo.Abp.Modularity;
using Volo.Abp.Timing;

namespace TimeZoneApp.Blazor.Shared;

[DependsOn(
    typeof(TimeZoneAppApplicationContractsModule),
    typeof(AbpAspNetCoreComponentsWebModule),
    typeof(AbpBlazoriseUIModule),
    typeof(AbpTimingModule)
)]
public class TimeZoneAppBlazorSharedModule : AbpModule
{

}
