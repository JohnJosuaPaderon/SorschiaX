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
    internal sealed class InsertUserRoleHandler : IRequestHandler<InsertUserRoleRequest, UserRole>
    {
        private readonly IResourceManager _resourceManager;

        public InsertUserRoleHandler(IResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }

        public async Task<UserRole> Handle(InsertUserRoleRequest request, CancellationToken cancellationToken)
        {
            var resourceContext = _resourceManager.GetContext(request);
            var context = resourceContext.GetIdentityContext();
            var currentFootprint = resourceContext.GetCurrentFootprint();
            var user = request.User ?? await context.FindUserAsync(request.UserId, cancellationToken);
            var role = request.Role ?? await context.FindRoleAsync(request.RoleId, cancellationToken);

            if (await context.UserRoles.Where(_ => _.UserId == request.UserId && _.RoleId == request.RoleId).AnyAsync(cancellationToken))
                throw new DuplicateEntityExceptionBuilder()
                    .WithEntityType<UserRole>()
                    .WithMessage("User-Role already exists")
                    .WithDebugMessage($"User-Role with UserId = {request.UserId}, RoleId = {request.RoleId} already exists")
                    .AddField(nameof(UserRole.UserId), request.UserId)
                    .AddField(nameof(UserRole.RoleId), request.RoleId)
                    .Build();

            var userRole = request.AsUserRole();
            userRole.User = user;
            userRole.Role = role;
            context.UserRoles.Add(userRole, currentFootprint);
            await context.SaveChangesAsync(cancellationToken);
            return userRole;
        }
    }
}
