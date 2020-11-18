using Microsoft.AspNetCore.Authorization;

namespace Sorschia.Authorization
{
    public class ApiPermissionAuthorizeAttribute : AuthorizeAttribute
    {
        public ApiPermissionAuthorizeAttribute() : base(Policies.ApiPermisssion)
        {
        }
    }
}
