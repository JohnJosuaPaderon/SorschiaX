using Refit;
using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Processes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.ApiServices
{
    public interface IPermissionTypeApiService
    {
        [Delete(ApiServicePaths.Empty)]
        [Headers(ApiConstants.JwtAuthorizationHeader)]
        Task<bool> Delete([Body] DeletePermissionTypeModel model);

        [Get(ApiServicePaths.Empty)]
        [Headers(ApiConstants.JwtAuthorizationHeader)]
        Task<PermissionType> Get(int id);

        [Post(ApiServicePaths.Empty)]
        [Headers(ApiConstants.JwtAuthorizationHeader)]
        Task<SavePermissionTypeResult> Save([Body] SavePermissionTypeModel model);

        [Get(ApiServicePaths.Search)]
        [Headers(ApiConstants.JwtAuthorizationHeader)]
        Task<SearchPermissionTypeResult> Search([Query] SearchPermissionTypeModel model,
            [Query(CollectionFormat.Multi)] IList<int> skippedIds);
    }
}
