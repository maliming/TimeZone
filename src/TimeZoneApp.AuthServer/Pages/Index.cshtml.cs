using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeZoneApp.Meetings;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Domain.Repositories;

namespace TimeZoneApp.Pages;

public class IndexModel : AbpPageModel
{
    public List<Meeting>? Meetings { get; set; }

    protected IRepository<Meeting, Guid> MeetingRepository { get; }

    public IndexModel(IRepository<Meeting, Guid> meetingRepository)
    {
        MeetingRepository = meetingRepository;
    }

    public async Task OnGetAsync()
    {
        Meetings = await MeetingRepository.GetListAsync();
    }
}
