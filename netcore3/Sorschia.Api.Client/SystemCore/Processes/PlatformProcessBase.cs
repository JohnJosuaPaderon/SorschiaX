using Sorschia.ApiServices;
using Sorschia.Processes;
using Sorschia.SystemCore.ApiServices;

namespace Sorschia.SystemCore.Processes
{
    internal abstract class PlatformProcessBase : ProcessBase<IPlatformApiService>
    {
        public PlatformProcessBase(IAccessTokenRefresher tokenRefresher, ApiServiceProvider apiServiceProvider) : base(tokenRefresher, apiServiceProvider.Platform())
        {
        }
    }
}
