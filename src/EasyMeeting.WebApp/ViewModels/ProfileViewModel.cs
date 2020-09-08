using EasyMeeting.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
