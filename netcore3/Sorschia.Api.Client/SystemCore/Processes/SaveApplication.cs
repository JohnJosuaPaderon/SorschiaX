using Sorschia.ApiServices;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal sealed class SaveApplication : ApplicationProcessBase, ISaveApplication
    {
        public SaveApplicationModel Model { get; set; }

        public SaveApplication(IAccessTokenRefresher tokenRefresher, ApiServiceProvider apiServiceProvider) : base(tokenRefresher, apiServiceProvider)
        {
        }

        public Task<SaveApplicationResult> ExecuteAsync(CancellationToken cancellationToken = default) => ExecuteAsync(() => _apiService.Save(Model), cancellationToken);
    }
}
