﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Sorschia.Identity.Data;
using Sorschia.Identity.Entities;
using Sorschia.Identity.Processes.Results;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Identity.Processes.Handlers
{
    internal sealed class InsertUserHandler : IRequestHandler<InsertUser, InsertUserResult>
    {
        private readonly IDbContextFactory<IdentityContext> _contextFactory;
        private readonly IMediator _mediator;

        public InsertUserHandler(IDbContextFactory<IdentityContext> contextFactory, IMediator mediator)
        {
            _contextFactory = contextFactory;
            _mediator = mediator;
        }

        public async Task<InsertUserResult> Handle(InsertUser request, CancellationToken cancellationToken)
        {
            using var context = _contextFactory.CreateDbContext();
            using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);
            var result = new InsertUserResult();
            var user = await _mediator.Send(request.AsDbInsertUser(context), cancellationToken);
            result.Set(user);
            await InsertUserRolesAsync(context, user, request.RoleIds, result, cancellationToken);
            await InsertUserPermissionsAsync(context, user, request.PermissionIds, result, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return result;
        }

        private async Task InsertUserRolesAsync(IdentityContext context, User user, IEnumerable<int> roleIds, InsertUserResult result, CancellationToken cancellationToken)
        {
            if (roleIds is null)
                return;

            var userRoles = new List<InsertUserResult.UserRoleObj>();

            foreach (var roleId in roleIds)
            {
                await InsertUserRoleAsync(context, user, roleId, userRoles, cancellationToken);
            }

            result.UserRoles = userRoles;
        }

        private async Task InsertUserRoleAsync(IdentityContext context, User user, int roleId, IList<InsertUserResult.UserRoleObj> userRoles, CancellationToken cancellationToken)
        {
            var role = await context.FindRoleAsync(roleId, cancellationToken);
            var userRole = await _mediator.Send(new DbInsertUserRole(context)
            {
                UserId = user.Id,
                RoleId = roleId
            }, cancellationToken);

            userRoles.Add(new InsertUserResult.UserRoleObj().Set(userRole.Id, role));
        }

        private async Task InsertUserPermissionsAsync(IdentityContext context, User user, IEnumerable<int> permissionIds, InsertUserResult result, CancellationToken cancellationToken)
        {
            if (permissionIds is null)
                return;

            var userPermissions = new List<InsertUserResult.UserPermissionObj>();

            foreach (var permissionId in permissionIds)
            {
                await InsertUserPermissionAsync(context, user, permissionId, userPermissions, cancellationToken);
            }
        }

        private async Task InsertUserPermissionAsync(IdentityContext context, User user, int permissionId, List<InsertUserResult.UserPermissionObj> userPermissions, CancellationToken cancellationToken)
        {
            var permission = await context.FindPermissionAsync(permissionId, cancellationToken);
            var userPermission = await _mediator.Send(new DbInsertUserPermission(context)
            {
                UserId = user.Id,
                PermissionId = permissionId
            }, cancellationToken);

            userPermissions.Add(new InsertUserResult.UserPermissionObj().Set(userPermission.Id, permission));
        }
    }
}