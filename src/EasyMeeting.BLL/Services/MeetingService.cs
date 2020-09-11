using AutoMapper;
using EasyMeeting.BLL.Models;
using EasyMeeting.Common.Interfaces;
using EasyMeeting.DAL.Models;
using System;
using System.Threading.Tasks;

namespace EasyMeeting.BLL.Services
{
    public class MeetingService
    {
        private readonly IRepository<Meeting> _db;
        private readonly IMapper _mapper;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="db"></param>
        /// <param name="mapper"></param>
        public MeetingService(IRepository<Meeting> db, IMapper mapper)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Add new meeting.
        /// </summary>
        /// <param name="meeting"></param>
        /// <returns></returns>
        public async Task AddMeetingAsync(MeetingsDto meetings, string userId)
        {
            var dataMeeting = _mapper.Map<Meeting>(meetings);
            dataMeeting.UserId = userId;
            await _db.AddAsync(dataMeeting);
            await _db.SaveChangesAsync();
        }
    }
}