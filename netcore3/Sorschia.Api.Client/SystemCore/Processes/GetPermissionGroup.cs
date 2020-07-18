using Sorschia.ApiServices;
using Sorschia.SystemCore.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal sealed class GetPermissionGroup : PermissionGroupProcessBase, IGetPermissionGroup
    {
        public int Id { get; set; }

        public GetPermissionGroup(IAccessTokenRefresher tokenRefresher, ApiServiceProvider apiServiceProvider) : base(tokenRefresher, apiServiceProvider)
        {
        }

        public Task<PermissionGroup> ExecuteAsync(CancellationToken cancellationToken = default) => ExecuteAsync(() => _apiService.Get(Id), cancellationToken);
    }
}
