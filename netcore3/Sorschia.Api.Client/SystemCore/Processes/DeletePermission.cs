using Sorschia.ApiServices;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal sealed class DeletePermission : PermissionProcessBase, IDeletePermission
    {
        public DeletePermissionModel Model { get; set; }

        public DeletePermission(IAccessTokenRefresher tokenRefresher, ApiServiceProvider apiServiceProvider) : base(tokenRefresher, apiServiceProvider)
        {
        }

        public Task<bool> ExecuteAsync(CancellationToken cancellationToken = default) => ExecuteAsync(() => _apiService.Delete(Model), cancellationToken);
    }
}
