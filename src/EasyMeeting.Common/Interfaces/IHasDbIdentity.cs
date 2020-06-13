using System;
using System.Collections.Generic;
using System.Text;

namespace EasyMeeting.Common.Interfaces
{
    public interface IHasDbIdentity
    {
        /// <summary>
        /// ID Key.
        /// </summary>
        public int Id { get; set; }
    }
}
