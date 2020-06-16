using EasyMeeting.Common.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace EasyMeeting.DAL.Models
{
    public class Users : IdentityUser, IHasDbIdentity 
    {
        /// <summary>
        /// ID Key.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// User password.
        /// </summary>
        public string Password { get; set; }

        public List<Meetings> Meetings { get; set; }
        public List<Profiles> Profiles { get; set; }
    }
}
