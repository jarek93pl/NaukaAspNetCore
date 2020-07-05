using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RoutingWConfig.Models;

namespace RoutingWConfig.Controllers
{
    [Route("Api2/{controller}/{action}/{id:int}/{idx:Weekdey}")]
    public class Home2Controller : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public Home2Controller(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Daria()
        {
            ViewBag.Id = RouteData.Values["id"];
            return View();
        }

        public IActionResult Darek()
        {
            return Json(new { id = RouteData.Values["id"], name = $"z api 2: {RouteData.Values["idx"]}" });
        }
    }
}
