using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filtry.Infrastructure.RodzajeFiltrow
{
    public class ExceptionFilterTAttribute : Attribute, IExceptionFilter
    {

        public ExceptionFilterTAttribute()
        {
            System.Diagnostics.Debug.WriteLine("wejście do konstruktora");
        }
        public void OnException(ExceptionContext context)
        {
            System.Diagnostics.Debug.WriteLine("OnException");
        }
    }
}
