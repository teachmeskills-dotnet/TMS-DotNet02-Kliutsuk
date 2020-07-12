using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyMeeting.WebApp.Controllers
{
    /// <summary>
    /// Calendar controller.
    /// </summary>
    public class CalendarController : Controller
    {
        public CalendarController()
        {
        }

        /// <summary>
        /// Return calendar VIEW.
        /// </summary>
        /// <returns></returns>
        public IActionResult Calendar()
        {
            return View("~/Views/Calendar/Calendar.cshtml");
        }
    }
}
