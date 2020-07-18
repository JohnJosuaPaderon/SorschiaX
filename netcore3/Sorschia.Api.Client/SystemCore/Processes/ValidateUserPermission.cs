using Sorschia.ApiServices;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal sealed class ValidateUserPermission : UserProcessBase, IValidateUserPermission
    {
        public ValidateUserPermissionModel Model { get; set; }

        public ValidateUserPermission(IAccessTokenRefresher tokenRefresher, ApiServiceProvider apiServiceProvider) : base(tokenRefresher, apiServiceProvider)
        {
        }

        public Task<bool> ExecuteAsync(CancellationToken cancellationToken = default) => ExecuteAsync(() => _apiService.ValidateUserPermission(Model), cancellationToken);
    }
}
