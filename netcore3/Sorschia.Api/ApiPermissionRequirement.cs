using Microsoft.AspNetCore.Authorization;

namespace Sorschia
{
    internal sealed class ApiPermissionRequirement : IAuthorizationRequirement
    {
        public ApiPermissionRequirement(string domain, string controller, string action)
        {
            if (string.IsNullOrWhiteSpace(domain))
                SorschiaException.InvalidParameter<string>(nameof(domain));

            if (string.IsNullOrWhiteSpace(controller))
                SorschiaException.InvalidParameter<string>(nameof(controller));

            if (string.IsNullOrWhiteSpace(action))
                SorschiaException.InvalidParameter<string>(nameof(action));

            Domain = domain;
            Controller = controller;
            Action = action;
        }

        public ApiPermissionRequirement(SorschiaDomain domain, string controller, string action) : this(domain.ToString(), controller, action)
        {
        }

        public string Domain { get; }
        public string Controller { get; }
        public string Action { get; }
    }
}
