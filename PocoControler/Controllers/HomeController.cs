using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using PocoControler.Models;

namespace PocoControler.Controllers
{
    public class HomeController 
    {
        private readonly ILogger<HomeController> _logger;

        [ControllerContext]
        public ControllerContext ControllerContextA { get; set; }
        [ActionContext]
        public ActionContext ActionContextA { get; set; }
        [ViewContext]
        public ViewContext ViewContextA { get; set; }

        [ViewComponentContext]
        public ViewComponentContext ViewComponentContextA { get; set; }

        [ViewDataDictionary]
        public ViewDataDictionary ViewDataDictionaryA { get; set; }
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return new JsonResult(new {id = ControllerContextA.HttpContext.Request.Path });
        }

    }
}
