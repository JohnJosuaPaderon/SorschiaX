using Sorschia.ApiServices;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal sealed class SaveApiPermission : PermissionProcessBase, ISaveApiPermission
    {
        public SaveApiPermissionModel Model { get; set; }

        public SaveApiPermission(IAccessTokenRefresher tokenRefresher, ApiServiceProvider apiServiceProvider) : base(tokenRefresher, apiServiceProvider)
        {
        }

        public Task<SaveApiPermissionResult> ExecuteAsync(CancellationToken cancellationToken = default) => ExecuteAsync(() => _apiService.SaveApiPermission(Model), cancellationToken);
    }
}
