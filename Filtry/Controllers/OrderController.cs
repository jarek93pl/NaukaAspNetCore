using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filtry.Infrastructure.RodzajeFiltrow;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filtry.Controllers
{
    public class OrderController : Controller
    {
        [ResultFilterT(Order = 53)]
        public IActionResult Index()
        {
            return View();
        }
    }
}