using Sorschia.Caching;
using Sorschia.SystemBase.Security.Entities;
using Sorschia.SystemBase.Security.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemBase.Security
{
    internal sealed partial class SystemBaseSecurityRepository : CachedRepositoryBase, ISystemBaseSecurityRepository
    {
        public SystemBaseSecurityRepository(IDependencyProvider dependencyProvider, ICache cache, SystemBaseSecurityConfiguration configuration) : base(dependencyProvider, cache)
        {
            _configuration = configuration;
        }

        private readonly SystemBaseSecurityConfiguration _configuration;

        #region SystemApplication
        public async Task<bool> DeleteApplicationAsync(DeleteSystemApplicationModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = CreateCacheKey<DeleteSystemApplicationModel, bool>(model);

            if (TryGetFromCache(cacheKey, out bool result))
            {
                return result;
            }

            using (var process = GetProcess<IDeleteSystemApplication>())
            {
                process.Model = model;
                return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _configuration.CacheExpiration.DeleteApplication);
            }
        }

        public async Task<SystemApplication> GetApplicationAsync(int id, CancellationToken cancellationToken = default)
        {
            var cacheKey = CreateCacheKey<int, SystemApplication>(id);

            if (TryGetFromCache(cacheKey, out SystemApplication application))
            {
                return application;
            }

            using (var process = GetProcess<IGetSystemApplication>())
            {
                process.Id = id;
                return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _configuration.CacheExpiration.GetApplication);
            }
        }

        public async Task<SaveSystemApplicationResult> SaveApplicationAsync(SavesystemApplicationModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = CreateCacheKey<SavesystemApplicationModel, SaveSystemApplicationResult>(model);

            if (TryGetFromCache(cacheKey, out SaveSystemApplicationResult result))
            {
                return result;
            }

            using (var process = GetProcess<ISaveSystemApplication>())
            {
                process.Model = model;
                return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _configuration.CacheExpiration.SaveApplication);
            }
        }
        #endregion

        #region SystemModule
        public async Task<bool> DeleteModuleAsync(DeleteSystemModuleModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = CreateCacheKey<DeleteSystemModuleModel, bool>(model);

            if (TryGetFromCache(cacheKey, out bool result))
            {
                return result;
            }

            using (var process = GetProcess<IDeleteSystemModule>())
            {
                process.Model = model;
                return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _configuration.CacheExpiration.DeleteModule);
            }
        }

        public async Task<SystemModule> GetModuleAsync(int id, CancellationToken cancellationToken = default)
        {
            var cacheKey = CreateCacheKey<int, SystemModule>(id);

            if (TryGetFromCache(cacheKey, out SystemModule module))
            {
                return module;
            }

            using (var process = GetProcess<IGetSystemModule>())
            {
                process.Id = id;
                return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _configuration.CacheExpiration.GetModule);
            }
        }

        public async Task<SaveSystemModuleResult> SaveModuleAsync(SaveSystemModuleModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = CreateCacheKey<SaveSystemModuleModel, SaveSystemModuleResult>(model);

            if (TryGetFromCache(cacheKey, out SaveSystemModuleResult result))
            {
                return result;
            }

            using (var process = GetProcess<ISaveSystemModule>())
            {
                process.Model = model;
                return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _configuration.CacheExpiration.SaveModule);
            }
        }
        #endregion

        #region SystemPermission
        public async Task<bool> DeletePermissionAsync(DeleteSystemPermissionModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = CreateCacheKey<DeleteSystemPermissionModel, bool>(model);

            if (TryGetFromCache(cacheKey, out bool result))
            {
                return result;
            }

            using (var process = GetProcess<IDeleteSystemPermission>())
            {
                process.Model = model;
                return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _configuration.CacheExpiration.DeletePermission);
            }
        }

        public async Task<SystemPermission> GetPermissionAsync(int id, CancellationToken cancellationToken = default)
        {
            var cacheKey = CreateCacheKey<int, SystemPermission>(id);

            if (TryGetFromCache(cacheKey, out SystemPermission permission))
            {
                return permission;
            }

            using (var process = GetProcess<IGetSystemPermission>())
            {
                process.Id = id;
                return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _configuration.CacheExpiration.GetPermission);
            }
        }

        public async Task<SaveSystemPermissionResult> SavePermissionAsync(SaveSystemPermissionModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = CreateCacheKey<SaveSystemPermissionModel, SaveSystemPermissionResult>(model);

            if (TryGetFromCache(cacheKey, out SaveSystemPermissionResult result))
            {
                return result;
            }

            using (var process = GetProcess<ISaveSystemPermission>())
            {
                process.Model = model;
                return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _configuration.CacheExpiration.SavePermission);
            }
        }
        #endregion

        #region SystemUser
        public async Task<bool> DeleteUserAsync(DeleteSystemUserModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = CreateCacheKey<DeleteSystemUserModel, bool>(model);

            if (TryGetFromCache(cacheKey, out bool result))
            {
                return result;
            }

            using (var process = GetProcess<IDeleteSystemUser>())
            {
                process.Model = model;
                return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _configuration.CacheExpiration.DeleteUser);
            }
        }

        public async Task<SystemUser> GetUserAsync(int id, CancellationToken cancellationToken = default)
        {
            var cacheKey = CreateCacheKey<int, SystemUser>(id);

            if (TryGetFromCache(cacheKey, out SystemUser user))
            {
                return user;
            }

            using (var process = GetProcess<IGetSystemUser>())
            {
                process.Id = id;
                return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _configuration.CacheExpiration.GetUser);
            }
        }

        public async Task<SaveSystemUserResult> SaveUserAsync(SaveSystemUserModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = CreateCacheKey<SaveSystemUserModel, SaveSystemUserResult>(model);

            if (TryGetFromCache(cacheKey, out SaveSystemUserResult result))
            {
                return result;
            }

            using (var process = GetProcess<ISaveSystemUser>())
            {
                process.Model = model;
                return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _configuration.CacheExpiration.SaveUser);
            }
        }
        #endregion
    }
}
