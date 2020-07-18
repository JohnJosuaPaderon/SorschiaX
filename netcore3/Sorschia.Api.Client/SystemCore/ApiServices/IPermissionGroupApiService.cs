using Refit;
using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Processes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.ApiServices
{
    public interface IPermissionGroupApiService
    {
        [Delete(ApiServicePaths.Empty)]
        [Headers(ApiConstants.JwtAuthorizationHeader)]
        Task<bool> Delete([Body] DeletePermissionGroupModel model);

        [Get(ApiServicePaths.Empty)]
        [Headers(ApiConstants.JwtAuthorizationHeader)]
        Task<PermissionGroup> Get(int id);

        [Post(ApiServicePaths.Empty)]
        [Headers(ApiConstants.JwtAuthorizationHeader)]
        Task<SavePermissionGroupResult> Save([Body] SavePermissionGroupModel model);

        [Get(ApiServicePaths.Search)]
        [Headers(ApiConstants.JwtAuthorizationHeader)]
        Task<SearchPermissionGroupResult> Search([Query] SearchPermissionGroupModel model,
            [Query(CollectionFormat.Multi)] IList<int> parentIds,
            [Query(CollectionFormat.Multi)] IList<int> skippedIds);
    }
}
