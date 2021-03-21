using MediatR;
using Microsoft.EntityFrameworkCore;
using Sorschia.Data;
using Sorschia.Entities;
using Sorschia.Extensions;
using Sorschia.Security;
using Sorschia.Utilities;
using Sorschia.Utilities.ExceptionBuilders;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Processes.Handlers
{
    internal sealed class InsertUserHandler : IRequestHandler<InsertUser, InsertUser.Result>
    {
        private readonly IDbContextFactory<SorschiaDbContext> _contextFactory;
        private readonly ICurrentFootprintProvider _currentFootprintProvider;
        private readonly IFullNameBuilder _fullNameBuilder;
        private readonly IUserPasswordTransformer _userPasswordTransformer;

        public InsertUserHandler(IDbContextFactory<SorschiaDbContext> contextFactory, ICurrentFootprintProvider currentFootprintProvider, IFullNameBuilder fullNameBuilder, IUserPasswordTransformer userPasswordTransformer)
        {
            _contextFactory = contextFactory;
            _currentFootprintProvider = currentFootprintProvider;
            _fullNameBuilder = fullNameBuilder;
            _userPasswordTransformer = userPasswordTransformer;
        }

        public async Task<InsertUser.Result> Handle(InsertUser request, CancellationToken cancellationToken)
        {
            using var context = _contextFactory.CreateDbContext();
            using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);
            var result = new InsertUser.Result();
            var footprint = _currentFootprintProvider.Current;
            await InsertUserAsync(context, request, footprint, result, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return result;
        }

        #region Insert User
        private async Task InsertUserAsync(SorschiaDbContext context, InsertUser request, Footprint footprint, InsertUser.Result result, CancellationToken cancellationToken)
        {
            var user = new User
            {
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                NameSuffix = request.NameSuffix,
                FullName = _fullNameBuilder.Build(request.FirstName, request.MiddleName, request.LastName, request.NameSuffix),
                Username = request.Username,
                EmailAddress = request.EmailAddress,
                MobileNumber = request.MobileNumber,
                IsActive = request.IsActive,
                IsPasswordChangeRequired = request.IsPasswordChangeRequired,
                IsEmailAddressVerified = request.IsEmailAddressVerified,
                IsMobileNumberVerified = request.IsMobileNumberVerified
            };

            if (await context.Users.AnyAsync(_ => _.Username == request.Username, cancellationToken))
                throw new SorschiaDuplicateEntityFieldExceptionBuilder()
                    .WithEntityType<User>()
                    .AddDuplicateFields("Username", request.Username)
                    .Build();

            context.Entry(user)
                .SetSecurePassword(_userPasswordTransformer.ToSecurePassword(request.Password))
                .SetInsertFootprint(footprint);
            await context.AddAsync(user, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            await InsertUserApplicationsAsync(context, request.ApplicationIds, user.Id, footprint, result.UserApplications, cancellationToken);
            await InsertUserRolesAsync(context, request.RoleIds, user.Id, footprint, result.UserRoles, cancellationToken);
            await InsertUserPermissionsAsync(context, request.PermissionIds, user.Id, footprint, result.UserPermissions, cancellationToken);

            result.Id = user.Id;
            result.FirstName = user.FirstName;
            result.MiddleName = user.MiddleName;
            result.LastName = user.LastName;
            result.NameSuffix = user.NameSuffix;
            result.FullName = user.Username;
            result.Username = user.Username;
            result.EmailAddress = user.EmailAddress;
            result.MobileNumber = user.MobileNumber;
            result.IsActive = user.IsActive;
            result.IsPasswordChangeRequired = user.IsPasswordChangeRequired;
            result.IsEmailAddressVerified = user.IsEmailAddressVerified;
            result.IsMobileNumberVerified = user.IsMobileNumberVerified;
        }
        #endregion

        #region Insert User-Applications
        private static async Task InsertUserApplicationsAsync(SorschiaDbContext context, IEnumerable<short> requestApplicationIds, int userId, Footprint footprint, ICollection<InsertUser.UserApplicationObj> resultUserApplications, CancellationToken cancellationToken)
        {
            if (requestApplicationIds is null) return;

            foreach (var requestApplicationId in requestApplicationIds)
            {
                await InsertUserApplicationAsync(context, requestApplicationId, userId, footprint, resultUserApplications, cancellationToken);
            }
        }

        private static async Task InsertUserApplicationAsync(SorschiaDbContext context, short requestApplicationId, int userId, Footprint footprint, ICollection<InsertUser.UserApplicationObj> resultUserApplications, CancellationToken cancellationToken)
        {
            var application = await context.Applications.FindAsync(new object[] { requestApplicationId }, cancellationToken);

            if (application is null)
                throw new SorschiaEntityNotFoundExceptionBuilder()
                    .WithEntityType<Application>()
                    .AddLookupParameter("requestApplicationId", requestApplicationId)
                    .Build();

            if (await context.UserApplications.AnyAsync(_ => _.UserId == userId && _.ApplicationId == application.Id, cancellationToken))
                throw new SorschiaDuplicateEntityFieldExceptionBuilder()
                    .WithEntityType<UserApplication>()
                    .AddDuplicateFields("UserId", userId)
                    .AddDuplicateFields("ApplicationId", application.Id)
                    .Build();

            var userApplication = new UserApplication
            {
                UserId = userId,
                ApplicationId = application.Id
            };

            context.Entry(userApplication).SetInsertFootprint(footprint);
            await context.AddAsync(userApplication, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            resultUserApplications.Add(new InsertUser.UserApplicationObj
            {
                Id = userApplication.Id,
                Application = new InsertUser.ApplicationObj
                {
                    Id = application.Id,
                    Name = application.Name,
                    Description = application.Description
                }
            });
        }
        #endregion

        #region Insert User-Roles
        private static async Task InsertUserRolesAsync(SorschiaDbContext context, IEnumerable<int> requestRoleIds, int userId, Footprint footprint, ICollection<InsertUser.UserRoleObj> resultUserRoles, CancellationToken cancellationToken)
        {
            if (requestRoleIds is null) return;

            foreach (var requestRoleId in requestRoleIds)
            {
                await InsertUserRoleAsync(context, requestRoleId, userId, footprint, resultUserRoles, cancellationToken);
            }
        }

        private static async Task InsertUserRoleAsync(SorschiaDbContext context, int requestRoleId, int userId, Footprint footprint, ICollection<InsertUser.UserRoleObj> resultUserRoles, CancellationToken cancellationToken)
        {
            var role = await context.Roles.FindAsync(new object[] { requestRoleId }, cancellationToken);

            if (role is null)
                throw new SorschiaEntityNotFoundExceptionBuilder()
                    .WithEntityType<Role>()
                    .AddLookupParameter("requestRoleId", requestRoleId)
                    .Build();

            if (await context.UserRoles.AnyAsync(_ => _.UserId == userId && _.RoleId == role.Id, cancellationToken))
                throw new SorschiaDuplicateEntityFieldExceptionBuilder()
                    .WithEntityType<UserRole>()
                    .AddDuplicateFields("UserId", userId)
                    .AddDuplicateFields("RoleId", role.Id)
                    .Build();

            var userRole = new UserRole
            {
                UserId = userId,
                RoleId = role.Id
            };

            context.Entry(userRole).SetInsertFootprint(footprint);
            await context.AddAsync(userRole, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            resultUserRoles.Add(new InsertUser.UserRoleObj
            {
                Id = userRole.Id,
                Role = new InsertUser.RoleObj
                {
                    Id = role.Id,
                    Name = role.Name,
                    Description = role.Description
                }
            });
        }
        #endregion

        #region Insert User-Permissions
        private static async Task InsertUserPermissionsAsync(SorschiaDbContext context, IEnumerable<int> requestPermissionIds, int userId, Footprint footprint, ICollection<InsertUser.UserPermissionObj> resultUserPermissions, CancellationToken cancellationToken)
        {
            if (requestPermissionIds is null) return;

            foreach (var requestPermissionId in requestPermissionIds)
            {
                await InsertUserPermissionAsync(context, requestPermissionId, userId, footprint, resultUserPermissions, cancellationToken);
            }
        }

        private static async Task InsertUserPermissionAsync(SorschiaDbContext context, int requestPermissionId, int userId, Footprint footprint, ICollection<InsertUser.UserPermissionObj> resultUserPermissions, CancellationToken cancellationToken)
        {
            var permission = await context.Permissions.FindAsync(new object[] { requestPermissionId }, cancellationToken);

            if (permission is null)
                throw new SorschiaEntityNotFoundExceptionBuilder()
                    .WithEntityType<Permission>()
                    .AddLookupParameter("requestPermissionId", requestPermissionId)
                    .Build();

            if (await context.UserPermissions.AnyAsync(_ => _.UserId == userId && _.PermissionId == permission.Id, cancellationToken))
                throw new SorschiaDuplicateEntityFieldExceptionBuilder()
                    .WithEntityType<UserPermission>()
                    .AddDuplicateFields("UserId", userId)
                    .AddDuplicateFields("PermissionId", permission.Id)
                    .Build();

            var userPermission = new UserPermission
            {
                UserId = userId,
                PermissionId = permission.Id
            };

            context.Entry(userPermission).SetInsertFootprint(footprint);
            await context.AddAsync(userPermission, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            resultUserPermissions.Add(new InsertUser.UserPermissionObj
            {
                Id = userPermission.Id,
                Permission = new InsertUser.PermissionObj
                {
                    Id = permission.Id,
                    Name = permission.Name,
                    Description = permission.Description
                }
            });
        }
        #endregion
    }
}
