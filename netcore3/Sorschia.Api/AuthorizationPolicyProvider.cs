using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace Sorschia
{
    internal sealed class AuthorizationPolicyProvider : DefaultAuthorizationPolicyProvider
    {
        private const string ROUTEDATA_CONTROLLER = "controller";
        private const string ROUTEDATA_ACTION = "action";

        private readonly IActionContextAccessor _actionContextAccessor;

        public AuthorizationPolicyProvider(IOptions<AuthorizationOptions> options, IActionContextAccessor actionContextAccessor) : base(options)
        {
            _actionContextAccessor = actionContextAccessor;
        }

        public override async Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            var policy = await base.GetPolicyAsync(policyName);

            if (policy is null && !string.IsNullOrWhiteSpace(policyName))
            {
                if (policyName == ApiPermissionAuthorizeAttribute.POLICY_NAME)
                {
                    var actionContext = _actionContextAccessor.ActionContext;
                    var controller = Convert.ToString(actionContext.RouteData.Values[ROUTEDATA_CONTROLLER]);
                    var action = Convert.ToString(actionContext.RouteData.Values[ROUTEDATA_ACTION]);

                    policy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                        .RequireAuthenticatedUser()
                        .AddRequirements(new ApiPermissionRequirement(controller, action))
                        .Build();
                }
            }

            return policy;
        }
    }
}
