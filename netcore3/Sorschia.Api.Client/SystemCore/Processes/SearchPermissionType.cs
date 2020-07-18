using Sorschia.ApiServices;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal sealed class SearchPermissionType : PermissionTypeProcessBase, ISearchPermissionType
    {
        public SearchPermissionTypeModel Model { get; set; }

        public SearchPermissionType(IAccessTokenRefresher tokenRefresher, ApiServiceProvider apiServiceProvider) : base(tokenRefresher, apiServiceProvider)
        {
        }

        public Task<SearchPermissionTypeResult> ExecuteAsync(CancellationToken cancellationToken = default) => ExecuteAsync(() => _apiService.Search(Model, Model.SkippedIds), cancellationToken);
    }
}
