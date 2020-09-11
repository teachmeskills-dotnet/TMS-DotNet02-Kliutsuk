using EasyMeeting.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyMeeting.DAL
{
    public class EasyMeetingDbContext : IdentityDbContext<User>
    {
        public EasyMeetingDbContext(DbContextOptions<EasyMeetingDbContext> options) : base(options)
        {
        }

        public DbSet<Meeting> Meetings { get; set; }

        public DbSet<Profile> Profiles { get; set; }

        public DbSet<Participiant> Participiants { get; set; }
    }
}
