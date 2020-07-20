using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
namespace IdentityZNetCore
{
    public class ForJarekRequirement : IAuthorizationRequirement
    {
    }
    public class ForJarekHandler : AuthorizationHandler<ForJarekRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ForJarekRequirement requirement)
        {
            return Task.Run(() =>
            {
                if (context.User?.Identity?.Name?.ToLower()?.Contains("jarek") == true)
                {
                    context.Succeed(requirement);

                }
                else
                {
                    context.Fail();
                }
            });
        }
    }
}

