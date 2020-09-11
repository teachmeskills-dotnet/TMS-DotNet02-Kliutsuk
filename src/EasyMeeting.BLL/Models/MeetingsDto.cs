using System;

namespace EasyMeeting.BLL.Models
{
    public class MeetingsDto
    {
        /// <summary>
        /// ID Key.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Meetings start date.
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// Meetings end date.
        /// </summary>
        public DateTime End { get; set; }

        /// <summary>
        /// Meeting place.
        /// </summary>
        public string Place { get; set; }

        /// <summary>
        /// Write some notes.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Durations.
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Title of meeting.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Link for google calendar.
        /// </summary>
        public string Link { get; set; }
    }
}
