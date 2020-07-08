using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WstrzykiwanieZalerznosci.Interface;
using WstrzykiwanieZalerznosci.Models;

namespace WstrzykiwanieZalerznosci.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        Ia a;
        IB b;
        IC c;
        public HomeController(ILogger<HomeController> logger, Ia a, IB b, IC c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            _logger = logger;
        }

        public IActionResult Index([FromServices] Ia a)
        {
            return View();
        }

        public IActionResult Privacy()
        {
            IC ob = (IC)HttpContext.RequestServices.GetService(typeof(IC));
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
