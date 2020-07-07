using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InformacjeOKontrolerze.Models;
using Microsoft.AspNetCore.Mvc.Abstractions;

namespace InformacjeOKontrolerze.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Headers()
        {
            return Json(Request.Headers.Select(X => (X.Key.ToString() + ":" + X.Value.ToString())).ToList());
        }
    }
}
