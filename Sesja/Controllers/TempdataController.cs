using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TrzymanieDanych.Controllers
{
    public class TempdataController : Controller
    {
        [TempData]
        public int MyProperty { get; set; }
        public IActionResult Index()
        {
            ViewBag.B = "12";
            MyProperty++;
            return RedirectToAction(nameof(Ania));
        }
        public IActionResult Ania()
        {
            return View();
        }
    }
}