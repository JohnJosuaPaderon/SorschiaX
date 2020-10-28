using Sorschia.Caching;
using Sorschia.Repositories;
using Sorschia.SystemCore.Configuration;
using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Processes;
using Sorschia.Utilities;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Repositories
{
    internal sealed class UserCachedRepository : CachedRepositoryBase, IUserRepository
    {
        private readonly SystemCoreConfiguration.CacheExpirationSection.UserSection _cacheExpiration;

        public UserCachedRepository(IDependencyResolver dependencyResolver, ICache cache, ICacheHelper cacheHelper, SystemCoreConfiguration configuration) : base(dependencyResolver, cache, cacheHelper)
        {
            _cacheExpiration = configuration.CacheExpiration.User;
        }

        public async Task<bool> DeleteAsync(DeleteUserModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = _cacheHelper.CreateKey<DeleteUserModel, bool>(model);

            if (TryGetFromCache(cacheKey, out bool result)) return result;

            using var process = GetProcess<IDeleteUser>();
            process.Model = model;
            return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _cacheExpiration.Delete);
        }

        public async Task<User> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var cacheKey = _cacheHelper.CreateKey<int, User>(id);

            if (TryGetFromCache(cacheKey, out User user)) return user;

            using var process = GetProcess<IGetUser>();
            process.Id = id;
            return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _cacheExpiration.Get);
        }

        public async Task<LoginUserResult> LoginAsync(LoginUserModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = _cacheHelper.CreateKey<LoginUserModel, LoginUserResult>(model);

            if (TryGetFromCache(cacheKey, out LoginUserResult result)) return result;

            using var process = GetProcess<ILoginUser>();
            process.Model = model;
            return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _cacheExpiration.Login);
        }

        public async Task<SaveUserResult> SaveAsync(SaveUserModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = _cacheHelper.CreateKey<SaveUserModel, SaveUserResult>(model);

            if (TryGetFromCache(cacheKey, out SaveUserResult result)) return result;

            using var process = GetProcess<ISaveUser>();
            process.Model = model;
            return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _cacheExpiration.Save);
        }

        public async Task<SearchUserResult> SearchAsync(SearchUserModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = _cacheHelper.CreateKey<SearchUserModel, SearchUserResult>(model);

            if (TryGetFromCache(cacheKey, out SearchUserResult result)) return result;

            using var process = GetProcess<ISearchUser>();
            process.Model = model;
            return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _cacheExpiration.Search);
        }

        public async Task<bool> ValidateUserApplicationAsync(ValidateUserApplicationModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = _cacheHelper.CreateKey<ValidateUserApplicationModel, bool>(model);

            if (TryGetFromCache(cacheKey, out bool result)) return result;

            using var process = GetProcess<IValidateUserApplication>();
            process.Model = model;
            return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _cacheExpiration.ValidateUserApplication);
        }

        public async Task<bool> ValidateUserModuleAsync(ValidateUserModuleModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = _cacheHelper.CreateKey<ValidateUserModuleModel, bool>(model);

            if (TryGetFromCache(cacheKey, out bool result)) return result;

            using var process = GetProcess<IValidateUserModule>();
            process.Model = model;
            return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _cacheExpiration.ValidateUserModule);
        }

        public async Task<bool> ValidateUserPermissionAsync(ValidateUserPermissionModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = _cacheHelper.CreateKey<ValidateUserPermissionModel, bool>(model);

            if (TryGetFromCache(cacheKey, out bool result)) return result;

            using var process = GetProcess<IValidateUserPermission>();
            process.Model = model;
            return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _cacheExpiration.ValidateUserPermission);
        }
    }
}
