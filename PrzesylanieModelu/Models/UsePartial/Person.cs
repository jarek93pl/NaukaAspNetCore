using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrzesylanieModelu.Models.UsePartial
{
    public class Person
    {
        public float Weight { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [BindProperty(Name = "")]
        public Eyes Eyes { get; set; }

        public Address AddressHome { get; set; }

        [BindNever]
        public Address AddressForCorrespondence { get; set; }

    }
}
