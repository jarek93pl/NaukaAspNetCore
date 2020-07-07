using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Areas.Areas.Con2Area.Controllers
{
    public class Default2Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}