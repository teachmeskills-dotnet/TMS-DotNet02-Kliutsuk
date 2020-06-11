using EasyMeeting.Common.Interfaces;
using System.Collections.Generic;

namespace EasyMeeting.DAL.Models
{
    public class Users : IHasDbIdentity
    {
        /// <summary>
        /// ID Key
        /// </summary>
        public int Id { get; set; }
        public string Identity { get; set; }

        /// <summary>
        /// Reference on Meetings
        /// </summary>
        public List<Meetings> Meetings { get; set; }
        /// <summary>
        /// Reference on Profiles
        /// </summary>
        public List<Profiles> Profiles { get; set; }
    }
}
