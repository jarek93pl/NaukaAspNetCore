using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;

namespace AtrybutyOptymalizacjaIVersionowanie.Controllers
{
    public class CecheController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Person(int id)
        {
            return View(id);
        }
    }
}