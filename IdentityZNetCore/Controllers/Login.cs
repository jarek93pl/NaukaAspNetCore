using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IdentityZNetCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityZNetCore.Controllers
{
    public class Login : Controller
    {
        public SignInManager<AppUser> _usersMenager { get; set; }
        public Login(SignInManager<AppUser> _usersMenager)
        {
            this._usersMenager = _usersMenager;
        }
        public IActionResult IsLogin()
        {
            return View();
        }

        public async Task IsNotlogin()
        {
            await HttpContext.Response.WriteAsync("urzytkownik nie jest zalogowany");
        }
        public IActionResult LoginUser()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> LoginUser(LoginUser user)
        {
            await _usersMenager.SignOutAsync();
            var result = await this._usersMenager.PasswordSignInAsync(user.Login, user.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "zalogowanie odbyło się nie pomyślne");
            }
            else
            {
                var appUser = await _usersMenager.UserManager.FindByNameAsync(user.Login);
                var resultCreateUserPrincipalAsync = await _usersMenager.CreateUserPrincipalAsync(appUser);
            }
            return RedirectToAction(nameof(IsLogin));
        }
        public IActionResult FromRedairectAfterLogin()
        {
            return View();
        }
        public async Task<IActionResult> SingOut()
        {
            await _usersMenager.SignOutAsync();
            if (User?.Identity?.IsAuthenticated == true)
            {
                return RedirectToAction(nameof(SingOut));
            }
            else
            {
                return View();
            }
        }
    }
}
