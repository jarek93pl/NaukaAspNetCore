using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filtry.Infrastructure.RodzajeFiltrow
{
    public class ActionFilterTAttribute : Attribute, IActionFilter
    {

        public ActionFilterTAttribute()
        {
            System.Diagnostics.Debug.WriteLine("ActionFilter:wejście do konstruktora");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            System.Diagnostics.Debug.WriteLine("ActionFilter:OnActionExecuted");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            System.Diagnostics.Debug.WriteLine("ActionFilter:OnActionExecuting");
        }
    }
}
