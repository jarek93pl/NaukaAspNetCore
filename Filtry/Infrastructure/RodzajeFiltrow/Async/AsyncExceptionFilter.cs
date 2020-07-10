using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filtry.Infrastructure.RodzajeFiltrow.Async
{
    public class AsyncExceptionFilterAttribute : Attribute, IAsyncExceptionFilter
    {

        public AsyncExceptionFilterAttribute()
        {

            System.Diagnostics.Debug.WriteLine("AsyncExceptionFilter:wejście do konstruktora");
        }
        public Task OnExceptionAsync(ExceptionContext context)
        {
            System.Diagnostics.Debug.WriteLine($"AsyncExceptionFilter:wyskoczył błąd {context.Exception.Message}");
            return Task.CompletedTask;
        }
    }
}
