using EasyMeeting.DAL.Models;
using System.Collections.Generic;

namespace EasyMeeting.WebApp.ViewModels
{
    public class ProfileViewModel
    {
        /// <summary>
        /// Username.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// User meetings.
        /// </summary>
        public ICollection<Meeting> Meetings { get; set; }

        /// <summary>
        /// User Email.
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// User Phone
        /// </summary>
        public string UserPhone { get; set; }
    }
}
