using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityZNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace IdentityZNetCore
{
    public class ContextDBIdentity : IdentityDbContext<IdentityZNetCore.Models.AppUser>
    {
        public ContextDBIdentity(DbContextOptions options) :base(options)
        {

        }
    }
}
