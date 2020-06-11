using System;
using System.Collections.Generic;
using EasyMeeting.Common.Interfaces;

namespace EasyMeeting.DAL.Models
{
    public class Meetings : IHasDbIdentity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Place { get; set; }
        public string Note { get; set; }
        
        public int UserId { get; set; }
        public List<Participiants> Participiants { get; set; }
    }
}
