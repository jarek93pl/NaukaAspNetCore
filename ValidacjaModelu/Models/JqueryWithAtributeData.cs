using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ValidacjaModelu.Models
{
    public class JqueryWithAtributeData
    {
        [MustByTrue]
        public bool Agrement { get; set; }
        
        [Required]
        [StringLength(2)]
        [MaxLength(20)]
        [Compare(nameof(RepitEmail))]
        [RegularExpression("^[a-z]*@[a-z]*$")]
        public string Email { get; set; }
        public string RepitEmail { get; set; }
    }
}
