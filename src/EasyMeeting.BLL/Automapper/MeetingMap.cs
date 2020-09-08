using EasyMeeting.DAL.Models;
using Meetings = EasyMeeting.BLL.Models.Meetings;
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
            CreateMap<Meetings, Meeting>();
            CreateMap<Meeting, Meetings>();
        }
    }
}
