using MediatR;
using Microsoft.EntityFrameworkCore;
using Sorschia.Identity.Data;
using Sorschia.Identity.Entities;
using System.Threading;
using System.Threading.Tasks;
using SystemBase.Entities.Exceptions.Builders;
using SystemBase.Extensions;

namespace Sorschia.Identity.Processes.Handlers
{
    internal sealed class DbInsertPermissionHandler : IRequestHandler<DbInsertPermission, Permission>
    {
        public async Task<Permission> Handle(DbInsertPermission request, CancellationToken cancellationToken)
        {
            var context = request.TryGetContext();
            var role = request.Role ?? await context.FindRoleAsync(request.RoleId ?? 0, cancellationToken);

            if (!string.IsNullOrEmpty(request.LookupCode) && await context.Permissions.AnyAsync(_ => _.LookupCode == request.LookupCode, cancellationToken))
                throw new DuplicateEntityExceptionBuilder()
                    .WithEntityType<Permission>()
                    .WithMessage("Permission with same look-up code already exists")
                    .WithDebugMessage($"Permission with LookupCode '{request.LookupCode}' already exists")
                    .AddField(nameof(Permission.LookupCode), request.LookupCode)
                    .Build();

            if (await context.Permissions.AnyAsync(_ => _.RoleId == request.RoleId && _.Name == request.Name, cancellationToken))
                throw new DuplicateEntityExceptionBuilder()
                    .WithEntityType<Permission>()
                    .WithMessage("Permission already exists")
                    .WithDebugMessage($"Permission with Name '{request.Name}' and Role '{role?.Name} [{request.RoleId}]' already exists")
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
