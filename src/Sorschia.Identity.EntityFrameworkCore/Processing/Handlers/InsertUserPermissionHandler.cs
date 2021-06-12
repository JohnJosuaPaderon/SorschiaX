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
    internal sealed class InsertUserPermissionHandler : IRequestHandler<InsertUserPermissionRequest, UserPermission>
    {
        private readonly IResourceManager _resourceManager;

        public InsertUserPermissionHandler(IResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }

        public async Task<UserPermission> Handle(InsertUserPermissionRequest request, CancellationToken cancellationToken)
        {
            var resourceContext = _resourceManager.GetContext(request);
            var context = resourceContext.GetIdentityContext();
            var currentFootprint = resourceContext.GetCurrentFootprint();
            var user = request.User ?? await context.FindUserAsync(request.UserId, cancellationToken);
            var permission = request.Permission ?? await context.FindPermissionAsync(request.PermissionId, cancellationToken);

            if (await context.UserPermissions.Where(_ => _.UserId == request.UserId && _.PermissionId == request.PermissionId).AnyAsync(cancellationToken))
                throw new DuplicateEntityExceptionBuilder()
                    .WithEntityType<UserPermission>()
                    .WithMessage("User-Permission already exists")
                    .WithDebugMessage($"User-Permission with UserId = {request.UserId}, PermissionId = {request.PermissionId} already exists")
                    .AddField(nameof(UserPermission.UserId), request.UserId)
                    .AddField(nameof(UserPermission.PermissionId), request.PermissionId)
                    .Build();

            var userPermission = request.AsUserPermission();
            userPermission.User = user;
            userPermission.Permission = permission;
            context.UserPermissions.Add(userPermission, currentFootprint);
            await context.SaveChangesAsync(cancellationToken);
            return userPermission;
        }
    }
}
