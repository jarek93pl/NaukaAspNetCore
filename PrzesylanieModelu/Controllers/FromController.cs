using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PrzesylanieModelu.Controllers
{
    public class FromController : Controller
    {
        //https://localhost:5001/From/FromRoute/3
        public IActionResult FromRoute([FromRoute] int id)
        {
            ViewBag.Id = id;
            return View("Index");
        }
        //https://localhost:5001/From/FromQuery?id=23
        public IActionResult FromQuery([FromQuery] int id)
        {
            ViewBag.Id = id;
            return View("Index");
        }
        public IActionResult FromForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FromForm([FromForm] int id)
        {
            ViewBag.Id = id;
            return View("Index");
        }

        public IActionResult FromHeader()
        {
            return View();
        }
        [HttpPost]
        public int FromHeader([FromHeader] int id)
        {
            return id;
        }
        public IActionResult FromBody()
        {
            return View("FromHeader");
        }
        [HttpPost]
        public int FromBody([FromBody] int id)
        {
            return id;
        }
    }
}