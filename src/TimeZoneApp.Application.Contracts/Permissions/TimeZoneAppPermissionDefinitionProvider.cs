using TimeZoneApp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace TimeZoneApp.Permissions;

public class TimeZoneAppPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(TimeZoneAppPermissions.GroupName);

        var booksPermission = myGroup.AddPermission(TimeZoneAppPermissions.Meetings.Default, L("Permission:Meetings"));
        booksPermission.AddChild(TimeZoneAppPermissions.Meetings.Create, L("Permission:Meetings.Create"));
        booksPermission.AddChild(TimeZoneAppPermissions.Meetings.Edit, L("Permission:Meetings.Edit"));
        booksPermission.AddChild(TimeZoneAppPermissions.Meetings.Delete, L("Permission:Meetings.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<TimeZoneAppResource>(name);
    }
}
