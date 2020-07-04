using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Singlenton.Models;

namespace Singlenton.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        Singleton singleton;
        public HomeController(ILogger<HomeController> logger, Singleton singleton)
        {
            _logger = logger;
            this.singleton = singleton;
        }

        public IActionResult Index()
        {
            ViewBag.Number = singleton.Number;
            return View();
        }

        public IActionResult Privacy()
        {
            ViewBag.Number = singleton.Number;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            ViewBag.Number = singleton.Number;
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
