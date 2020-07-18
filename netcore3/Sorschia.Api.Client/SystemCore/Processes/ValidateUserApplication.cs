using Sorschia.ApiServices;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal sealed class ValidateUserApplication : UserProcessBase, IValidateUserApplication
    {
        public ValidateUserApplicationModel Model { get; set; }

        public ValidateUserApplication(IAccessTokenRefresher tokenRefresher, ApiServiceProvider apiServiceProvider) : base(tokenRefresher, apiServiceProvider)
        {
        }

        public Task<bool> ExecuteAsync(CancellationToken cancellationToken = default) => ExecuteAsync(() => _apiService.ValidateUserApplication(Model), cancellationToken);
    }
}
