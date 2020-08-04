using EasyMeeting.Common.Interfaces;
using EasyMeeting.DAL;
using EasyMeeting.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EasyMeeting.WebApp.Controllers
{
    public class ProfileController : Controller
    {
        private readonly EasyMeetingDbContext _db;
        private readonly IEmailService _emailService;

        public ProfileController(EasyMeetingDbContext db, IEmailService emailService)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
        }

        /// <summary>
        /// View profile form.
        /// </summary>
        /// <returns>View form</returns>
        [HttpGet]
        public IActionResult Profile()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View("~/Views/Profile/Profile.cshtml");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        /// <summary>
        /// Edit Profile.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(ProfileViewModel model)
        {
            var result = new DAL.Models.Profile
            {
                Name = model.UserName,
                Phone = model.UserPhone,
            };

            _db.Entry(result).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return View(model);
        }

        /// <summary>
        /// Send email.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SendEmail([FromBody] int id)
        {
            var meetings = await _db.Meetings.AsNoTracking().Include(p => p.Participiants).FirstOrDefaultAsync(p => p.Id == id);
            var participiants = meetings.Participiants.ToList();
            //var participiants = _db.Participiants.Find();
            //string[] emails = participiants.Split(',');
            //var x = emails.Length;

            //var link = _db.Meetings;
            //await _emailService.SendEmailAsync(emails[x],
            //                                   "Event for you",
            //                                   $"Click on the <a href='{link}'>link</a> and add event in your Google Calendar");

            return Ok();
        }
    }
}
