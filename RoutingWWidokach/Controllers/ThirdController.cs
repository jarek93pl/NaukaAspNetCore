using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RoutingWWidokach.Controllers
{
    public class ThirdController : Controller
    {
        public IActionResult Morek(string pom)
        {
            return Json(new { pom = pom });
        }
    }
}