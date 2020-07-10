using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filtry.Infrastructure.RodzajeFiltrow
{
    public class AsyncActionFilter : Attribute, IAsyncActionFilter//ActionFilterAttribute
    {

        public AsyncActionFilter()
        {
            System.Diagnostics.Debug.WriteLine("AsyncActionFilter:wejście do konstruktora");
        }
        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            
            System.Diagnostics.Debug.WriteLine("AsyncActionFilter:przed next");
            next();
            System.Diagnostics.Debug.WriteLine("AsyncActionFilter:po next");
            return Task.CompletedTask;
        }
    }
}
