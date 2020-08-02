using AutoMapper;
using EasyMeeting.DAL;
using EasyMeeting.DAL.Models;
using EasyMeeting.WebApp.Models;
using EasyMeeting.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyMeeting.WebApp.Controllers
{
    /// <summary>
    /// Meeting controller.
    /// </summary>
    public class MeetingController : Controller
    {
        private readonly ILogger<Meeting> _loger;
        private readonly EasyMeetingDbContext _db;

        public MeetingController(EasyMeetingDbContext db, ILogger<Meeting> loger)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _loger = loger ?? throw new ArgumentNullException(nameof(loger));
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
                return View("~/Views/Event/Event.cshtml");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Event(EventViewModel model)
        {
            if(ModelState.IsValid)
            {
                var events = new Meeting
                {
                    Title = model.Title,
                    StartDate = model.Start,
                    EndDate = model.End,
                    Duration = model.Duration,
                    Note = model.Description,
                    Place = model.Address,
                    Link = model.Link
                };
                var participiants = new Participiant
                {
                    Email = model.Emails
                };

                await _db.Meetings.AddAsync(events);
                await _db.Participiants.AddAsync(participiants);
                await _db.SaveChangesAsync();

                return View("~/Views/Event/Event.cshtml");
            }

            return View(model);
        }
    }
}
