namespace TimeZoneApp.Permissions;

public static class TimeZoneAppPermissions
{
    public const string GroupName = "TimeZoneApp";

    public static class Meetings
    {
        public const string Default = GroupName + ".Meetings";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
}
