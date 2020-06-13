using System;
using System.Collections.Generic;
using EasyMeeting.Common.Interfaces;

namespace EasyMeeting.DAL.Models
{
    public class Meetings : IHasDbIdentity
    {
        /// <summary>
        /// ID Key.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Meetings date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Meeting place.
        /// </summary>
        public string Place { get; set; }

        /// <summary>
        /// Write some notes.
        /// </summary>
        public string Note { get; set; }
        
        public int UserId { get; set; }
        public List<Participiants> Participiants { get; set; }
    }
}
