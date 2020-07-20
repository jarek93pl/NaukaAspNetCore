using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationModelExample.Logic
{
    public class ForChromeAttribute : Attribute, IActionConstraint
    {
        public int Order => 0;

        public bool Accept(ActionConstraintContext context)
        {
            //context.Candidates
            return context.RouteContext.HttpContext.Request.Headers["User-Agent"].ToString().ToLower().Contains("chrome");
        }
    }
}
