using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AtrynutyFormularza.Models;
using System.Reflection.PortableExecutable;

namespace AtrynutyFormularza.Controllers
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
            ViewBag.EyeColor = new string[] { "niebieski", "zielony", "brązowy" };
            return View(new Person());
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public void Index(Person person)
        {
            RedirectToAction(nameof(Index));
        }


        public IActionResult Strona2()
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
    }
}
