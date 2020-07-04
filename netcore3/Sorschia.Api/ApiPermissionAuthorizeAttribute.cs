using Microsoft.AspNetCore.Authorization;

namespace Sorschia
{
    internal sealed class ApiPermissionAuthorizeAttribute : AuthorizeAttribute
    {
        internal const string POLICY_NAME = "API_PERMISSION";

        public ApiPermissionAuthorizeAttribute() : base(POLICY_NAME)
        {
        }
    }
}
