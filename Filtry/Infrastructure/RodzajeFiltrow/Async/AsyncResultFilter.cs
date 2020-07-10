using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filtry.Infrastructure.RodzajeFiltrow
{
    public class AsyncResultFilterAttribute : Attribute, IAsyncResultFilter
    {

        public AsyncResultFilterAttribute()
        {
            System.Diagnostics.Debug.WriteLine("AsyncResultFilter:wejście do konstruktora");
        }
        public Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            System.Diagnostics.Debug.WriteLine("AsyncResultFilter:przed");
            next();
            System.Diagnostics.Debug.WriteLine("AsyncResultFilter:po");
            return Task.CompletedTask;
        }
    }
}
