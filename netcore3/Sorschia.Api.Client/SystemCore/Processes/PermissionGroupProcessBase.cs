using Sorschia.ApiServices;
using Sorschia.Processes;
using Sorschia.SystemCore.ApiServices;

namespace Sorschia.SystemCore.Processes
{
    internal abstract class PermissionGroupProcessBase : ProcessBase<IPermissionGroupApiService>
    {
        public PermissionGroupProcessBase(IAccessTokenRefresher tokenRefresher, ApiServiceProvider apiServiceProvider) : base(tokenRefresher, apiServiceProvider.PermissionGroup())
        {
        }
    }
}
