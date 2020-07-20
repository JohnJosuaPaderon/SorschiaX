using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Sorschia
{
    internal sealed class ApiPermissionHandler : AuthorizationHandler<ApiPermissionRequirement>
    {
        private readonly bool _authorizationEnabled;

        public ApiPermissionHandler(IConfiguration configuration)
        {
            _authorizationEnabled = configuration.AuthorizationEnabled();
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ApiPermissionRequirement requirement)
        {
            if (!_authorizationEnabled || context.User.HasClaim(claim => claim.Type == requirement.Controller))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
