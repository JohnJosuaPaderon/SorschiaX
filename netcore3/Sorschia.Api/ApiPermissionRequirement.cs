using Microsoft.AspNetCore.Authorization;

namespace Sorschia
{
    internal sealed class ApiPermissionRequirement : IAuthorizationRequirement
    {
        public ApiPermissionRequirement(string controller, string action)
        {
            if (string.IsNullOrWhiteSpace(controller))
                SorschiaException.InvalidParameter<string>(nameof(controller));

            if (string.IsNullOrWhiteSpace(action))
                SorschiaException.InvalidParameter<string>(nameof(action));

            Controller = controller;
            Action = action;
        }   

        public string Controller { get; }
        public string Action { get; }
    }
}
