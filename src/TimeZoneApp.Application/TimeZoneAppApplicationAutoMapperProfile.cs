using AutoMapper;
using TimeZoneApp.Meetings;

namespace TimeZoneApp;

public class TimeZoneAppApplicationAutoMapperProfile : Profile
{
    public TimeZoneAppApplicationAutoMapperProfile()
    {
        CreateMap<Meeting, MeetingDto>().ReverseMap();
        CreateMap<CreateUpdateMeetingDto, Meeting>();
    }
}
