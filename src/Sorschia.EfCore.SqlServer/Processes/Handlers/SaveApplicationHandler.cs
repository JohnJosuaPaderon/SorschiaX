﻿using MediatR;
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
    internal sealed class SaveApplicationHandler : IRequestHandler<SaveApplication, SaveApplication.Result>
    {
        private readonly IDbContextFactory<SorschiaDbContext> _contextFactory;
        private readonly ICurrentFootprintProvider _currentFootprintProvider;

        public SaveApplicationHandler(IDbContextFactory<SorschiaDbContext> contextFactory, ICurrentFootprintProvider currentFootprintProvider)
        {
            _contextFactory = contextFactory;
            _currentFootprintProvider = currentFootprintProvider;
        }

        public async Task<SaveApplication.Result> Handle(SaveApplication request, CancellationToken cancellationToken)
        {
            using var context = _contextFactory.CreateDbContext();
            using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);
            var result = new SaveApplication.Result();
            var footprint = _currentFootprintProvider.Current;
            await SaveApplicationAsync(context, request, footprint, result, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return result;
        }

        #region Save Application
        private static async Task SaveApplicationAsync(SorschiaDbContext context, SaveApplication request, Footprint footprint, SaveApplication.Result result, CancellationToken cancellationToken)
        {
            if (await context.Applications.AnyAsync(_ => _.Id != request.Id && _.Name == request.Name, cancellationToken))
                throw new SorschiaDuplicateEntityFieldExceptionBuilder()
                    .WithEntityType<Application>()
                    .AddDuplicateField("Name", request.Name)
                    .Build();

            Application application;

            if (request.Id == 0)
                application = await InsertApplicationAsync(context, request, footprint, cancellationToken);
            else
                application = await UpdateApplicationAsync(context, request, footprint, cancellationToken);

            result.FromSource(application);
            await SaveRolesAsync(context, request.Roles, application.Id, footprint, result.Roles, cancellationToken);
            await SavePermissionsAsync(context, request.Permissions, application.Id, null, footprint, result.Permissions, cancellationToken);
            await DeleteRolesAsync(context, request.DeletedRoleIds, footprint, result.DeletedRoleIds, cancellationToken);
            await DeletePermissionsAsync(context, request.DeletedPermissionIds, footprint, result.DeletedPermissionIds, cancellationToken);
        }

        private static async Task<Application> InsertApplicationAsync(SorschiaDbContext context, SaveApplication request, Footprint footprint, CancellationToken cancellationToken)
        {
            var application = request.ToSource();
            context.Add(application)
                .SetInsertFootprint(footprint);
            await context.SaveChangesAsync(cancellationToken);
            return application;
        }

        private static async Task<Application> UpdateApplicationAsync(SorschiaDbContext context, SaveApplication request, Footprint footprint, CancellationToken cancellationToken)
        {
            var application = await context.Applications.FindAsync(new object[] { request.Id }, cancellationToken);

            if (application is null)
                throw new SorschiaEntityNotFoundExceptionBuilder()
                    .WithEntityType<Application>()
                    .AddLookupField("Id", request.Id)
                    .Build();

            if (application.HasChanges(request))
            {
                application.FromRequest(request);
                context.Update(application)
                    .SetUpdateFootprint(footprint);
            }

            return application;
        }
        #endregion

        #region Save Roles
        private static async Task SaveRolesAsync(SorschiaDbContext context, IEnumerable<SaveApplication.RoleObj> requestRoles, short? applicationId, Footprint footprint, ICollection<SaveApplication.RoleObj> resultRoles, CancellationToken cancellationToken)
        {
            if (requestRoles is null) return;

            foreach (var requestRole in requestRoles)
            {
                await SaveRoleAsync(context, requestRole, applicationId, footprint, resultRoles, cancellationToken);
            }
        }

        private static async Task SaveRoleAsync(SorschiaDbContext context, SaveApplication.RoleObj requestRole, short? applicationId, Footprint footprint, ICollection<SaveApplication.RoleObj> resultRoles, CancellationToken cancellationToken)
        {

            if (await context.Roles.AnyAsync(_ => _.Id != requestRole.Id && _.ApplicationId == applicationId && _.Name == requestRole.Name, cancellationToken))
                throw new SorschiaDuplicateEntityFieldExceptionBuilder()
                    .WithEntityType<Role>()
                    .AddDuplicateField("ApplicationId", applicationId)
                    .AddDuplicateField("Name", requestRole.Name)
                    .Build();

            Role role;
            var resultRole = new SaveApplication.RoleObj();

            if (requestRole.Id == 0)
                role = await InsertRoleAsync(context, requestRole, applicationId, footprint, cancellationToken);
            else
                role = await UpdateRoleAsync(context, requestRole, applicationId, footprint, cancellationToken);

            resultRole.FromSource(role);
            await SavePermissionsAsync(context, requestRole.Permissions, null, role.Id, footprint, resultRole.Permissions, cancellationToken);
            await DeletePermissionsAsync(context, requestRole.DeletedPermissionIds, footprint, resultRole.DeletedPermissionIds, cancellationToken);
            resultRoles.Add(resultRole);
        }

        private static async Task<Role> InsertRoleAsync(SorschiaDbContext context, SaveApplication.RoleObj requestRole, short? applicationId, Footprint Footprint, CancellationToken cancellationToken)
        {
            var role = requestRole.ToSource();
            context.Add(role)
                .SetInsertFootprint(Footprint);
            await context.SaveChangesAsync(cancellationToken);
            return role;
        }

        private static async Task<Role> UpdateRoleAsync(SorschiaDbContext context, SaveApplication.RoleObj requestRole, short? applicationId, Footprint footprint, CancellationToken cancellationToken)
        {
            var role = await context.Roles.FindAsync(new object[] { requestRole.Id }, cancellationToken);

            if (role is null)
                throw new SorschiaEntityNotFoundExceptionBuilder()
                    .WithEntityType<Role>()
                    .AddLookupField("Id", requestRole.Id)
                    .Build();

            if (role.HasChanges(requestRole, applicationId))
            {
                role.FromRequest(requestRole, applicationId);
                context.Update(role)
                    .SetUpdateFootprint(footprint);
            }

            return role;
        }
        #endregion

        #region Delete Roles
        private static async Task DeleteRolesAsync(SorschiaDbContext context, IEnumerable<int> requestDeletedRoleIds, Footprint footprint, ICollection<int> resultDeletedRoleIds, CancellationToken cancellationToken)
        {
            if (requestDeletedRoleIds is null) return;

            foreach (var requestDeletedRoleId in requestDeletedRoleIds)
            {
                await DeleteRoleAsync(context, requestDeletedRoleId, footprint, resultDeletedRoleIds, cancellationToken);
            }
        }

        private static async Task DeleteRoleAsync(SorschiaDbContext context, int requestDeletedRoleId, Footprint footprint, ICollection<int> resultDeletedRoleIds, CancellationToken cancellationToken)
        {
            var role = await context.Roles.FindAsync(new object[] { requestDeletedRoleId }, cancellationToken);

            if (role is null)
                throw new SorschiaEntityNotFoundExceptionBuilder()
                    .WithEntityType<Role>()
                    .AddLookupField("Id", requestDeletedRoleId)
                    .Build();

            context.Update(role)
                .SoftDelete()
                .SetDeleteFootprint(footprint);

            resultDeletedRoleIds.Add(role.Id);
        }
        #endregion

        #region Save Permissions
        private static async Task SavePermissionsAsync(SorschiaDbContext context, IEnumerable<SaveApplication.PermissionObj> requestPermissions, short? applicationId, int? roleId, Footprint footprint, ICollection<SaveApplication.PermissionObj> resultPermissions, CancellationToken cancellationToken)
        {
            if (requestPermissions is null) return;

            foreach (var requestPermission in requestPermissions)
            {
                await SavePermissionAsync(context, requestPermission, applicationId, roleId, footprint, resultPermissions, cancellationToken);
            }
        }

        private static async Task SavePermissionAsync(SorschiaDbContext context, SaveApplication.PermissionObj requestPermission, short? applicationId, int? roleId, Footprint footprint, ICollection<SaveApplication.PermissionObj> resultPermissions, CancellationToken cancellationToken)
        {
            if (await context.Permissions.AnyAsync(_ => _.Id != requestPermission.Id && _.ApplicationId == applicationId && _.RoleId == roleId && _.Name == requestPermission.Name, cancellationToken))
                throw new SorschiaDuplicateEntityFieldExceptionBuilder()
                    .WithEntityType<Permission>()
                    .AddDuplicateField("ApplicationId", applicationId)
                    .AddDuplicateField("RoleId", roleId)
                    .AddDuplicateField("Name", requestPermission.Name)
                    .Build();

            Permission permission;
            var resultPermission = new SaveApplication.PermissionObj();

            if (requestPermission.Id == 0)
                permission = await InsertPermissionAsync(context, requestPermission, applicationId, roleId, footprint, cancellationToken);
            else
                permission = await UpdatePermissionAsync(context, requestPermission, applicationId, roleId, footprint, cancellationToken);

            resultPermission.FromSource(permission);
            await SavePermissionAspNetRoutesAsync(context, requestPermission.AspNetRoutes, permission.Id, footprint, requestPermission.AspNetRoutes, cancellationToken);
            await DeletePermissionAspNetRoutesAsync(context, requestPermission.DeletedAspNetRouteIds, footprint, requestPermission.DeletedAspNetRouteIds, cancellationToken);
            resultPermissions.Add(resultPermission);
        }

        private static async Task<Permission> InsertPermissionAsync(SorschiaDbContext context, SaveApplication.PermissionObj requestPermission, short? applicationId, int? roleId, Footprint footprint, CancellationToken cancellationToken)
        {
            var permission = requestPermission.ToSource(applicationId, roleId);
            context.Add(permission)
                .SetInsertFootprint(footprint);
            await context.SaveChangesAsync(cancellationToken);
            return permission;
        }

        private static async Task<Permission> UpdatePermissionAsync(SorschiaDbContext context, SaveApplication.PermissionObj requestPermission, short? applicationId, int? roleId, Footprint footprint, CancellationToken cancellationToken)
        {
            var permission = await context.Permissions.FindAsync(new object[] { requestPermission.Id }, cancellationToken);

            if (permission is null)
                throw new SorschiaEntityNotFoundExceptionBuilder()
                    .WithEntityType<Permission>()
                    .AddLookupField("Id", requestPermission.Id)
                    .Build();

            if (permission.HasChanges(requestPermission, applicationId, roleId))
            {
                permission.FromRequest(requestPermission, applicationId, roleId);
                context.Update(permission)
                    .SetUpdateFootprint(footprint);
            }

            return permission;
        }
        #endregion

        #region Delete Permissions
        private static async Task DeletePermissionsAsync(SorschiaDbContext context, IEnumerable<int> requestDeletedPermissionIds, Footprint footprint, ICollection<int> resultDeletedPermissionIds, CancellationToken cancellationToken)
        {
            if (requestDeletedPermissionIds is null) return;

            foreach (var requestDeletedPermissionId in requestDeletedPermissionIds)
            {
                await DeletePermissionAsync(context, requestDeletedPermissionId, footprint, resultDeletedPermissionIds, cancellationToken);
            }
        }

        private static async Task DeletePermissionAsync(SorschiaDbContext context, int requestDeletedPermissionId, Footprint footprint, ICollection<int> resultDeletedPermissionIds, CancellationToken cancellationToken)
        {
            var permission = await context.Permissions.FindAsync(new object[] { requestDeletedPermissionId }, cancellationToken);

            if (permission is null)
                throw new SorschiaEntityNotFoundExceptionBuilder()
                    .WithEntityType<Permission>()
                    .AddLookupField("Id", requestDeletedPermissionId)
                    .Build();

            context.Update(permission)
                .SoftDelete()
                .SetDeleteFootprint(footprint);

            resultDeletedPermissionIds.Add(permission.Id);
        }
        #endregion

        #region Save Permission ASP.NET Routes
        private static async Task SavePermissionAspNetRoutesAsync(SorschiaDbContext context, IEnumerable<SaveApplication.PermissionAspNetRouteObj> requestPermissionAspNetRoutes, int permissionId, Footprint footprint, ICollection<SaveApplication.PermissionAspNetRouteObj> resultPermissionAspNetRoutes, CancellationToken cancellationToken)
        {
            if (requestPermissionAspNetRoutes is null) return;

            foreach (var requestPermissionAspNetRoute in requestPermissionAspNetRoutes)
            {
                await SavePermissionAspNetRouteAsync(context, requestPermissionAspNetRoute, permissionId, footprint, resultPermissionAspNetRoutes, cancellationToken);
            }
        }

        private static async Task SavePermissionAspNetRouteAsync(SorschiaDbContext context, SaveApplication.PermissionAspNetRouteObj requestPermissionAspNetRoute, int permissionId, Footprint footprint, ICollection<SaveApplication.PermissionAspNetRouteObj> resultPermissionAspNetRoutes, CancellationToken cancellationToken)
        {
            if (await context.PermissionAspNetRoutes.AnyAsync(_ => _.Id != requestPermissionAspNetRoute.Id && _.PermissionId == permissionId && _.AspNetArea == requestPermissionAspNetRoute.AspNetArea && _.AspNetController == requestPermissionAspNetRoute.AspNetController && _.AspNetAction == requestPermissionAspNetRoute.AspNetAction, cancellationToken))
                throw new SorschiaDuplicateEntityFieldExceptionBuilder()
                    .WithEntityType<PermissionAspNetRoute>()
                    .AddDuplicateField("PermissionId", permissionId)
                    .AddDuplicateField("AspNetArea", requestPermissionAspNetRoute.AspNetArea)
                    .AddDuplicateField("AspNetController", requestPermissionAspNetRoute.AspNetController)
                    .AddDuplicateField("AspNetAction", requestPermissionAspNetRoute.AspNetAction)
                    .Build();

            PermissionAspNetRoute permissionAspNetRoute;

            if (requestPermissionAspNetRoute.Id == 0)
                permissionAspNetRoute = await InsertPermissionAspNetRouteAsync(context, requestPermissionAspNetRoute, permissionId, footprint, cancellationToken);
            else
                permissionAspNetRoute = await UpdatePermissionAspNetRouteAsync(context, requestPermissionAspNetRoute, permissionId, footprint, cancellationToken);

            resultPermissionAspNetRoutes.Add(permissionAspNetRoute);
        }

        private static async Task<PermissionAspNetRoute> InsertPermissionAspNetRouteAsync(SorschiaDbContext context, SaveApplication.PermissionAspNetRouteObj requestPermissionAspNetRoute, int permissionId, Footprint footprint, CancellationToken cancellationToken)
        {
            var permissionAspNetRoute = requestPermissionAspNetRoute.ToSource(permissionId);
            context.Add(permissionAspNetRoute)
                .SetInsertFootprint(footprint);
            await context.SaveChangesAsync(cancellationToken);
            return permissionAspNetRoute;
        }

        private static async Task<PermissionAspNetRoute> UpdatePermissionAspNetRouteAsync(SorschiaDbContext context, SaveApplication.PermissionAspNetRouteObj requestPermissionAspNetRoute, int permissionId, Footprint footprint, CancellationToken cancellationToken)
        {
            var permissionAspNetRoute = await context.PermissionAspNetRoutes.FindAsync(new object[] { requestPermissionAspNetRoute.Id }, cancellationToken);

            if (permissionAspNetRoute is null)
                throw new SorschiaEntityNotFoundExceptionBuilder()
                    .WithEntityType<PermissionAspNetRoute>()
                    .AddLookupField("Id", requestPermissionAspNetRoute.Id)
                    .Build();

            if (permissionAspNetRoute.HasChanges(requestPermissionAspNetRoute, permissionId))
            {
                permissionAspNetRoute.FromRequest(requestPermissionAspNetRoute, permissionId);
                context.Update(permissionAspNetRoute)
                    .SetUpdateFootprint(footprint);
            }

            return permissionAspNetRoute;
        }
        #endregion

        #region Delete Permission ASP.NET Routes
        private static async Task DeletePermissionAspNetRoutesAsync(SorschiaDbContext context, IEnumerable<long> requestDeletedPermissionAspNetRouteIds, Footprint footprint, ICollection<long> resultDeletedPermissionAspNetRouteIds, CancellationToken cancellationToken)
        {
            if (requestDeletedPermissionAspNetRouteIds is null) return;

            foreach (var requestDeletedPermissionAspNetRouteId in requestDeletedPermissionAspNetRouteIds)
            {
                await DeletePermissionAspNetRouteAsync(context, requestDeletedPermissionAspNetRouteId, footprint, resultDeletedPermissionAspNetRouteIds, cancellationToken);
            }
        }

        private static async Task DeletePermissionAspNetRouteAsync(SorschiaDbContext context, long requestDeletedPermissionAspNetRouteId, Footprint footprint, ICollection<long> resultDeletedPermissionAspNetRouteIds, CancellationToken cancellationToken)
        {
            var permissionAspNetRoute = await context.PermissionAspNetRoutes.FindAsync(new object[] { requestDeletedPermissionAspNetRouteId }, cancellationToken);

            if (permissionAspNetRoute is null)
                throw new SorschiaEntityNotFoundExceptionBuilder()
                    .WithEntityType<PermissionAspNetRoute>()
                    .AddLookupField("Id", requestDeletedPermissionAspNetRouteId)
                    .Build();

            context.Update(permissionAspNetRoute)
                .SoftDelete()
                .SetDeleteFootprint(footprint);
            resultDeletedPermissionAspNetRouteIds.Add(permissionAspNetRoute.Id);
        }
        #endregion
    }
}
