using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityZNetCore.Controllers
{
    [Authorize]
    public class UseAutroize : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public UseAutroize(RoleManager<IdentityRole> roleManager)
        {
            this._roleManager = roleManager;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Page2()
        {
            return View();
        }
        [Authorize(Roles = "WW")]
        public IActionResult PageFromRoleWW()
        {
            return View();
        }

        public async Task<IActionResult> GetRole([FromQuery] string nameRole)
        {
            if (await _roleManager.RoleExistsAsync(nameRole))
            {
                ViewBag.NameRole = nameRole;
                return View();
            }
            return NotFound();
        }

    }
}
