using Refit;
using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Processes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.ApiServices
{
    public interface IPlatformApiService
    {
        [Delete(ApiServicePaths.Empty)]
        [Headers(ApiConstants.JwtAuthorizationHeader)]
        Task<bool> Delete([Body] DeletePlatformModel model);

        [Get(ApiServicePaths.Empty)]
        [Headers(ApiConstants.JwtAuthorizationHeader)]
        Task<Platform> Get(int id);

        [Post(ApiServicePaths.Empty)]
        [Headers(ApiConstants.JwtAuthorizationHeader)]
        Task<SavePlatformResult> Save([Body] SavePlatformModel model);

        [Get(ApiServicePaths.Search)]
        [Headers(ApiConstants.JwtAuthorizationHeader)]
        Task<SearchPlatformResult> Search([Query] SearchPlatformModel model,
            [Query(CollectionFormat.Multi)] IList<int> skippedIds);
    }
}
