using MediatR;
using Microsoft.EntityFrameworkCore;
using Sorschia.Auditing;
using Sorschia.ErrorHandling.Builders;
using Sorschia.Extensions;
using Sorschia.Identity.Data;
using Sorschia.Identity.Entities;
using Sorschia.Identity.Processing.Requests;
using Sorschia.Utilities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Identity.Processing.Handlers
{
    internal sealed class InsertRolePermissionHandler : IRequestHandler<InsertRolePermissionRequest, RolePermission>
    {
        private readonly IResourceManager _resourceManager;

        public InsertRolePermissionHandler(IResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }

        public async Task<RolePermission> Handle(InsertRolePermissionRequest request, CancellationToken cancellationToken)
        {
            var resourceContext = _resourceManager.GetContext(request);
            var context = resourceContext.GetIdentityContext();
            var currentFootprint = resourceContext.GetCurrentFootprint();
            var role = request.Role ?? await context.FindRoleAsync(request.RoleId, cancellationToken);
            var permission = request.Permission ?? await context.FindPermissionAsync(request.PermissionId, cancellationToken);

            if (await context.RolePermissions.Where(_ => _.RoleId == request.RoleId && _.PermissionId == request.PermissionId).AnyAsync(cancellationToken))
                throw new DuplicateEntityExceptionBuilder()
                    .WithEntityType<RolePermission>()
                    .WithMessage("Role-Permission already exists")
                    .WithDebugMessage($"Role-Permission with RoleId = {request.RoleId}, PermissionId = {request.PermissionId} already exists")
                    .AddField(nameof(RolePermission.RoleId), request.RoleId)
                    .AddField(nameof(RolePermission.PermissionId), request.PermissionId)
                    .Build();

            var rolePermission = request.AsRolePermission();
            rolePermission.Role = role;
            rolePermission.Permission = permission;
            context.RolePermissions.Add(rolePermission, currentFootprint);
            await context.SaveChangesAsync(cancellationToken);
            return rolePermission;
        }
    }
}
