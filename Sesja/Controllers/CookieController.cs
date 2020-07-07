using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TrzymanieDanych.Controllers
{
    public class CookieController : Controller
    {
        static readonly string CookieKey = typeof(CookieController).FullName;
        public IActionResult Index()
        {
            Response.Cookies.Append(CookieKey, Request.Cookies[CookieKey] ?? "" + "Serwer");
            return View();
        }

    }
}