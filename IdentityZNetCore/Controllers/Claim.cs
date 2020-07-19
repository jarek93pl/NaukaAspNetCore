using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IdentityZNetCore.Controllers
{
    public class Claim : Controller
    {
        public IActionResult ListClaim()
        {
            return View();
        }
    }
}
