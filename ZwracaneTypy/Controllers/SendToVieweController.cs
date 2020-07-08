using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ZwracaneTypy.Controllers
{
    public class SendToVieweController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VievBag()
        {
            ViewBag.R = "dane";
            return View();
        }
    }
}