using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IdentityZNetCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Authorization;

namespace IdentityZNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(Login.LoginUser), nameof(Login));
        }

        public IActionResult CreateUser()
        {
            return View();
        }
        public async Task<ActionResult> CreateRole([FromQuery] string role)
        {
            var resultRole = await _roleManager.CreateAsync(new IdentityRole(role));
            foreach (var item in resultRole.Errors)
            {
                ModelState.AddModelError(string.Empty, item.Description);
            }
            return View();
        }
        [Authorize]
        public async Task<IActionResult> AddRoleToUser([FromQuery] string role, [FromQuery] string UserName)
        {
            var userResult = await _userManager.FindByNameAsync(UserName);
            var operationResult = _userManager.AddToRoleAsync(userResult, role);
            foreach (var item in operationResult.Result.Errors)
            {
                ModelState.AddModelError(string.Empty, item.Code);
            }
            return View();
        }
        [Authorize]
        public async Task<IActionResult> RemoveRoleFromUser([FromQuery] string role)
        {
            await _roleManager.DeleteAsync(new IdentityRole(role));
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(AppUser usr)
        {
            var result = await _userManager.CreateAsync(usr, usr.PasswordHash);
            result.Errors.ToList().ForEach(x => ModelState.AddModelError(x.Code, x.Description));
            await _roleManager.CreateAsync(new IdentityRole("X"));
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
