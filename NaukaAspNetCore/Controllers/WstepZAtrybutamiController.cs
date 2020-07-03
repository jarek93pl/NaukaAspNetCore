using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NaukaAspNetCore.Models;

namespace NaukaAspNetCore.Controllers
{
    public class WstepZAtrybutamiController : Controller
    {
        private readonly ILogger<WstepZAtrybutamiController> _logger;

        public WstepZAtrybutamiController(ILogger<WstepZAtrybutamiController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public void Darek(Preson preson)
        {
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
