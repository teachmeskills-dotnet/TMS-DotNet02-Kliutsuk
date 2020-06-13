using EasyMeeting.Common.Interfaces;
using System.Collections.Generic;

namespace EasyMeeting.DAL.Models
{
    public class Users : IHasDbIdentity
    {
        /// <summary>
        /// ID Key.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identity.
        /// </summary>
        public string Identity { get; set; }

        public List<Meetings> Meetings { get; set; }
        public List<Profiles> Profiles { get; set; }
    }
}
