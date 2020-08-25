using AutoMapper;
using EasyMeeting.BLL.Models;
using EasyMeeting.Common.Interfaces;
using EasyMeeting.DAL.Models;
using System.Threading.Tasks;
using System;

namespace EasyMeeting.BLL.Services
{
    public class ParticipiantService
    {
        private readonly IRepository<Participiant> _db;
        private readonly IMapper _mapper;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="db"></param>
        /// <param name="mapper"></param>
        public ParticipiantService(IRepository<Participiant> db, IMapper mapper)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Add new participiant.
        /// </summary>
        /// <param name="participiant"></param>
        /// <returns></returns>
        public async Task AddParticipiantsAsync(Participiants participiant)
        {
            var dataParticipiant = _mapper.Map<Participiant>(participiant);
            await _db.AddAsync(dataParticipiant);
            await _db.SaveChangesAsync();
        }
    }
}