using Sorschia.ApiServices;
using Sorschia.SystemCore.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal sealed class GetModule : ModuleProcessBase, IGetModule
    {
        public int Id { get; set; }

        public GetModule(IAccessTokenRefresher tokenRefresher, ApiServiceProvider apiServiceProvider) : base(tokenRefresher, apiServiceProvider)
        {
        }

        public Task<Module> ExecuteAsync(CancellationToken cancellationToken = default) => ExecuteAsync(() => _apiService.Get(Id), cancellationToken);
    }
}
