using Refit;
using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Processes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.ApiServices
{
    public interface IModuleApiService
    {
        [Delete(ApiServicePaths.Empty)]
        [Headers(ApiConstants.JwtAuthorizationHeader)]
        Task<bool> Delete([Body] DeleteModuleModel model);

        [Get(ApiServicePaths.Empty)]
        [Headers(ApiConstants.JwtAuthorizationHeader)]
        Task<Module> Get(int id);

        [Post(ApiServicePaths.Empty)]
        [Headers(ApiConstants.JwtAuthorizationHeader)]
        Task<SaveModuleResult> Save([Body] SaveModuleModel model);

        [Get(ApiServicePaths.Search)]
        [Headers(ApiConstants.JwtAuthorizationHeader)]
        Task<SearchModuleResult> Search([Query] SearchModuleModel model,
            [Query(CollectionFormat.Multi)] IList<int> applicationIds,
            [Query(CollectionFormat.Multi)] IList<int> skippedIds);
    }
}
