using Sorschia.ApiServices;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal sealed class DeletePermissionGroup : PermissionGroupProcessBase, IDeletePermissionGroup
    {
        public DeletePermissionGroupModel Model { get; set; }

        public DeletePermissionGroup(IAccessTokenRefresher tokenRefresher, ApiServiceProvider apiServiceProvider) : base(tokenRefresher, apiServiceProvider)
        {
        }

        public Task<bool> ExecuteAsync(CancellationToken cancellationToken = default) => ExecuteAsync(() => _apiService.Delete(Model), cancellationToken);
    }
}
