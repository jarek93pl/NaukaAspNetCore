using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filtry.Infrastructure.RodzajeFiltrow
{
    public class AutoruzationFilterAttribute : Attribute, IAuthorizationFilter
    {

        public AutoruzationFilterAttribute()
        {

            System.Diagnostics.Debug.WriteLine("wejście do konstruktora");
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            System.Diagnostics.Debug.WriteLine("OnAuthorization");
        }
    }
}
