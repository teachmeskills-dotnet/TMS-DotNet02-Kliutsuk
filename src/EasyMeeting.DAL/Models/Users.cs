using EasyMeeting.Common.Interfaces;
using Microsoft.AspNetCore.Identity;
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
        /// User Identity.
        /// </summary>
        public string Inentity { get; set; }

        public List<Meetings> Meetings { get; set; }
        public List<Profiles> Profiles { get; set; }
    }
}
