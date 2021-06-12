using MediatR;
using Microsoft.EntityFrameworkCore;
using Sorschia.Auditing;
using Sorschia.Identity.Data;
using Sorschia.Identity.Entities;
using Sorschia.Identity.Processing.Requests;
using Sorschia.Identity.Processing.Responses;
using Sorschia.Utilities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Identity.Processing.Handlers
{
    internal sealed class AddUserHandler : IRequestHandler<AddUserRequest, AddUserResponse>
    {
        private readonly IMediator _mediator;
        private readonly IResourceManager _resourceManager;
        private readonly IDbContextFactory<IdentityContext> _contextFactory;
        private readonly ICurrentFootprintProvider _currentFootprintProvider;

        public AddUserHandler(IMediator mediator, IResourceManager resourceManager, IDbContextFactory<IdentityContext> contextFactory, ICurrentFootprintProvider currentFootprintProvider)
        {
            _mediator = mediator;
            _resourceManager = resourceManager;
            _contextFactory = contextFactory;
            _currentFootprintProvider = currentFootprintProvider;
        }

        public async Task<AddUserResponse> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
            using var context = _contextFactory.CreateDbContext();
            using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);
            using var resourceContext = _resourceManager.CreateContext()
                .SetIdentityContext(context)
                .SetCurrentFootprint(_currentFootprintProvider.Current);
            var response = new AddUserResponse();
            var user = await InsertUserAsync(resourceContext, request, cancellationToken);
            response.From(user);
            response.UserRoles = await InsertUserRolesAsync(resourceContext, user, request.RoleIds, cancellationToken);
            response.UserPermissions = await InsertUserPermissionsAsync(resourceContext, user, request.PermissionIds, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return response;
        }

        private async Task<User> InsertUserAsync(IResourceContext resourceContext, AddUserRequest request, CancellationToken cancellationToken)
        {
            var insertUserRequest = new InsertUserRequest
            {
                Username = request.Username,
                Password = request.Password,
                Status = request.Status
            };

            resourceContext.AttachConsumer(insertUserRequest);
            return await _mediator.Send(insertUserRequest, cancellationToken);
        }

        private async Task<IEnumerable<AddUserResponse.UserRoleObj>> InsertUserRolesAsync(IResourceContext resourceContext, User user, IEnumerable<int> roleIds, CancellationToken cancellationToken)
        {
            if (roleIds is null)
                return null;

            var userRoles = new List<AddUserResponse.UserRoleObj>();

            foreach (var roleId in roleIds)
                userRoles.Add(await InsertUserRoleAsync(resourceContext, user, roleId, cancellationToken));

            return userRoles;
        }

        private async Task<AddUserResponse.UserRoleObj> InsertUserRoleAsync(IResourceContext resourceContext, User user, int roleId, CancellationToken cancellationToken)
        {
            var insertUserRoleRequest = new InsertUserRoleRequest
            {
                User = user,
                UserId = user.Id,
                RoleId = roleId
            };
            resourceContext.AttachConsumer(insertUserRoleRequest);
            return await _mediator.Send(insertUserRoleRequest, cancellationToken);
        }

        private async Task<IEnumerable<AddUserResponse.UserPermissionObj>> InsertUserPermissionsAsync(IResourceContext resourceContext, User user, IEnumerable<int> permissionIds, CancellationToken cancellationToken)
        {
            if (permissionIds is null)
                return null;

            var userPermissions = new List<AddUserResponse.UserPermissionObj>();

            foreach (var permissionId in permissionIds)
                userPermissions.Add(await InsertUserPermissionAsync(resourceContext, user, permissionId, cancellationToken));

            return userPermissions;
        }

        private async Task<AddUserResponse.UserPermissionObj> InsertUserPermissionAsync(IResourceContext resourceContext, User user, int permissionId, CancellationToken cancellationToken)
        {
            var insertUserPermissionRequest = new InsertUserPermissionRequest
            {
                User = user,
                UserId = user.Id,
                PermissionId = permissionId
            };
            resourceContext.AttachConsumer(insertUserPermissionRequest);
            return await _mediator.Send(insertUserPermissionRequest, cancellationToken);
        }
    }
}
