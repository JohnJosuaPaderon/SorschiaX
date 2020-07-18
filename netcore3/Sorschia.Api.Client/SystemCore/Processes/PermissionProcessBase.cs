using Sorschia.ApiServices;
using Sorschia.Processes;
using Sorschia.SystemCore.ApiServices;

namespace Sorschia.SystemCore.Processes
{
    internal abstract class PermissionProcessBase : ProcessBase<IPermissionApiService>
    {
        public PermissionProcessBase(IAccessTokenRefresher tokenRefresher, ApiServiceProvider apiServiceProvider) : base(tokenRefresher, apiServiceProvider.Permission())
        {
        }
    }
}
