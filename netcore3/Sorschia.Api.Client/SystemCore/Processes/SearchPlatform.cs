using Sorschia.ApiServices;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal sealed class SearchPlatform : PlatformProcessBase, ISearchPlatform
    {
        public SearchPlatformModel Model { get; set; }

        public SearchPlatform(IAccessTokenRefresher tokenRefresher, ApiServiceProvider apiServiceProvider) : base(tokenRefresher, apiServiceProvider)
        {
        }

        public Task<SearchPlatformResult> ExecuteAsync(CancellationToken cancellationToken = default) => ExecuteAsync(() => _apiService.Search(Model, Model.SkippedIds), cancellationToken);
    }
}
