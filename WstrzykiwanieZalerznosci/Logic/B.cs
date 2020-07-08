using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WstrzykiwanieZalerznosci.Interface;
namespace WstrzykiwanieZalerznosci.Logic
{
    public class B : IB
    {
        Ia date;
        public B(Ia ia)
        {
            date = ia;
        }
        public Ia MyProperty { get => date; set => date = value; }
    }
}
