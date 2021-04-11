using MediatR;
using Sorschia.Extensions;
using Sorschia.Identity.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Identity.Processes.Handlers
{
    internal sealed class DbInsertUserPermissionHandler : IRequestHandler<DbInsertUserPermission, UserPermission>
    {
        public async Task<UserPermission> Handle(DbInsertUserPermission request, CancellationToken cancellationToken)
        {
            var context = request.TryGetContext();
            var userPermission = request.AsUserPermission();
            context.UserPermissions.AddWithFootprint(userPermission);
            await context.SaveChangesAsync(cancellationToken);
            return userPermission;
        }
    }
}
