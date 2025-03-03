using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeZoneApp.Meetings;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Domain.Repositories;

namespace TimeZoneApp.Controllers;

public class HomeController : AbpController
{
    protected IRepository<Meeting, Guid> MeetingRepository { get; }

    public HomeController(IRepository<Meeting, Guid> meetingRepository)
    {
        MeetingRepository = meetingRepository;
    }

    public async Task<List<MeetingDto>> Index()
    {
        return ObjectMapper.Map<List<Meeting>, List<MeetingDto>>(await MeetingRepository.GetListAsync());
    }
}
