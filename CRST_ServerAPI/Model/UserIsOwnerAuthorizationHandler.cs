using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Authorization;
 
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
using KTSF.Core;


namespace CRST_ServerAPI.Model
{
    public class UserIsOwnerAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, User>
    {
        UserManager<IdentityUser> _userManager;

        public UserIsOwnerAuthorizationHandler(UserManager<IdentityUser> userManager)
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

           /* if (requirement.Name != Constants.CreateOperationName &&
                requirement.Name != Constants.ReadOperationName &&
                requirement.Name != Constants.UpdateOperationName &&
                requirement.Name != Constants.DeleteOperationName)
            {
                return Task.CompletedTask;
            }*/

            if (resource.AccessToken == _userManager.GetUserId(context.User))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
