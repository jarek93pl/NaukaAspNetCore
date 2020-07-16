using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ValidacjaModelu.Models;

namespace ValidacjaModelu.Controllers
{
    public class MVCCodeValidateModelController : Controller
    {
        private readonly ILogger<MVCCodeValidateModelController> _logger;

        public MVCCodeValidateModelController(ILogger<MVCCodeValidateModelController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(MVCCodeValidateModelData homeToValidate)
        {
            if (!ModelState.IsValid)
            {
                System.Diagnostics.Debug.WriteLine("model nie jest poprawny");
                if (ModelState.GetValidationState(nameof(MVCCodeValidateModelData.Value)) == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                {

                    System.Diagnostics.Debug.WriteLine("tekst nie jest uzupełniony");
                }
            }
            ModelState.AddModelError("", "błąd");
            return View();
        }
        public IActionResult TextVal(string text)
        {
            if (text.Contains("Ma"))
            {
                return Json(true);
            }
            else
            {
                return Json("text nie zawiera");
            }
        }

    }
}
