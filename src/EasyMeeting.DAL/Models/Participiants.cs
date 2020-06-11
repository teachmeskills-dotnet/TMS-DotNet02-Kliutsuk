using EasyMeeting.Common.Interfaces;
using System.Collections.Generic;

namespace EasyMeeting.DAL.Models
{
    public class Participiants : IHasDbIdentity
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public Meetings Meetings { get; set; }
    }
}
