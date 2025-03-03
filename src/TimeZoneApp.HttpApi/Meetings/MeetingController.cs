using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeZoneApp.Controllers;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace TimeZoneApp.Meetings;

[RemoteService]
[Route("api/meeting")]
public class MeetingController : TimeZoneAppController, IMeetingAppService
{
    private readonly IMeetingAppService _meetingAppService;

    public MeetingController(IMeetingAppService meetingAppService)
    {
        _meetingAppService = meetingAppService;
    }

    [HttpGet]
    [Route("{id}")]
    public Task<MeetingDto> GetAsync(Guid id)
    {
        return _meetingAppService.GetAsync(id);
    }

    [HttpGet]
    public Task<PagedResultDto<MeetingDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return _meetingAppService.GetListAsync(input);
    }

    [HttpPost]
    public Task<MeetingDto> CreateAsync(CreateUpdateMeetingDto input)
    {
        return _meetingAppService.CreateAsync(input);
    }

    [HttpPut]
    [Route("{id}")]
    public Task<MeetingDto> UpdateAsync(Guid id, CreateUpdateMeetingDto input)
    {
        return _meetingAppService.UpdateAsync(id, input);
    }

    [HttpDelete]
    [Route("{id}")]
    public Task DeleteAsync(Guid id)
    {
        return _meetingAppService.DeleteAsync(id);
    }
}
