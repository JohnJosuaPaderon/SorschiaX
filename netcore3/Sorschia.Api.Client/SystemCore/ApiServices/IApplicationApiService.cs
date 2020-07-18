using Refit;
using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Processes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.ApiServices
{
    public interface IApplicationApiService
    {
        [Delete(ApiServicePaths.Empty)]
        [Headers(ApiConstants.JwtAuthorizationHeader)]
        Task<bool> Delete([Body] DeleteApplicationModel model);

        [Get(ApiServicePaths.Empty)]
        [Headers(ApiConstants.JwtAuthorizationHeader)]
        Task<Application> Get(int id);

        [Post(ApiServicePaths.Empty)]
        [Headers(ApiConstants.JwtAuthorizationHeader)]
        Task<SaveApplicationResult> Save([Body] SaveApplicationModel model);

        [Get(ApiServicePaths.Search)]
        [Headers(ApiConstants.JwtAuthorizationHeader)]
        Task<SearchApplicationResult> Search([Query] SearchApplicationModel model, 
            [Query(CollectionFormat.Multi)] IList<int> platformIds, 
            [Query(CollectionFormat.Multi)] IList<int> skippedIds);
    }
}
