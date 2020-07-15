using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrzesylanieModelu.Models.UsePartial;

namespace PrzesylanieModelu.Controllers
{
    public class UsePartialController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Men()
        {
            ViewBag.TypeEyes = PrzesylanieModelu.Models.UsePartial.Eyes.GetColors();
            return View();
        }
        [HttpPost]
        public IActionResult Men(Men men)// w klasie person jest opis
        {
            return View();
        }
        public IActionResult Eyes()
        {
            ViewBag.TypeEyes = PrzesylanieModelu.Models.UsePartial.Eyes.GetColors();
            return PartialView();
        }

        public IActionResult Person()
        {
            ViewBag.TypeEyes = PrzesylanieModelu.Models.UsePartial.Eyes.GetColors();
            return PartialView();
        }

    }
}