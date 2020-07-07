using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PocoControler.Models;

namespace PocoControler.Controllers
{
    public class HomeController
    {
        private readonly ILogger<HomeController> _logger;

        [ControllerContext]
        public ControllerContext MyProperty { get; set; }
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return new JsonResult(new { id = MyProperty.HttpContext.Request.Path });
        }

    }
}
