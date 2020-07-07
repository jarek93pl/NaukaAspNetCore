using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sesja.Models;

namespace Sesja.Controllers
{
    public class SesjaController : Controller
    {
        private readonly ILogger<SesjaController> _logger;

        static readonly string CountRefreshKey = typeof(SesjaController).FullName ?? "" + nameof(CountRefresh);
        public int? CountRefresh
        {
            get => HttpContext.Session.GetInt32(CountRefreshKey);
            set => HttpContext.Session.SetInt32(CountRefreshKey, value ?? 0);
        }
        public SesjaController(ILogger<SesjaController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (CountRefresh == null)
            {
                CountRefresh = 0;
            }
            CountRefresh++;

            return View(CountRefresh);
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
