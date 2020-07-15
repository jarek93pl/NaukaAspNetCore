using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ValidacjaModelu
{
    public class MustByTrue : ValidationAttribute
    {
        public MustByTrue()
        {
            ErrorMessage = "te pole musi być uzupełnione";
        }
        public override bool IsValid(object value)
        {
            return (bool?)value == true;
        }
    }
}
