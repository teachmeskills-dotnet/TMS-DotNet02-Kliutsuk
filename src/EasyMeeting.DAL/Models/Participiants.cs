using EasyMeeting.Common.Interfaces;
using System.Collections.Generic;

namespace EasyMeeting.DAL.Models
{
    public class Participiants : IHasDbIdentity
    {
        /// <summary>
        /// ID Key.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Email participants .
        /// </summary>
        public string Email { get; set; }

        public Meetings Meetings { get; set; }
    }
}
