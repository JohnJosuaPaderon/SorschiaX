using Refit;
using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Processes;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.ApiServices
{
    public interface IUserApiService
    {
        [Delete(ApiServicePaths.Empty)]
        [Headers(ApiConstants.JwtAuthorizationHeader)]
        Task<bool> Delete([Body] DeleteUserModel model);

        [Get(ApiServicePaths.Empty)]
        [Headers(ApiConstants.JwtAuthorizationHeader)]
        Task<User> Get(int id);

        [Post(ApiServicePaths.User.Login)]
        Task<LoginUserResult> Login([Body] LoginUserModel model);

        [Post(ApiServicePaths.Empty)]
        [Headers(ApiConstants.JwtAuthorizationHeader)]
        Task<SaveUserResult> Save([Body] SaveUserModel model);

        [Post(ApiServicePaths.Search)]
        [Headers(ApiConstants.JwtAuthorizationHeader)]
        Task<SearchUserResult> Search([Body] SearchUserModel model);

        [Post(ApiServicePaths.User.ValidateUserApplication)]
        [Headers(ApiConstants.JwtAuthorizationHeader)]
        Task<bool> ValidateUserApplication([Body] ValidateUserApplicationModel model);

        [Post(ApiServicePaths.User.ValidateUserModule)]
        [Headers(ApiConstants.JwtAuthorizationHeader)]
        Task<bool> ValidateUserModule([Body] ValidateUserModuleModel model);

        [Post(ApiServicePaths.User.ValidateUserPermission)]
        [Headers(ApiConstants.JwtAuthorizationHeader)]
        Task<bool> ValidateUserPermission([Body] ValidateUserPermissionModel model);
    }
}
