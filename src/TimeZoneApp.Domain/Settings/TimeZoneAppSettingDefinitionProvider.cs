using Volo.Abp.Settings;

namespace TimeZoneApp.Settings;

public class TimeZoneAppSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(TimeZoneAppSettings.MySetting1));
    }
}
