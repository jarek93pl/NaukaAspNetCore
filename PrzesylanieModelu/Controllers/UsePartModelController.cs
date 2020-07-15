using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrzesylanieModelu.Models.UsePartial;

namespace PrzesylanieModelu.Controllers
{
    public class UsePartModelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]//pobierane są tylko dane przekazane
        public IActionResult ShowAdress([Bind((nameof(Address.Streat)), Prefix = nameof(Person.AddressHome))] Address address)
        {
            return View();
        }
    }
}