using EasyMeeting.Common.Interfaces;
using System.Collections.Generic;

namespace EasyMeeting.DAL.Models
{
    public class Profiles : IHasDbIdentity
    {
        /// <summary>
        /// ID Key.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Profile name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Profile phone.
        /// </summary>
        public string Phone { get; set; }

        public int UserId { get; set; }
        public Users Users { get; set; }
    }
}
