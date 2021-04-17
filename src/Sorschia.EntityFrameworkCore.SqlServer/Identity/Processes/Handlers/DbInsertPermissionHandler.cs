using MediatR;
using Microsoft.EntityFrameworkCore;
using Sorschia.Entities.Exceptions.Builders;
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
            var role = request.Role ?? await context.FindRoleAsync(request.RoleId ?? 0, cancellationToken);

            if (!string.IsNullOrEmpty(request.LookupCode) && await context.Permissions.AnyAsync(_ => _.LookupCode == request.LookupCode, cancellationToken))
                throw new DuplicateEntityFieldExceptionBuilder()
                    .WithEntityType<Permission>()
                    .WithMessage($"Permission with LookupCode '{request.LookupCode}' already exists")
                    .WithUserFriendlyMessage("Permission with same look-up code already exists")
                    .Build();

            if (await context.Permissions.AnyAsync(_ => _.RoleId == request.RoleId && _.Name == request.Name, cancellationToken))
                throw new DuplicateEntityFieldsExceptionBuilder()
                    .WithEntityType<Permission>()
                    .WithMessage($"Permission with Name '{request.Name}' and Role '{role?.Name} [{request.RoleId}]' already exists")
                    .WithUserFriendlyMessage("Permission already exists")
                    .AddField(nameof(Permission.RoleId), request.RoleId)
                    .AddField(nameof(Permission.Name), request.Name)
                    .Build();

            var permission = request.AsPermission(role);
            context.Permissions.AddWithFootprint(permission);
            await context.SaveChangesAsync(cancellationToken);
            return permission;
        }
    }
}
