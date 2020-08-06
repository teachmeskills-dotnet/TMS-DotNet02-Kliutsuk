using AutoMapper;
using EasyMeeting.BLL.Models;
using EasyMeeting.WebApp.ViewModels;

namespace EasyMeeting.WebApp.Automapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<EventViewModel, Meetings>().ReverseMap();
            CreateMap<EventViewModel, Participiants>().ReverseMap();
        }
    }
}
