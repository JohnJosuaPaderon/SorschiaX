using Sorschia.ApiServices;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal sealed class SaveUser : UserProcessBase, ISaveUser
    {
        public SaveUserModel Model { get; set; }

        public SaveUser(IAccessTokenRefresher tokenRefresher, ApiServiceProvider apiServiceProvider) : base(tokenRefresher, apiServiceProvider)
        {
        }

        public Task<SaveUserResult> ExecuteAsync(CancellationToken cancellationToken = default) => ExecuteAsync(() => _apiService.Save(Model), cancellationToken);
    }
}
