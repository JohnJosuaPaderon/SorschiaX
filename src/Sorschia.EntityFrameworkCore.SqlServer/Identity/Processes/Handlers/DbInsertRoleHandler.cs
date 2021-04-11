using MediatR;
using Sorschia.Extensions;
using Sorschia.Identity.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Identity.Processes.Handlers
{
    internal sealed class DbInsertRoleHandler : IRequestHandler<DbInsertRole, Role>
    {
        public async Task<Role> Handle(DbInsertRole request, CancellationToken cancellationToken)
        {
            var context = request.TryGetContext();
            var role = request.AsRole();
            context.Roles.AddWithFootprint(role);
            await context.SaveChangesAsync(cancellationToken);
            return role;
        }
    }
}
