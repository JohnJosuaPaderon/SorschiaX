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
    internal sealed class DbInsertUserPermissionHandler : IRequestHandler<DbInsertUserPermission, UserPermission>
    {
        public async Task<UserPermission> Handle(DbInsertUserPermission request, CancellationToken cancellationToken)
        {
            var context = request.TryGetContext();
            var user = request.User ?? await context.FindUserAsync(request.UserId, cancellationToken);
            var permission = request.Permission ?? await context.FindPermissionAsync(request.PermissionId, cancellationToken);

            if (await context.UserPermissions.AnyAsync(_ => _.UserId == request.UserId && _.PermissionId == request.PermissionId, cancellationToken))
                throw new DuplicateEntityExceptionBuilder()
                    .WithEntityType<UserPermission>()
                    .WithMessage("User-Permission already exists")
                    .WithDebugMessage($"UserPermission with User '{user?.FullName} [{request.UserId}]' and Permission '{permission?.Name} [{request.PermissionId}]' already exists")
                    .AddField(nameof(UserPermission.UserId), request.UserId)
                    .AddField(nameof(UserPermission.PermissionId), request.PermissionId)
                    .Build();

            var userPermission = request.AsUserPermission(user, permission);
            context.UserPermissions.AddWithFootprint(userPermission);
            await context.SaveChangesAsync(cancellationToken);
            return userPermission;
        }
    }
}
