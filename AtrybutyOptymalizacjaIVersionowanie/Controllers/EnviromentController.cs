using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AtrybutyOptymalizacjaIVersionowanie.Controllers
{
    public class EnviromentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}