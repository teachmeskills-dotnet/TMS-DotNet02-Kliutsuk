using EasyMeeting.DAL;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EasyMeeting.WebApp.Controllers
{
    /// <summary>
    /// Meeting controller.
    /// </summary>
    public class MeetingController : Controller
    {
        private readonly EasyMeetingDbContext _db;

        public MeetingController(EasyMeetingDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            if(User.Identity.IsAuthenticated)
            {
                return View("~/Views/Event/index.cshtml");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
    }
}
