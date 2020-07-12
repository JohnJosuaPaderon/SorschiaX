using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Repositories
{
    public interface IUserRepository
    {
        Task<bool> DeleteAsync(DeleteUserModel model, CancellationToken cancellationToken = default);
        Task<User> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<LoginUserResult> LoginAsync(LoginUserModel model, CancellationToken cancellationToken = default);
        Task<SaveUserResult> SaveAsync(SaveUserModel model, CancellationToken cancellationToken = default);
        Task<SearchUserResult> SearchAsync(SearchUserModel model, CancellationToken cancellationToken = default);
        Task<bool> ValidateUserApplicationAsync(ValidateUserApplicationModel model, CancellationToken cancellationToken = default);
        Task<bool> ValidateUserModuleAsync(ValidateUserModuleModel model, CancellationToken cancellationToken = default);
        Task<bool> ValidateUserPermissionAsync(ValidateUserPermissionModel model, CancellationToken cancellationToken = default);
    }
}
