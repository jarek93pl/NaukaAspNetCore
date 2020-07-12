using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace komponentWidoku.Controllers
{
    public class PocoViewComponent
    {
        public string Invoke()
        {
            return "<p> tekst z PocoViewComponent, znaki spoecjalne nie przerobiły się na html</p>";
        }
    }
}
