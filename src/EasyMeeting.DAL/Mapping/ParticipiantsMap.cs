using AutoMapper;
using EasyMeeting.DAL.Models;

namespace EasyMeeting.DAL.Mapping
{
    class ParticipiantsMap
    {
        public ParticipiantsMap()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Participiant, ParticipiantsMap>()
                                                           .ForMember("Email", opt => opt.MapFrom(c => c.Email)));
        }
    }
}
