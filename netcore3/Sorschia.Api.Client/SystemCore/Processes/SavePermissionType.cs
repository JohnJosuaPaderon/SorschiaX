using Sorschia.ApiServices;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal sealed class SavePermissionType : PermissionTypeProcessBase, ISavePermissionType
    {
        public SavePermissionTypeModel Model { get; set; }

        public SavePermissionType(IAccessTokenRefresher tokenRefresher, ApiServiceProvider apiServiceProvider) : base(tokenRefresher, apiServiceProvider)
        {
        }

        public Task<SavePermissionTypeResult> ExecuteAsync(CancellationToken cancellationToken = default) => ExecuteAsync(() => _apiService.Save(Model), cancellationToken);
    }
}
