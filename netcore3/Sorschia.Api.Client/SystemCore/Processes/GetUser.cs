using Sorschia.ApiServices;
using Sorschia.SystemCore.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal sealed class GetUser : UserProcessBase, IGetUser
    {
        public int Id { get; set; }

        public GetUser(IAccessTokenRefresher tokenRefresher, ApiServiceProvider apiServiceProvider) : base(tokenRefresher, apiServiceProvider)
        {
        }

        public Task<User> ExecuteAsync(CancellationToken cancellationToken = default) => ExecuteAsync(() => _apiService.Get(Id), cancellationToken);
    }
}
