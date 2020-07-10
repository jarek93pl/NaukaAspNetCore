using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Filtry.Controllers
{
    public class WbodowanyFilterController : Controller
    {
        [RequireHttpsAttribute]
        public IActionResult Index()
        {
            return View();
        }
    }
}