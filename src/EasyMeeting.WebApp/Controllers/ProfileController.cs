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
        public async Task<IActionResult> SendEmail([FromBody] int id, [FromBody] string link)
        {
            var meetings = await _db.Meetings.AsNoTracking().Include(p => p.Participiants).FirstOrDefaultAsync(p => p.Id == id);
            var participiants = meetings.Participiants.ToList();
            var googleLink = await _db.Meetings.AsNoTracking().FirstOrDefaultAsync(p=>p.Link == link);

            await _emailService.SendEmailAsync(participiants.ToString(),
                                               "Event for you",
                                               $"Click on the <a href='{googleLink}'>link</a> and add event in your Google Calendar\n" +
                                               $"\n" +
                                               $"\n" +
                                               $"If you have another questions, please, texted {User.Identity.Name}");

            return Ok();
        }
    }
}
