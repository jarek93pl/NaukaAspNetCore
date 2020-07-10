using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Filtry.Controllers
{
    public class DaneWFiltrach : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
            //context.Canceled
            //context.ModelState.Count
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //context.HttpContext
            //context.RouteData
        }
    }
}
