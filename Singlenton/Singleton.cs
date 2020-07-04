using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Singlenton
{
    public class Singleton
    {
        int numberOpen = 0;
        public int Number { get { return numberOpen++; } }
    }
}
