using Sorschia.ApiServices;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal sealed class DeleteUser : UserProcessBase, IDeleteUser
    {
        public DeleteUserModel Model { get; set; }

        public DeleteUser(IAccessTokenRefresher tokenRefresher, ApiServiceProvider apiServiceProvider) : base(tokenRefresher, apiServiceProvider)
        {
        }

        public Task<bool> ExecuteAsync(CancellationToken cancellationToken = default) => ExecuteAsync(() => _apiService.Delete(Model), cancellationToken);
    }
}
