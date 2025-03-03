using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Timing;

namespace TimeZoneApp.Meetings;

public class MeetingDataSeederContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Meeting, Guid> _bookRepository;
    private readonly IClock _clock;

    public MeetingDataSeederContributor(IRepository<Meeting, Guid> bookRepository, IClock clock)
    {
        _bookRepository = bookRepository;
        _clock = clock;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _bookRepository.GetCountAsync() <= 0)
        {
            await _bookRepository.InsertAsync(
                new Meeting
                {
                    Subject = "ABP Developer Guide",
                    StartTime = _clock.Normalize(DateTime.Parse("2025-03-01 09:00:00")),
                    EndTime = _clock.Normalize(DateTime.Parse("2025-03-01 10:00:00")),
                    ActualStartTime = _clock.Normalize(DateTime.Parse("2025-03-01 09:05:00")),
                    Description = "We will discuss the ABP developer guide."
                },
                autoSave: true
            );

            await _bookRepository.InsertAsync(
                new Meeting
                {
                    Subject = "ABP Training",
                    StartTime = _clock.Normalize(DateTime.Parse("2025-03-01 15:00:00")),
                    EndTime = _clock.Normalize(DateTime.Parse("2025-03-01 16:00:00")),
                    ActualStartTime = _clock.Normalize(DateTime.Parse("2025-03-01 15:05:00")),
                    CanceledTime = _clock.Normalize(DateTime.Parse("2025-03-01 14:30:00")),
                    Description = "ABP training for the new developers."
                },
                autoSave: true
            );
        }
    }
}
