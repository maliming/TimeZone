using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace TimeZoneApp.Meetings;

public interface IMeetingAppService : ICrudAppService<MeetingDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateMeetingDto>
{

}
