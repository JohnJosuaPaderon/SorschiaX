using Sorschia.ApiServices;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal sealed class SearchApplication : ApplicationProcessBase, ISearchApplication
    {
        public SearchApplicationModel Model { get; set; }

        public SearchApplication(IAccessTokenRefresher tokenRefresher, ApiServiceProvider apiServiceProvider) : base(tokenRefresher, apiServiceProvider)
        {
        }

        public Task<SearchApplicationResult> ExecuteAsync(CancellationToken cancellationToken = default) => ExecuteAsync(() => _apiService.Search(Model, Model.PlatformIds, Model.SkippedIds), cancellationToken);
    }
}
