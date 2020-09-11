using EasyMeeting.Common.Interfaces;

namespace EasyMeeting.DAL.Models
{
    public class Participiant : IHasDbIdentity
    {
        /// <summary>
        /// ID Key.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; set; }

        public Meeting Meeting { get; set; }
    }
}
