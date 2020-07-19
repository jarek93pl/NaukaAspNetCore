using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityZNetCore.Models
{
    public enum Region
    {
        Lodzkie,
        Mazowieckie
    }

    public class AppUser : IdentityUser
    {
        public Region Region { get; set; }
        public int TemData { get; set; }
    }
}
