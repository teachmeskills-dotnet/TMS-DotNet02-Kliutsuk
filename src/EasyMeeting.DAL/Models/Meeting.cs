using System;
using System.Collections.Generic;
using EasyMeeting.Common.Interfaces;

namespace EasyMeeting.DAL.Models
{
    public class Meeting : IHasDbIdentity
    {
        /// <summary>
        /// ID Key.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Meetings start date.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Meetings end date.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Meeting place.
        /// </summary>
        public string Place { get; set; }

        /// <summary>
        /// Write some notes.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Email of participiants.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Title of meeting.
        /// </summary>
        public string Title { get; set; }


        public string UserId { get; set; }
        public ICollection<Participiant> Participiants { get; set; }
    }
}
