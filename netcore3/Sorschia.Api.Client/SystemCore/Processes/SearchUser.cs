using Sorschia.ApiServices;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal sealed class SearchUser : UserProcessBase, ISearchUser
    {
        public SearchUserModel Model { get; set; }

        public SearchUser(IAccessTokenRefresher tokenRefresher, ApiServiceProvider apiServiceProvider) : base(tokenRefresher, apiServiceProvider)
        {
        }

        public Task<SearchUserResult> ExecuteAsync(CancellationToken cancellationToken = default) => ExecuteAsync(() => _apiService.Search(Model, Model.SkippedIds), cancellationToken);
    }
}
