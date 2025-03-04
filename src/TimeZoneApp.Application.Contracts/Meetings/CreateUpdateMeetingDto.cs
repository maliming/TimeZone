using System;

namespace TimeZoneApp.Meetings;

public class CreateUpdateMeetingDto
{
    public string Subject { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public DateTime ActualStartTime { get; set; }

    public DateTime? CanceledTime { get; set; }

    public DateTimeOffset ReminderTime { get; set; }

    public DateTimeOffset? FollowUpTime { get; set; }

    public string Description { get; set; }
}
