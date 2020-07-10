using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filtry.Infrastructure.RodzajeFiltrow;
using Filtry.Infrastructure.RodzajeFiltrow.Async;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filtry.Controllers
{
    [ActionFilterT]
    [ResultFilterT]//użycie dwóch tych samych filtrów result się gryzie
    [AutoruzationFilter]
    [AsyncActionFilter]
    [AsyncResultFilter]
    [ExceptionFilterTAttribute]
    [AsyncExceptionFilter]
    public class TypeFilterController : Controller
    {
        public IActionResult Index()
        {
            System.Diagnostics.Debug.WriteLine("ciało metody <<<<<<<<<<<<<<<");
            return View();
        }

        public IActionResult Blad()
        {
            System.Diagnostics.Debug.WriteLine("ciało metody <<<<<<<<<<<<<<<");
            throw new NotImplementedException();
        }

        [AsyncAutoruzationFilter]
        public IActionResult NieAutoryzowane()
        {
            System.Diagnostics.Debug.WriteLine("ciało metody <<<<<<<<<<<<<<<");
            return Content("błąd");
        }
    }
}