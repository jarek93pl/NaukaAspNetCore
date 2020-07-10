using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filtry.Infrastructure.RodzajeFiltrow
{
    public class ResultFilterTAttribute : ResultFilterAttribute
    {
        public ResultFilterTAttribute()
        {
            System.Diagnostics.Debug.WriteLine("wejście do konstruktora");
        }
        public override Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            System.Diagnostics.Debug.WriteLine("ResultFilterTAttribute:ExecuteResultAsync");
            return Task.CompletedTask;
        }
    }
}
