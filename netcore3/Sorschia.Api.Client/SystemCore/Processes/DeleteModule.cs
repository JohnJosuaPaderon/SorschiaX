using Sorschia.ApiServices;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal sealed class DeleteModule : ModuleProcessBase, IDeleteModule
    {
        public DeleteModuleModel Model { get; set; }

        public DeleteModule(IAccessTokenRefresher tokenRefresher, ApiServiceProvider apiServiceProvider) : base(tokenRefresher, apiServiceProvider)
        {
        }

        public Task<bool> ExecuteAsync(CancellationToken cancellationToken = default) => ExecuteAsync(() => _apiService.Delete(Model), cancellationToken);
    }
}
