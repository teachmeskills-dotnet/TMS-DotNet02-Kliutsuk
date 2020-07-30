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
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View("~/Views/Event/index.cshtml");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetEventAsync(EventViewModel model)
        {
            if(ModelState.IsValid)
            {
                var newEvent = new Meeting
                {
                    Title = model.Title,
                    StartDate = model.Start,
                    EndDate = model.End,
                    Note = model.Description,
                    Place = model.Address
                };
                var email = new Participiant
                {
                    Email = model.Emails
                };
                return Json(newEvent, email);
            }
            else
            {
                return RedirectToAction("index","Meeting");
            }
        }
    }
}
