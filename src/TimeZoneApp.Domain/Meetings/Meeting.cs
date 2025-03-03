using System;
using Volo.Abp.Domain.Entities;

namespace TimeZoneApp.Meetings;

public class Meeting : AggregateRoot<Guid>
{
    public string Subject { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public DateTime ActualStartTime { get; set; }

    public DateTime? CanceledTime { get; set; }

    public string Description { get; set; }
}
