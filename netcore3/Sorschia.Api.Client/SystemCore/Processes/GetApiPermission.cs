using Sorschia.ApiServices;
using Sorschia.SystemCore.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal sealed class GetApiPermission : PermissionProcessBase, IGetApiPermission
    {
        public int Id { get; set; }

        public GetApiPermission(IAccessTokenRefresher tokenRefresher, ApiServiceProvider apiServiceProvider) : base(tokenRefresher, apiServiceProvider)
        {
        }

        public Task<ApiPermission> ExecuteAsync(CancellationToken cancellationToken = default) => ExecuteAsync(() => _apiService.GetApiPermission(Id), cancellationToken);
    }
}
