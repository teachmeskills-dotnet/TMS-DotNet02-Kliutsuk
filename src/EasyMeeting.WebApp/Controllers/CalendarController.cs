﻿using EasyMeeting.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace EasyMeeting.WebApp.Controllers
{
    /// <summary>
    /// Calendar controller.
    /// </summary>
    public class CalendarController : Controller
    {
        private readonly EasyMeetingDbContext _db;

        public CalendarController(EasyMeetingDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        /// <summary>
        /// Return calendar VIEW.
        /// </summary>
        /// <returns></returns>
        public IActionResult Calendar()
        {
            return View();
        }

        /// <summary>
        /// JSON result
        /// </summary>
        /// <returns>events</returns>
        public IActionResult FindAllEvents()
        {
            var events = _db.Meetings.Select(e => new
            {
                id = e.Id,
                title = e.Title,
                startdate = e.Start.ToString("yyyy/MM/dd"),
                enddate = e.End.ToString("yyyy/MM/dd"),
                //email = e.Email,
                place = e.Place,
                note = e.Note
            }).ToList();
            return new JsonResult(events);
        }
    }
}
