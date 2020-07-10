using Filtry.Infrastructure.RodzajeFiltrow;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filtry.Controllers
{
    public class TypeFilterAtributeController : Controller
    {

        [TypeFilter(typeof(AsyncActionFilter))]
        [TypeFilter(typeof(AsyncActionFilter))]
        public IActionResult Index()
        {
            return View();
        }
    }
}
