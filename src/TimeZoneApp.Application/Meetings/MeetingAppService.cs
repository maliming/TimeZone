using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TimeZoneApp.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace TimeZoneApp.Meetings;

[Authorize(TimeZoneAppPermissions.Meetings.Default)]
public class MeetingAppService : TimeZoneAppAppService, IMeetingAppService
{
    private readonly IRepository<Meeting, Guid> _repository;

    public MeetingAppService(IRepository<Meeting, Guid> repository)
    {
        _repository = repository;
    }

    public async Task<MeetingDto> GetAsync(Guid id)
    {
        var meeting = await _repository.GetAsync(id);
        return ObjectMapper.Map<Meeting, MeetingDto>(meeting);
    }

    public async Task<PagedResultDto<MeetingDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        var queryable = await _repository.GetQueryableAsync();
        var query = DynamicQueryableExtensions.Take(queryable
                .OrderBy(input.Sorting.IsNullOrWhiteSpace() ? "Subject" : input.Sorting)
                .Skip(input.SkipCount), input.MaxResultCount);

        var meetings = await AsyncExecuter.ToListAsync(query.As<IQueryable<Meeting>>());
        var totalCount = await AsyncExecuter.CountAsync(queryable);

        return new PagedResultDto<MeetingDto>(
            totalCount,
            ObjectMapper.Map<List<Meeting>, List<MeetingDto>>(meetings)
        );
    }

    [Authorize(TimeZoneAppPermissions.Meetings.Create)]
    public async Task<MeetingDto> CreateAsync(CreateUpdateMeetingDto input)
    {
        var meeting = ObjectMapper.Map<CreateUpdateMeetingDto, Meeting>(input);
        await _repository.InsertAsync(meeting);
        return ObjectMapper.Map<Meeting, MeetingDto>(meeting);
    }

    [Authorize(TimeZoneAppPermissions.Meetings.Edit)]
    public async Task<MeetingDto> UpdateAsync(Guid id, CreateUpdateMeetingDto input)
    {
        var meeting = await _repository.GetAsync(id);
        ObjectMapper.Map(input, meeting);
        await _repository.UpdateAsync(meeting);
        return ObjectMapper.Map<Meeting, MeetingDto>(meeting);
    }

    [Authorize(TimeZoneAppPermissions.Meetings.Delete)]
    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}
