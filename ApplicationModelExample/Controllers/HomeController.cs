using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ApplicationModelExample.Models;
using ApplicationModelExample.Logic;
using Microsoft.AspNetCore.Http;

namespace ApplicationModelExample.Controllers
{
    [AddControlerAtribute(SeconName = "D1")]
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

        [AddMethodAtribute(AddActionName = "Privacy")]
        [ActionName("D2")]
        public IActionResult Privacy()
        {
            return View(nameof(Privacy));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task MethodWorkInD1()
        {
            await HttpContext.Response.WriteAsync("result MethodWorkInD1");
        }
        [ForChrome()]
        [ActionName("MethodWorkInD1")]
        public async Task MethodWorkInD1ForChrome()
        {
            await HttpContext.Response.WriteAsync("result MethodWorkInD1");
        }
    }
}
