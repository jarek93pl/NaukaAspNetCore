using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrzesylanieModelu.Models.UsePartial
{
    public class Eyes
    {
        public static IEnumerable<string> GetColors()
        {
            yield return "Niebieski";
            yield return "Zielony";
            yield return "Brązowy";
            yield return "Czerwony";
            yield return "Po treningu ";
        }
        public string Color { get; set; }
    }
}
