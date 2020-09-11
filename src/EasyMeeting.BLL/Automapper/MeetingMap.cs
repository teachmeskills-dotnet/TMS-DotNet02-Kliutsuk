using EasyMeeting.BLL.Models;
using EasyMeeting.DAL.Models;
using Profile = AutoMapper.Profile;

namespace EasyMeeting.BLL.Automapper
{
    /// <summary>
    /// Mapping for meeting.
    /// </summary>
    public class MeetingMap : Profile
    {
        public MeetingMap()
        {
            CreateMap<MeetingsDto, Meeting>();
            CreateMap<Meeting, MeetingsDto>();
        }
    }
}
