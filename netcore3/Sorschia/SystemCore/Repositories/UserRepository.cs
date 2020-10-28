using Sorschia.Repositories;
using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Processes;
using Sorschia.Utilities;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Repositories
{
    internal sealed class UserRepository : RepositoryBase, IUserRepository
    {
        public UserRepository(IDependencyResolver dependencyResolver) : base(dependencyResolver)
        {
        }

        public Task<bool> DeleteAsync(DeleteUserModel model, CancellationToken cancellationToken = default)
        {
            using var process = GetProcess<IDeleteUser>();
            process.Model = model;
            return process.ExecuteAsync(cancellationToken);
        }

        public Task<User> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            using var process = GetProcess<IGetUser>();
            process.Id = id;
            return process.ExecuteAsync(cancellationToken);
        }

        public Task<LoginUserResult> LoginAsync(LoginUserModel model, CancellationToken cancellationToken = default)
        {
            using var process = GetProcess<ILoginUser>();
            process.Model = model;
            return process.ExecuteAsync(cancellationToken);
        }

        public Task<SaveUserResult> SaveAsync(SaveUserModel model, CancellationToken cancellationToken = default)
        {
            using var process = GetProcess<ISaveUser>();
            process.Model = model;
            return process.ExecuteAsync(cancellationToken);
        }

        public Task<SearchUserResult> SearchAsync(SearchUserModel model, CancellationToken cancellationToken = default)
        {
            using var process = GetProcess<ISearchUser>();
            process.Model = model;
            return process.ExecuteAsync(cancellationToken);
        }

        public Task<bool> ValidateUserApplicationAsync(ValidateUserApplicationModel model, CancellationToken cancellationToken = default)
        {
            using var process = GetProcess<IValidateUserApplication>();
            process.Model = model;
            return process.ExecuteAsync(cancellationToken);
        }

        public Task<bool> ValidateUserModuleAsync(ValidateUserModuleModel model, CancellationToken cancellationToken = default)
        {
            using var process = GetProcess<IValidateUserModule>();
            process.Model = model;
            return process.ExecuteAsync(cancellationToken);
        }

        public Task<bool> ValidateUserPermissionAsync(ValidateUserPermissionModel model, CancellationToken cancellationToken = default)
        {
            using var process = GetProcess<IValidateUserPermission>();
            process.Model = model;
            return process.ExecuteAsync(cancellationToken);
        }
    }
}
