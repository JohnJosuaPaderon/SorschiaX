using Sorschia.ApiServices;
using Sorschia.SystemCore.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal sealed class GetPermission : PermissionProcessBase, IGetPermission
    {
        public int Id { get; set; }

        public GetPermission(IAccessTokenRefresher tokenRefresher, ApiServiceProvider apiServiceProvider) : base(tokenRefresher, apiServiceProvider)
        {
        }

        public Task<Permission> ExecuteAsync(CancellationToken cancellationToken = default) => ExecuteAsync(() => _apiService.Get(Id), cancellationToken);
    }
}
