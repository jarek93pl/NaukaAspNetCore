using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ValidacjaModelu.Models;

namespace ValidacjaModelu.Controllers
{
    public class JqueryWithAtributeController : Controller
    {
        public JqueryWithAtributeController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string Index(JqueryWithAtributeData data)
        {
            return "response";
        }
    }
}