using MediatR;
using Microsoft.EntityFrameworkCore;
using Sorschia.Data;
using Sorschia.Entities;
using Sorschia.Extensions;
using Sorschia.Processes.Extensions;
using Sorschia.Utilities;
using Sorschia.Utilities.ExceptionBuilders;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Processes.Handlers
{
    internal sealed class UpdateUserHandler : IRequestHandler<UpdateUser, UpdateUser.Result>
    {
        private readonly IDbContextFactory<SorschiaDbContext> _contextFactory;
        private readonly ICurrentFootprintProvider _currentFootprintProvider;
        private readonly IFullNameBuilder _fullNameBuilder;

        public UpdateUserHandler(IDbContextFactory<SorschiaDbContext> contextFactory, ICurrentFootprintProvider currentFootprintProvider, IFullNameBuilder fullNameBuilder)
        {
            _contextFactory = contextFactory;
            _currentFootprintProvider = currentFootprintProvider;
            _fullNameBuilder = fullNameBuilder;
        }

        public async Task<UpdateUser.Result> Handle(UpdateUser request, CancellationToken cancellationToken)
        {
            using var context = _contextFactory.CreateDbContext();
            using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);
            var footprint = _currentFootprintProvider.Current;
            var result = new UpdateUser.Result();
            await UpdateUserAsync(context, request, footprint, result, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return result;
        }

        #region Update User
        private async Task UpdateUserAsync(SorschiaDbContext context, UpdateUser request, Footprint footprint, UpdateUser.Result result, CancellationToken cancellationToken)
        {
            var user = await context.Users.FindAsync(new object[] { request.Id }, cancellationToken);
            var requestFullName = _fullNameBuilder.Build(request.FirstName, request.MiddleName, request.LastName, request.NameSuffix);

            if (user is null)
                throw new SorschiaEntityNotFoundExceptionBuilder()
                    .WithEntityType<User>()
                    .AddLookupField("Id", request.Id)
                    .Build();

            if (await context.Users.AnyAsync(_ => _.Id != request.Id && _.Username == request.Username, cancellationToken))
                throw new SorschiaDuplicateEntityFieldExceptionBuilder()
                    .WithEntityType<User>()
                    .AddDuplicateField("Username", request.Username)
                    .Build();

            if (user.HasChanges(request, requestFullName))
            {
                user.FromRequest(request, requestFullName);
                context.Entry(user).SetUpdateFootprint(footprint);
                context.Update(user);
            }

            await InsertUserApplicationsAsync(context, request.ApplicationIds, user.Id, footprint, result.UserApplications, cancellationToken);
            await InsertUserRolesAsync(context, request.RoleIds, user.Id, footprint, result.UserRoles, cancellationToken);
            await InsertUserPermissionsAsync(context, request.PermissionIds, user.Id, footprint, result.UserPermissions, cancellationToken);
            await DeleteUserApplicationsAsync(context, request.DeletedUserApplicationIds, footprint, result.DeletedUserApplicationIds, cancellationToken);
            await DeleteUserRolesAsync(context, request.DeletedUserRoleIds, footprint, result.DeletedUserRoleIds, cancellationToken);
            await DeleteUserPermissionsAsync(context, request.DeletedUserPermissionIds, footprint, result.DeletedUserPermissionIds, cancellationToken);
        }
        #endregion

        #region Insert User-Applications
        private static async Task InsertUserApplicationsAsync(SorschiaDbContext context, IEnumerable<short> requestApplicationIds, int userId, Footprint footprint, ICollection<UpdateUser.UserApplicationObj> resultUserApplications, CancellationToken cancellationToken)
        {
            if (requestApplicationIds is null) return;

            foreach (var requestApplicationId in requestApplicationIds)
            {
                await InsertUserApplicationAsync(context, requestApplicationId, userId, footprint, resultUserApplications, cancellationToken);
            }
        }

        private static async Task InsertUserApplicationAsync(SorschiaDbContext context, short requestApplicationId, int userId, Footprint footprint, ICollection<UpdateUser.UserApplicationObj> resultUserApplications, CancellationToken cancellationToken)
        {
            var application = await context.Applications.FindAsync(new object[] { requestApplicationId }, cancellationToken);

            if (application is null)
                throw new SorschiaEntityNotFoundExceptionBuilder()
                    .WithEntityType<Application>()
                    .AddLookupField("Id", requestApplicationId)
                    .Build();

            if (await context.UserApplications.AnyAsync(_ => _.UserId == userId && _.ApplicationId == requestApplicationId, cancellationToken))
                throw new SorschiaDuplicateEntityFieldExceptionBuilder()
                    .WithEntityType<UserApplication>()
                    .AddDuplicateField("UserId", userId)
                    .AddDuplicateField("ApplicationId", requestApplicationId)
                    .Build();

            var userApplication = new UserApplication
            {
                UserId = userId,
                ApplicationId = requestApplicationId,
                Application = application
            };

            context.Add(userApplication)
                .SetInsertFootprint(footprint);
            await context.SaveChangesAsync(cancellationToken);
            resultUserApplications.Add(userApplication);
        }
        #endregion

        #region Insert User-Roles
        private static async Task InsertUserRolesAsync(SorschiaDbContext context, IEnumerable<int> requestRoleIds, int userId, Footprint footprint, ICollection<UpdateUser.UserRoleObj> resultUserRoles, CancellationToken cancellationToken)
        {
            if (requestRoleIds is null) return;

            foreach (var requestRoleId in requestRoleIds)
            {
                await InsertUserRoleAsync(context, requestRoleId, userId, footprint, resultUserRoles, cancellationToken);
            }
        }

        private static async Task InsertUserRoleAsync(SorschiaDbContext context, int requestRoleId, int userId, Footprint footprint, ICollection<UpdateUser.UserRoleObj> resultUserRoles, CancellationToken cancellationToken)
        {
            var role = await context.Roles.FindAsync(new object[] { requestRoleId }, cancellationToken);

            if (role is null)
                throw new SorschiaEntityNotFoundExceptionBuilder()
                    .WithEntityType<Role>()
                    .AddLookupField("Id", requestRoleId)
                    .Build();

            if (await context.UserRoles.AnyAsync(_ => _.UserId == userId && _.RoleId == requestRoleId, cancellationToken))
                throw new SorschiaDuplicateEntityFieldExceptionBuilder()
                    .WithEntityType<UserRole>()
                    .AddDuplicateField("UserId", userId)
                    .AddDuplicateField("RoleId", requestRoleId)
                    .Build();

            var userRole = new UserRole
            {
                UserId = userId,
                RoleId = requestRoleId,
                Role = role
            };

            context.Add(userRole)
                .SetInsertFootprint(footprint);
            await context.SaveChangesAsync(cancellationToken);
            resultUserRoles.Add(userRole);
        }
        #endregion

        #region Insert User-Permissions
        private static async Task InsertUserPermissionsAsync(SorschiaDbContext context, IEnumerable<int> requestPermissionIds, int userId, Footprint footprint, ICollection<UpdateUser.UserPermissionObj> resultUserPermissions, CancellationToken cancellationToken)
        {
            if (requestPermissionIds is null) return;

            foreach (var requestPermissionId in requestPermissionIds)
            {
                await InsertUserPermissionAsync(context, requestPermissionId, userId, footprint, resultUserPermissions, cancellationToken);
            }
        }

        private static async Task InsertUserPermissionAsync(SorschiaDbContext context, int requestPermissionId, int userId, Footprint footprint, ICollection<UpdateUser.UserPermissionObj> resultUserPermissions, CancellationToken cancellationToken)
        {
            var permission = await context.Permissions.FindAsync(new object[] { requestPermissionId }, cancellationToken);

            if (permission is null)
                throw new SorschiaEntityNotFoundExceptionBuilder()
                    .WithEntityType<Permission>()
                    .AddLookupField("Id", requestPermissionId)
                    .Build();

            if (await context.UserPermissions.AnyAsync(_ => _.UserId == userId && _.PermissionId == requestPermissionId, cancellationToken))
                throw new SorschiaDuplicateEntityFieldExceptionBuilder()
                    .WithEntityType<UserPermission>()
                    .AddDuplicateField("UserId", userId)
                    .AddDuplicateField("PermissionId", requestPermissionId)
                    .Build();

            var userPermission = new UserPermission
            {
                UserId = userId,
                PermissionId = requestPermissionId,
                Permission = permission
            };

            context.Add(userPermission)
                .SetInsertFootprint(footprint);
            await context.SaveChangesAsync(cancellationToken);
            resultUserPermissions.Add(userPermission);
        }
        #endregion

        #region Delete User-Applications
        private static async Task DeleteUserApplicationsAsync(SorschiaDbContext context, IEnumerable<long> requestDeletedUserApplicationIds, Footprint footprint, ICollection<long> resultDeletedUserApplicationIds, CancellationToken cancellationToken)
        {
            if (requestDeletedUserApplicationIds is null) return;

            foreach (var requestDeletedUserApplicationId in requestDeletedUserApplicationIds)
            {
                await DeleteUserApplicationAsync(context, requestDeletedUserApplicationId, footprint, resultDeletedUserApplicationIds, cancellationToken);
            }
        }

        private static async Task DeleteUserApplicationAsync(SorschiaDbContext context, long requestDeletedUserApplicationId, Footprint footprint, ICollection<long> resultDeletedUserApplicationIds, CancellationToken cancellationToken)
        {
            var userApplication = await context.UserApplications.FindAsync(new object[] { requestDeletedUserApplicationId }, cancellationToken);

            if (userApplication is null)
                throw new SorschiaEntityNotFoundExceptionBuilder()
                    .WithEntityType<UserApplication>()
                    .AddLookupField("Id", requestDeletedUserApplicationId)
                    .Build();

            context.Update(userApplication)
                .SoftDelete()
                .SetDeleteFootprint(footprint);
            resultDeletedUserApplicationIds.Add(requestDeletedUserApplicationId);
        }
        #endregion

        #region Delete User-Roles
        private static async Task DeleteUserRolesAsync(SorschiaDbContext context, IEnumerable<long> requestDeletedUserRoleIds, Footprint footprint, ICollection<long> resultDeletedUserRoleIds, CancellationToken cancellationToken)
        {
            if (requestDeletedUserRoleIds is null) return;

            foreach (var requestDeletedUserRoleId in requestDeletedUserRoleIds)
            {
                await DeleteUserRoleAsync(context, requestDeletedUserRoleId, footprint, resultDeletedUserRoleIds, cancellationToken);
            }
        }

        private static async Task DeleteUserRoleAsync(SorschiaDbContext context, long requestDeletedUserRoleId, Footprint footprint, ICollection<long> resultDeletedUserRoleIds, CancellationToken cancellationToken)
        {
            var userRole = await context.UserRoles.FindAsync(new object[] { requestDeletedUserRoleId }, cancellationToken);

            if (userRole is null)
                throw new SorschiaEntityNotFoundExceptionBuilder()
                    .WithEntityType<UserRole>()
                    .AddLookupField("Id", requestDeletedUserRoleId)
                    .Build();

            context.Update(userRole)
                .SoftDelete()
                .SetDeleteFootprint(footprint);
            resultDeletedUserRoleIds.Add(requestDeletedUserRoleId);
        }
        #endregion

        #region Delete User-Permissions
        private static async Task DeleteUserPermissionsAsync(SorschiaDbContext context, IEnumerable<long> requestDeletedUserPermissionIds, Footprint footprint, ICollection<long> resultDeletedUserPermissionIds, CancellationToken cancellationToken)
        {
            if (requestDeletedUserPermissionIds is null) return;

            foreach (var requestDeletedUserPermissionId in requestDeletedUserPermissionIds)
            {
                await DeleteUserPermissionAsync(context, requestDeletedUserPermissionId, footprint, resultDeletedUserPermissionIds, cancellationToken);
            }
        }

        private static async Task DeleteUserPermissionAsync(SorschiaDbContext context, long requestDeletedUserPermissionId, Footprint footprint, ICollection<long> resultDeletedUserPermissionIds, CancellationToken cancellationToken)
        {
            var userPermission = await context.UserPermissions.FindAsync(new object[] { requestDeletedUserPermissionId }, cancellationToken);

            if (userPermission is null)
                throw new SorschiaEntityNotFoundExceptionBuilder()
                    .WithEntityType<UserPermission>()
                    .AddLookupField("Id", requestDeletedUserPermissionId)
                    .Build();

            context.Update(userPermission)
                .SoftDelete()
                .SetDeleteFootprint(footprint);
            resultDeletedUserPermissionIds.Add(requestDeletedUserPermissionId);
        }
        #endregion
    }
}
