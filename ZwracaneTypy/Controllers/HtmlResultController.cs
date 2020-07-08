using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ZwracaneTypy.Controllers
{
    public class HtmlResultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Status()
        {
            return new StatusCodeResult(11);
        }

        public IActionResult okMb()
        {
            return Ok();
        }
        public IActionResult BadRequestMb()
        {
            return BadRequest();
        }
        public IActionResult UnauthorizedMb()
        {
            return Unauthorized();
        }
        public IActionResult NotFoundMb()
        {
            return NotFound();
        }
        public IActionResult CreatedAtActionMb()
        {
            return CreatedAtAction(nameof(Index), new { id = 123 });
        }

    }
}