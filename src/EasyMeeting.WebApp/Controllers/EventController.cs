using AutoMapper;
using EasyMeeting.BLL.Models;
using EasyMeeting.BLL.Services;
using EasyMeeting.Common.Interfaces;
using EasyMeeting.DAL;
using EasyMeeting.DAL.Models;
using EasyMeeting.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
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
        private readonly IEmailService _emailService;

        public EventController(EasyMeetingDbContext db, ILogger<Meeting> loger, IMapper mapper, MeetingService meetingService, ParticipiantService participiantService, IEmailService emailService)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _loger = loger ?? throw new ArgumentNullException(nameof(loger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _meetingService = meetingService ?? throw new ArgumentNullException(nameof(meetingService));
            _participiantService = participiantService ?? throw new ArgumentNullException(nameof(participiantService));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
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
        /// Add new event.
        /// </summary>
        /// <param name="model">Event View Model</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Event(EventViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Claims.FirstOrDefault(claim => claim.Type.Contains("nameidentifier")).Value;
                var meeting = _mapper.Map<Meetings>(model);
                var participiant = _mapper.Map<Participiants>(model);
                string[] emails = model.Emails.Split(", ");
                await _participiantService.AddParticipiantsAsync(participiant);
                await _meetingService.AddMeetingAsync(meeting, userId);

                foreach (var item in emails)
                {
                    await _emailService.SendEmailAsync(item,
                    "Event for you",
                    $"Click on the <a href='{model.Link}'>link</a> and add event in your Google Calendar\n\n\n" +
                    $"If you have another questions, please, texted {User.Identity.Name}"); ;
                }

                return View();
            }

            return View(model);
        }

        /// <summary>
        /// Send email.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SendEmail([FromBody] string link)
        {
            
            var meetings = await _db.Meetings.AsNoTracking().Include(p => p.Participiants).FirstOrDefaultAsync();
                //.FirstOrDefaultAsync(p => p.Id == id);
            var participiants = meetings.Participiants.Select(x=>x.Email).ToList();
            var googleLink = await _db.Meetings.AsNoTracking().FirstOrDefaultAsync(p => p.Link == link);
            //var emails = participiants.Select(p => p.Email).ToString();
            foreach (var item in participiants)
            {
                await _emailService.SendEmailAsync(item,
                                                   "Event for you",
                                                   $"Click on the <a href='{googleLink}'>link</a> and add event in your Google Calendar\n" +
                                                   $"\n" +
                                                   $"\n" +
                                                   $"If you have another questions, please, texted {User.Identity.Name}"); ;
            }
            return Ok();
        }
    }
}
