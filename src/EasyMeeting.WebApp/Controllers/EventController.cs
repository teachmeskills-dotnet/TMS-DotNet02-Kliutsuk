using AutoMapper;
using EasyMeeting.BLL.Models;
using EasyMeeting.BLL.Services;
using EasyMeeting.DAL;
using EasyMeeting.DAL.Models;
using EasyMeeting.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace EasyMeeting.WebApp.Controllers
{
    /// <summary>
    /// Event controller.
    /// </summary>
    public class EventController : Controller
    {
        private readonly ILogger<Meeting> _loger;
        private readonly EasyMeetingDbContext _db;
        private readonly IMapper _mapper;
        private readonly MeetingService _meetingService;
        private readonly ParticipiantService _participiantService;

        public EventController(EasyMeetingDbContext db, ILogger<Meeting> loger, IMapper mapper, MeetingService meetingService, ParticipiantService participiantService)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _loger = loger ?? throw new ArgumentNullException(nameof(loger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _meetingService = meetingService ?? throw new ArgumentNullException(nameof(meetingService));
            _participiantService = participiantService ?? throw new ArgumentNullException(nameof(participiantService));
        }

        /// <summary>
        /// View form for registration event.
        /// </summary>
        /// <returns>View form</returns>
        [HttpGet]
        public IActionResult Event()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        /// <summary>
        /// Writes data in database.
        /// </summary>
        /// <param name="model">Event View Model</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Event(EventViewModel model)
        {
            if (ModelState.IsValid)
            {
                var meeting = _mapper.Map<Meetings>(model);
                var participiant = _mapper.Map<Participiants>(model);
                await _participiantService.AddParticipiantsAsync(participiant);
                await _meetingService.AddMeetingAsync(meeting);

                return Ok();
            }

            return View(model);
        }
    }
}
