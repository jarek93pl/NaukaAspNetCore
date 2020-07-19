using IdentityZNetCore.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityZNetCore
{
    public class LocationClaimsProvider : IClaimsTransformation
    {
        public static readonly string NameClaimToRegion = "adres";
        UserManager<AppUser> userManager;
        public LocationClaimsProvider(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var user = await userManager.FindByNameAsync(principal.Identity.Name);
            if (principal.Identity is ClaimsIdentity claimsIdentity)
            {
                claimsIdentity.AddClaim(new Claim(NameClaimToRegion, user.Region.ToString()));
            }
            return principal;
        }
    }
}
