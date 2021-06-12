using MediatR;
using Microsoft.EntityFrameworkCore;
using Sorschia.Auditing;
using Sorschia.Identity.Data;
using Sorschia.Identity.Processing.Requests;
using Sorschia.Identity.Processing.Responses;
using Sorschia.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Identity.Processing.Handlers
{
    internal sealed class AddRoleHandler : IRequestHandler<AddRoleRequest, AddRoleResponse>
    {
        private readonly IMediator _mediator;
        private readonly IResourceManager _resourceManager;
        private readonly IDbContextFactory<IdentityContext> _contextFactory;
        private readonly ICurrentFootprintProvider _currentFootprintProvider;

        public AddRoleHandler(IMediator mediator, IResourceManager resourceManager, IDbContextFactory<IdentityContext> contextFactory, ICurrentFootprintProvider currentFootprintProvider)
        {
            _mediator = mediator;
            _resourceManager = resourceManager;
            _contextFactory = contextFactory;
            _currentFootprintProvider = currentFootprintProvider;
        }

        public async Task<AddRoleResponse> Handle(AddRoleRequest request, CancellationToken cancellationToken)
        {
            using var context = _contextFactory.CreateDbContext();
            using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);
            var insertRoleRequest = request.AsInsertRoleRequest();
            using var resourceContext = _resourceManager.CreateContext()
                .SetIdentityContext(context)
                .SetCurrentFootprint(_currentFootprintProvider.Current)
                .AttachConsumer(insertRoleRequest);
            var response = new AddRoleResponse();
            var role = await _mediator.Send(insertRoleRequest, cancellationToken);
            response.From(role);

            if (request.PermissionIds is not null && request.PermissionIds.Any())
            {
                var rolePermissions = new List<AddRoleResponse.RolePermissionObj>();

                foreach (var permissionId in request.PermissionIds)
                {
                    var insertRolePermissionRequest = new InsertRolePermissionRequest
                    {
                        Role = role,
                        RoleId = role.Id,
                        PermissionId = permissionId
                    };

                    resourceContext.AttachConsumer(insertRolePermissionRequest);
                    var rolePermission = await _mediator.Send(insertRolePermissionRequest, cancellationToken);
                    rolePermissions.Add(rolePermission);
                }

                response.RolePermissions = rolePermissions;
            }

            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return response;
        }
    }
}
