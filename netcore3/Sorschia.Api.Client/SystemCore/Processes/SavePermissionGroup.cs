using Sorschia.ApiServices;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal sealed class SavePermissionGroup : PermissionGroupProcessBase, ISavePermissionGroup
    {
        public SavePermissionGroupModel Model { get; set; }

        public SavePermissionGroup(IAccessTokenRefresher tokenRefresher, ApiServiceProvider apiServiceProvider) : base(tokenRefresher, apiServiceProvider)
        {
        }

        public Task<SavePermissionGroupResult> ExecuteAsync(CancellationToken cancellationToken = default) => ExecuteAsync(() => _apiService.Save(Model), cancellationToken);
    }
}
