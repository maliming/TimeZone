using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeZoneApp.Meetings;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form.DatePicker;
using Volo.Abp.Timing;

namespace TimeZoneApp.Web.Pages.Meetings
{
    public class CreateModalModel : TimeZoneAppPageModel
    {
        public class CreateMeetingViewModel
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

        [BindProperty]
        public CreateMeetingViewModel Meeting { get; set; }

        private readonly IMeetingAppService _meetingAppServiceAppService;

        public CreateModalModel(IMeetingAppService meetingAppServiceAppService)
        {
            _meetingAppServiceAppService = meetingAppServiceAppService;

            DatePickerOptions = new AbpDatePickerOptions
            {
                TimePicker = true,
                AutoApply = true
            };
        }

        public void OnGet()
        {
            Meeting = new CreateMeetingViewModel
            {
                StartTime = DateTime.Now.Date.AddHours(10),
                EndTime = DateTime.Now.Date.AddDays(7).AddHours(10)
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _meetingAppServiceAppService.CreateAsync(ObjectMapper.Map<CreateMeetingViewModel, CreateUpdateMeetingDto>(Meeting));
            return NoContent();
        }
    }
}
