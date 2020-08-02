using System;
using System.ComponentModel.DataAnnotations;

namespace EasyMeeting.WebApp.ViewModels
{
    public class EventViewModel
    {
        /// <summary>
        /// Title event.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Start date event.
        /// </summary>
        [Required]
        public DateTime Start { get; set; }

        /// <summary>
        /// End date event.
        /// </summary>
        [Required]
        public DateTime End { get; set; }

        /// <summary>
        /// Duration event.
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Addres event.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Description for event.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Email for email service.
        /// </summary>
        [Required]
        public string Emails { get; set; }

        /// <summary>
        /// Link for google calendar.
        /// </summary>
        public string Link { get; set; }
    }
}
