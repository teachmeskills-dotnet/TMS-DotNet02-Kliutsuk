using EasyMeeting.BLL.Models;
using EasyMeeting.DAL.Models;
using Profile = AutoMapper.Profile;

namespace EasyMeeting.BLL.Automapper
{
    /// <summary>
    /// Mapping for participiants.
    /// </summary>
    public class ParticipiantsMap : Profile
    {
        public ParticipiantsMap()
        {
            CreateMap<ParticipiantsDto, Participiant>();
            CreateMap<Participiant, ParticipiantsDto>();
        }
    }
}
