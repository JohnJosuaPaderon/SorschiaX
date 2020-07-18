using Sorschia.ApiServices;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal sealed class SavePlatform : PlatformProcessBase, ISavePlatform
    {
        public SavePlatformModel Model { get; set; }

        public SavePlatform(IAccessTokenRefresher tokenRefresher, ApiServiceProvider apiServiceProvider) : base(tokenRefresher, apiServiceProvider)
        {
        }

        public Task<SavePlatformResult> ExecuteAsync(CancellationToken cancellationToken = default) => ExecuteAsync(() => _apiService.Save(Model), cancellationToken);
    }
}
