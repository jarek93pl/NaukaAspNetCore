using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ValidacjaModelu.Models
{
    public class MVCCodeValidateModelData
    {
        public int Value { get; set; }
        [Remote("TextVal","MVCCodeValidateModel")]
        public string Text { get; set; }
    }
}
