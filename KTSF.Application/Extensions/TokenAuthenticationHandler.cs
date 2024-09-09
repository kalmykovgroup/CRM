 
using KTSF.Core.App;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace KTSF.Application.Extensions
{
   public class TokenAuthenticationHandler : AuthorizationHandler<OperationAuthorizationRequirement, User>
    {
        UserManager<IdentityUser> _userManager;

        public TokenAuthenticationHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, User resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }
            // Если вы не спрашиваете разрешения на использование CRUD, вернитесь.

            /*if (requirement.Name != Constants.CreateOperationName &&
                requirement.Name != Constants.ReadOperationName &&
                requirement.Name != Constants.UpdateOperationName &&
                requirement.Name != Constants.DeleteOperationName)
            {
                return Task.CompletedTask;
            }*/

            if (resource.JwtToken == _userManager.GetUserId(context.User))
            {
                //string? token = await _userManager.GetAuthenticationTokenAsync(context.User);
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    } 
}
