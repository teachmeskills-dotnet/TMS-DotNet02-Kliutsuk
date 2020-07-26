using Microsoft.AspNetCore.Mvc;

namespace EasyMeeting.WebApp.Controllers
{
    /// <summary>
    /// Meeting controller.
    /// </summary>
    public class MeetingController : Controller
    {
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
