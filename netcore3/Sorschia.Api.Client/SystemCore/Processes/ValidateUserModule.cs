using Sorschia.ApiServices;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal sealed class ValidateUserModule : UserProcessBase, IValidateUserModule
    {
        public ValidateUserModuleModel Model { get; set; }

        public ValidateUserModule(IAccessTokenRefresher tokenRefresher, ApiServiceProvider apiServiceProvider) : base(tokenRefresher, apiServiceProvider)
        {
        }

        public Task<bool> ExecuteAsync(CancellationToken cancellationToken = default) => ExecuteAsync(() => _apiService.ValidateUserModule(Model), cancellationToken);
    }
}
