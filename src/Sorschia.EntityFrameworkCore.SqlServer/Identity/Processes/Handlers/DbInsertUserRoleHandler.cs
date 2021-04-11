using MediatR;
using Sorschia.Extensions;
using Sorschia.Identity.Data;
using Sorschia.Identity.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Identity.Processes.Handlers
{
    internal sealed class DbInsertUserRoleHandler : IRequestHandler<DbInsertUserRole, UserRole>
    {
        public async Task<UserRole> Handle(DbInsertUserRole request, CancellationToken cancellationToken)
        {
            var context = request.TryGetContext();
            var user = request.User ?? await context.FindUserAsync(request.UserId, cancellationToken);
            var role = request.Role ?? await context.FindRoleAsync(request.RoleId, cancellationToken);
            var userRole = request.AsUserRole(user, role);
            context.UserRoles.AddWithFootprint(userRole);
            await context.SaveChangesAsync(cancellationToken);
            return userRole;
        }
    }
}
