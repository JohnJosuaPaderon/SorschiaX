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

        #region Application
        public async Task<bool> DeleteApplicationAsync(DeleteApplicationModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = CreateCacheKey<DeleteApplicationModel, bool>(model);

            if (TryGetFromCache(cacheKey, out bool result))
            {
                return result;
            }

            using (var process = GetProcess<IDeleteApplication>())
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

            using (var process = GetProcess<IGetApplication>())
            {
                process.Id = id;
                return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _configuration.CacheExpiration.GetApplication);
            }
        }

        public async Task<GetApplicationListResult> GetApplicationListAsync(GetApplicationListModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = CreateCacheKey<GetApplicationListModel, GetApplicationListResult>(model);

            if (TryGetFromCache(cacheKey, out GetApplicationListResult result))
            {
                return result;
            }

            using (var process = GetProcess<IGetApplicationList>())
            {
                process.Model = model;
                return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _configuration.CacheExpiration.GetApplicationList);
            }
        }

        public async Task<SaveApplicationResult> SaveApplicationAsync(SaveApplicationModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = CreateCacheKey<SaveApplicationModel, SaveApplicationResult>(model);

            if (TryGetFromCache(cacheKey, out SaveApplicationResult result))
            {
                return result;
            }

            using (var process = GetProcess<ISaveApplication>())
            {
                process.Model = model;
                return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _configuration.CacheExpiration.SaveApplication);
            }
        }
        #endregion

        #region ApplicationPlatform
        public async Task<bool> DeleteApplicationPlatformAsync(DeleteApplicationPlatformModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = CreateCacheKey<DeleteApplicationPlatformModel, bool>(model);

            if (TryGetFromCache(cacheKey, out bool result))
            {
                return result;
            }

            using (var process = GetProcess<IDeleteApplicationPlatform>())
            {
                process.Model = model;
                return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _configuration.CacheExpiration.DeleteApplicationPlatform);
            }

        }

        public async Task<SystemApplicationPlatform> GetApplicationPlatformAsync(int id, CancellationToken cancellationToken = default)
        {
            var cacheKey = CreateCacheKey<int, SystemApplicationPlatform>(id);

            if (TryGetFromCache(cacheKey, out SystemApplicationPlatform applicationPlatform))
            {
                return applicationPlatform;
            }

            using (var process = GetProcess<IGetApplicationPlatform>())
            {
                process.Id = id;
                return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _configuration.CacheExpiration.GetApplicationPlatform);
            }
        }

        public async Task<GetApplicationPlatformListResult> GetApplicationPlatformListAsync(GetApplicationPlatformListModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = CreateCacheKey<GetApplicationPlatformListModel, GetApplicationPlatformListResult>(model);

            if (TryGetFromCache(cacheKey, out GetApplicationPlatformListResult result))
            {
                return result;
            }

            using (var process = GetProcess<IGetApplicationPlatformList>())
            {
                process.Model = model;
                return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _configuration.CacheExpiration.GetApplicationPlatformList);
            }
        }

        public async Task<SaveApplicationPlatformResult> SaveApplicationPlatformAsync(SaveApplicationPlatformModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = CreateCacheKey<SaveApplicationPlatformModel, SaveApplicationPlatformResult>(model);

            if (TryGetFromCache(cacheKey, out SaveApplicationPlatformResult result))
            {
                return result;
            }

            using (var process = GetProcess<ISaveApplicationPlatform>())
            {
                process.Model = model;
                return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _configuration.CacheExpiration.SaveApplicationPlatform);
            }
        }
        #endregion

        #region Module
        public async Task<bool> DeleteModuleAsync(DeleteModuleModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = CreateCacheKey<DeleteModuleModel, bool>(model);

            if (TryGetFromCache(cacheKey, out bool result))
            {
                return result;
            }

            using (var process = GetProcess<IDeleteModule>())
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

            using (var process = GetProcess<IGetModule>())
            {
                process.Id = id;
                return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _configuration.CacheExpiration.GetModule);
            }
        }

        public async Task<GetModuleListResult> GetModuleListAsync(GetModuleListModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = CreateCacheKey<GetModuleListModel, GetModuleListResult>(model);

            if (TryGetFromCache(cacheKey, out GetModuleListResult result))
            {
                return result;
            }

            using (var process = GetProcess<IGetModuleList>())
            {
                process.Model = model;
                return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _configuration.CacheExpiration.GetModuleList);
            }
        }

        public async Task<SaveModuleResult> SaveModuleAsync(SaveModuleModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = CreateCacheKey<SaveModuleModel, SaveModuleResult>(model);

            if (TryGetFromCache(cacheKey, out SaveModuleResult result))
            {
                return result;
            }

            using (var process = GetProcess<ISaveModule>())
            {
                process.Model = model;
                return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _configuration.CacheExpiration.SaveModule);
            }
        }
        #endregion

        #region Permission
        public async Task<bool> DeletePermissionAsync(DeletePermissionModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = CreateCacheKey<DeletePermissionModel, bool>(model);

            if (TryGetFromCache(cacheKey, out bool result))
            {
                return result;
            }

            using (var process = GetProcess<IDeletePermission>())
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

            using (var process = GetProcess<IGetPermission>())
            {
                process.Id = id;
                return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _configuration.CacheExpiration.GetPermission);
            }
        }

        public async Task<GetPermissionListResult> GetPermissionListAsync(GetPermissionListModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = CreateCacheKey<GetPermissionListModel, GetPermissionListResult>(model);

            if (TryGetFromCache(cacheKey, out GetPermissionListResult result))
            {
                return result;
            }

            using (var process = GetProcess<IGetPermissionList>())
            {
                process.Model = model;
                return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _configuration.CacheExpiration.GetPermissionList);
            }
        }

        public async Task<SavePermissionResult> SavePermissionAsync(SavePermissionModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = CreateCacheKey<SavePermissionModel, SavePermissionResult>(model);

            if (TryGetFromCache(cacheKey, out SavePermissionResult result))
            {
                return result;
            }

            using (var process = GetProcess<ISavePermission>())
            {
                process.Model = model;
                return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _configuration.CacheExpiration.SavePermission);
            }
        }
        #endregion

        #region User
        public async Task<bool> DeleteUserAsync(DeleteUserModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = CreateCacheKey<DeleteUserModel, bool>(model);

            if (TryGetFromCache(cacheKey, out bool result))
            {
                return result;
            }

            using (var process = GetProcess<IDeleteUser>())
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

            using (var process = GetProcess<IGetUser>())
            {
                process.Id = id;
                return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _configuration.CacheExpiration.GetUser);
            }
        }

        public async Task<GetUserListResult> GetUserListAsync(GetUserListModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = CreateCacheKey<GetUserListModel, GetUserListResult>(model);

            if (TryGetFromCache(cacheKey, out GetUserListResult result))
            {
                return result;
            }

            using (var process = GetProcess<IGetUserList>())
            {
                process.Model = model;
                return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _configuration.CacheExpiration.GetUserList);
            }
        }

        public async Task<SaveUserResult> SaveUserAsync(SaveUserModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = CreateCacheKey<SaveUserModel, SaveUserResult>(model);

            if (TryGetFromCache(cacheKey, out SaveUserResult result))
            {
                return result;
            }

            using (var process = GetProcess<ISaveUser>())
            {
                process.Model = model;
                return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _configuration.CacheExpiration.SaveUser);
            }
        }
        #endregion
    }
}
