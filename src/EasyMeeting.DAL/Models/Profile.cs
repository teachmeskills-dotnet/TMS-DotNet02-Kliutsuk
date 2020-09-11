using EasyMeeting.Common.Interfaces;

namespace EasyMeeting.DAL.Models
{
    public class Profile : IHasDbIdentity
    {
        /// <summary>
        /// ID Key.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Profile name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Profile phone.
        /// </summary>
        public string Phone { get; set; }

        public string UserId { get; set; }
    }
}
