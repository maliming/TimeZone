using System;
using System.Threading.Tasks;
using TimeZoneApp.Settings;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.SettingManagement;
using Volo.Abp.Timing;

namespace TimeZoneApp.Meetings;

public class MeetingDataSeederContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Meeting, Guid> _bookRepository;
    private readonly IClock _clock;
    private readonly ISettingManager _settingManager;

    public MeetingDataSeederContributor(IRepository<Meeting, Guid> bookRepository, IClock clock, ISettingManager settingManager)
    {
        _bookRepository = bookRepository;
        _clock = clock;
        _settingManager = settingManager;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        //await _settingManager.SetGlobalAsync(TimingSettingNames.TimeZone, "Europe/Istanbul");
        if (await _bookRepository.GetCountAsync() <= 0)
        {
            await _bookRepository.InsertAsync(
                new Meeting
                {
                    Subject = "ABP Developer Guide",
                    StartTime = _clock.Normalize(DateTime.Parse("2025-03-01 09:30:00")),
                    EndTime = _clock.Normalize(DateTime.Parse("2025-03-01 10:30:00")),
                    ActualStartTime = _clock.Normalize(DateTime.Parse("2025-03-01 11:30:00")),
                    ReminderTime = _clock.Normalize(DateTime.Parse("2025-03-01 12:30:00")),
                    FollowUpTime = _clock.Normalize(DateTime.Parse("2025-03-01 13:30:00")),
                    Description = "We will discuss the ABP developer guide."
                },
                autoSave: true
            );

            await _bookRepository.InsertAsync(
                new Meeting
                {
                    Subject = "ABP Training",
                    StartTime = _clock.Normalize(DateTime.Parse("2025-03-01 09:30:00")),
                    EndTime = _clock.Normalize(DateTime.Parse("2025-03-01 10:30:00")),
                    ActualStartTime = _clock.Normalize(DateTime.Parse("2025-03-01 11:30:00")),
                    CanceledTime = _clock.Normalize(DateTime.Parse("2025-03-01 12:00:00")),
                    ReminderTime = _clock.Normalize(DateTime.Parse("2025-03-01 12:30:00")),
                    FollowUpTime = _clock.Normalize(DateTime.Parse("2025-03-01 13:30:00")),
                    Description = "ABP training for the new developers."
                },
                autoSave: true
            );
        }
    }
}
