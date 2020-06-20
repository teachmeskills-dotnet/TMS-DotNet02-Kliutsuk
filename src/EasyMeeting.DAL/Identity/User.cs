using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyMeeting.DAL.Identity
{
    public class User : IdentityUser
    {
        /// <summary>
        /// User password.
        /// </summary>
        public string Password { get; set; }
    }
}
