using AutoMapper;
using TimeZoneApp.Meetings;
using TimeZoneApp.Web.Pages.Meetings;

namespace TimeZoneApp.Web;

public class TimeZoneAppWebAutoMapperProfile : Profile
{
    public TimeZoneAppWebAutoMapperProfile()
    {
        CreateMap<MeetingDto, EditModalModel.EditMeetingViewModel>();
        CreateMap<CreateModalModel.CreateMeetingViewModel, CreateUpdateMeetingDto>();
        CreateMap<EditModalModel.EditMeetingViewModel, CreateUpdateMeetingDto>();
    }
}
