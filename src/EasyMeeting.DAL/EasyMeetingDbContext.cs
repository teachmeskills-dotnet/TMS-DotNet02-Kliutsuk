using EasyMeeting.DAL.Identity;
using EasyMeeting.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyMeeting.DAL
{
    public class EasyMeetingDbContext : IdentityDbContext<User>
    {
        public EasyMeetingDbContext(DbContextOptions<EasyMeetingDbContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Meetings> Meetings { get; set; }
        public DbSet<Profiles> Profiles { get; set; }
        public DbSet<Participiants> Participiants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EasyMeetingDataBase;Trusted_Connection=True;");
        }
    }
}
