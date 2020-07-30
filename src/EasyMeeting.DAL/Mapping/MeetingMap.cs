using EasyMeeting.DAL.Models;
using AutoMapper;

namespace EasyMeeting.DAL.Mapping
{
    public class MeetingMap : Meeting
    {
        public MeetingMap()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Meeting, MeetingMap>()
                                                           .ForMember("Email", opt=> opt.MapFrom(c => c.Participiants)));
        }
    }
}
