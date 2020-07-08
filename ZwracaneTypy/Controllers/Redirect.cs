using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZwracaneTypy.Controllers
{
    public class RedirectController : Controller
    {
        //redairecty działają
        public IActionResult Page()
        {
            return View();
        }
        public IActionResult RedirectToGoogle()
        {
            return Redirect("https://www.google.pl/");
        }

        public IActionResult LocalRedirect()
        {
            return LocalRedirect("~/Redirect/Page");
        }
        public IActionResult RedirectToActionResultMb()
        {
            return RedirectToAction("Page", "Redirect", new { id = "123" });
        }
    }
}
