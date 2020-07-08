using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ZwracaneTypy.Models;

namespace ZwracaneTypy.Controllers
{
    public class HomeController : Controller
    {
        class CustomResult : IActionResult
        {
            public Task ExecuteResultAsync(ActionContext context)
            {
                return context.HttpContext.Response.WriteAsync("własna akcja");
            }
        }
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
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
        public IActionResult CustomResultMethod()
        {
            return new CustomResult();
        }
        public IActionResult Other() => new ViewResult() { ViewName = "Privacy" };
    }
}
