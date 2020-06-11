using EasyMeeting.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyMeeting.DAL
{
    public class EasyMeetingDbContext : DbContext
    {
        public EasyMeetingDbContext()
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
