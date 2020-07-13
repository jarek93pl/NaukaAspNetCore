using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtrynutyFormularza.Models
{
    public class Person
    {
        [Display(Prompt = "twoje imie", Name = "Imie:")]
        public string FirstName { get; set; }

        [Display(Prompt = "twoje nazwisko", Name = "Nazwisko:")]
        public string LastName { get; set; }

        [Display(Prompt = "twój kolor oczu", Name = "Kolor:")]
        public string EyeColor { get; set; }

        [Display(Prompt = "twój waga", Name = "Wada:")]
        public decimal Waga { get; set; }
    }
}
