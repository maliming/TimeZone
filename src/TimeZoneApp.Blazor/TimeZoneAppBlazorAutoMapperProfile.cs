using AutoMapper;
using TimeZoneApp.Meetings;

namespace TimeZoneApp.Blazor;

public class TimeZoneAppBlazorAutoMapperProfile : Profile
{
    public TimeZoneAppBlazorAutoMapperProfile()
    {
        CreateMap<MeetingDto, CreateUpdateMeetingDto>().ReverseMap();
    }
}
