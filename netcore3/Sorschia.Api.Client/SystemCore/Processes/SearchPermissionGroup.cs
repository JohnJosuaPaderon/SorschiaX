using Sorschia.ApiServices;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal sealed class SearchPermissionGroup : PermissionGroupProcessBase, ISearchPermissionGroup
    {
        public SearchPermissionGroupModel Model { get; set; }

        public SearchPermissionGroup(IAccessTokenRefresher tokenRefresher, ApiServiceProvider apiServiceProvider) : base(tokenRefresher, apiServiceProvider)
        {
        }

        public Task<SearchPermissionGroupResult> ExecuteAsync(CancellationToken cancellationToken = default) => ExecuteAsync(() => _apiService.Search(Model, Model.ParentIds, Model.SkippedIds), cancellationToken);
    }
}
