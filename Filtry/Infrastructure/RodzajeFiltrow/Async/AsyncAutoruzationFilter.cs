using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filtry.Infrastructure.RodzajeFiltrow.Async
{
    public class AsyncAutoruzationFilterAttribute : Attribute, IAsyncAuthorizationFilter
    {

        public AsyncAutoruzationFilterAttribute()
        {
            System.Diagnostics.Debug.WriteLine("AsyncAutoruzationFilter:wejście do konstruktora");
        }
        public Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {

            System.Diagnostics.Debug.WriteLine("AsyncAutoruzationFilter:wejście do metody OnAuthorizationAsync");
            context.Result = new UnauthorizedResult();
            return Task.CompletedTask;
        }
    }
}
