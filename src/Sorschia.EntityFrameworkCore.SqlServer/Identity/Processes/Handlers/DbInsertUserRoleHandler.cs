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
    internal sealed class DbInsertUserRoleHandler : IRequestHandler<DbInsertUserRole, UserRole>
    {
        public async Task<UserRole> Handle(DbInsertUserRole request, CancellationToken cancellationToken)
        {
            var context = request.TryGetContext();
            var user = request.User ?? await context.FindUserAsync(request.UserId, cancellationToken);
            var role = request.Role ?? await context.FindRoleAsync(request.RoleId, cancellationToken);

            if (await context.UserRoles.AnyAsync(_ => _.UserId == request.UserId && _.RoleId == request.RoleId, cancellationToken))
                throw new DuplicateEntityExceptionBuilder()
                    .WithEntityType<UserRole>()
                    .WithMessage("User-Role already exists")
                    .WithDebugMessage($"UserRole with User '{user?.FullName} [{request.UserId}]' and Role '{role?.Name} [{request.RoleId}]'")
                    .Build();

            var userRole = request.AsUserRole(user, role);
            context.UserRoles.AddWithFootprint(userRole);
            await context.SaveChangesAsync(cancellationToken);
            return userRole;
        }
    }
}
