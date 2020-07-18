using Sorschia.ApiServices;
using Sorschia.Processes;
using Sorschia.SystemCore.ApiServices;

namespace Sorschia.SystemCore.Processes
{
    internal abstract class PermissionTypeProcessBase : ProcessBase<IPermissionTypeApiService>
    {
        public PermissionTypeProcessBase(IAccessTokenRefresher tokenRefresher, ApiServiceProvider apiServiceProvider) : base(tokenRefresher, apiServiceProvider.PermissionType())
        {
        }
    }
}
