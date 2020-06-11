using EasyMeeting.Common.Interfaces;
using System.Collections.Generic;

namespace EasyMeeting.DAL.Models
{
    public class Profiles : IHasDbIdentity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public int UserId { get; set; }
        public Users Users { get; set; }
    }
}
