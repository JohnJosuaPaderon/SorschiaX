using Sorschia.ApiServices;
using Sorschia.SystemCore.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal sealed class GetPlatform : PlatformProcessBase, IGetPlatform
    {
        public int Id { get; set; }

        public GetPlatform(IAccessTokenRefresher tokenRefresher, ApiServiceProvider apiServiceProvider) : base(tokenRefresher, apiServiceProvider)
        {
        }

        public Task<Platform> ExecuteAsync(CancellationToken cancellationToken = default) => ExecuteAsync(() => _apiService.Get(Id), cancellationToken);
    }
}
