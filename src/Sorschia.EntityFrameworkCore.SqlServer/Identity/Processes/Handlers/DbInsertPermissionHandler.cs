using MediatR;
using Sorschia.Extensions;
using Sorschia.Identity.Data;
using Sorschia.Identity.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Identity.Processes.Handlers
{
    internal sealed class DbInsertPermissionHandler : IRequestHandler<DbInsertPermission, Permission>
    {
        public async Task<Permission> Handle(DbInsertPermission request, CancellationToken cancellationToken)
        {
            var context = request.TryGetContext();
            var role = await context.FindRoleAsync(request.RoleId ?? 0, cancellationToken);
            var permission = request.AsPermission(role);
            context.Permissions.AddWithFootprint(permission);
            await context.SaveChangesAsync(cancellationToken);
            return permission;
        }
    }
}
