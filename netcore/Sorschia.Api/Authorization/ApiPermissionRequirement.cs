using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Sorschia.Http;

namespace Sorschia.Authorization
{
    public class ApiPermissionRequirement : IAuthorizationRequirement
    {
        public string Domain { get; }
        public string Controller { get; }
        public string Action { get; }

        public ApiPermissionRequirement(string domain, string controller, string action)
        {
            if (string.IsNullOrWhiteSpace(domain))
                throw new SorschiaException("Domain is null or white-space");

            if (string.IsNullOrWhiteSpace(controller))
                throw new SorschiaException("Controller is null or white-space");

            if (string.IsNullOrWhiteSpace(action))
                throw new SorschiaException("Action is null or white-space");

            Domain = domain;
            Controller = controller;
            Action = action;
        }

        public ApiPermissionRequirement(SorschiaDomain domain, string controller, string action) : this(domain.ToString(), controller, action)
        {
        }

        public static ApiPermissionRequirement FromContext(HttpContext context) => new ApiPermissionRequirement(context.GetDomain(), context.GetController(), context.GetAction());
    }
}
