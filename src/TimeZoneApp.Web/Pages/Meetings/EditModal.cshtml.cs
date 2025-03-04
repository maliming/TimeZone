using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeZoneApp.Meetings;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form.DatePicker;

namespace TimeZoneApp.Web.Pages.Meetings;

public class EditModalModel  : TimeZoneAppPageModel
{
    public class EditMeetingViewModel
    {
        public string Subject { get; set; }

        [BindProperty]
        [DateRangePicker("MyPicker",true)]
        [DatePickerOptions(nameof(DatePickerOptions))]
        public DateTime StartTime { get; set; }

        [BindProperty]
        [DateRangePicker("MyPicker",false)]
        [DatePickerOptions(nameof(DatePickerOptions))]
        public DateTime EndTime { get; set; }

        [DatePickerOptions(nameof(DatePickerOptions))]
        public DateTime ActualStartTime { get; set; }

        [DatePickerOptions(nameof(DatePickerOptions))]
        public DateTime? CanceledTime { get; set; }

        [DatePickerOptions(nameof(DatePickerOptions))]
        public DateTimeOffset ReminderTime { get; set; }

        [DatePickerOptions(nameof(DatePickerOptions))]
        public DateTimeOffset? FollowUpTime { get; set; }

        public string Description { get; set; }
    }

    public AbpDatePickerOptions DatePickerOptions { get; set; }

    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public EditMeetingViewModel Meeting { get; set; }

    private readonly IMeetingAppService _meetingAppServiceAppService;

    public EditModalModel(IMeetingAppService meetingAppServiceAppService)
    {
        _meetingAppServiceAppService = meetingAppServiceAppService;

        DatePickerOptions = new AbpDatePickerOptions
        {
            TimePicker = true,
            AutoApply = true
        };
    }

    public async Task OnGetAsync()
    {
        var meetingDto = await _meetingAppServiceAppService.GetAsync(Id);
        Meeting = ObjectMapper.Map<MeetingDto, EditMeetingViewModel>(meetingDto);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _meetingAppServiceAppService.UpdateAsync(Id, ObjectMapper.Map<EditMeetingViewModel, CreateUpdateMeetingDto>(Meeting));
        return NoContent();
    }
}
