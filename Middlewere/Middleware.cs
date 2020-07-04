using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Middlewere
{
    public class Middleware
    {
        RequestDelegate requestDelegate;
        public Middleware(RequestDelegate requestDelegate)
        {
            this.requestDelegate = requestDelegate;
        }
        public Task Invoke(HttpContext httpContext)
        {
            Console.WriteLine($"zapytanie weszło do {httpContext.Request.Path}");
            return requestDelegate(httpContext);
        }
    }
}
