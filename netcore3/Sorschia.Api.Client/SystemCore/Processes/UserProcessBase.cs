using Sorschia.ApiServices;
using Sorschia.Processes;
using Sorschia.SystemCore.ApiServices;

namespace Sorschia.SystemCore.Processes
{
    internal abstract class UserProcessBase : ProcessBase<IUserApiService>
    {
        public UserProcessBase(IAccessTokenRefresher tokenRefresher, ApiServiceProvider apiServiceProvider) : base(tokenRefresher, apiServiceProvider.User())
        {
        }
    }
}
