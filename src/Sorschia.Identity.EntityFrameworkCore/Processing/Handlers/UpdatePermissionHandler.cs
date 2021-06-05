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
    internal sealed class UpdatePermissionHandler : IRequestHandler<UpdatePermissionRequest, Permission>
    {
        private readonly IResourceManager _resourceManager;

        public UpdatePermissionHandler(IResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }

        public async Task<Permission> Handle(UpdatePermissionRequest request, CancellationToken cancellationToken)
        {
            var resourceContext = _resourceManager.GetContext(request);
            var context = resourceContext.GetIdentityContext();
            var currentFootprint = resourceContext.GetCurrentFootprint();
            var permission = await context.FindPermissionAsync(request.Id, cancellationToken);

            if (request.HasChanges(permission))
            {
                if (await context.Permissions.Where(_ => _.Id != request.Id && _.Name == request.Name).AnyAsync(cancellationToken))
                    throw new DuplicateEntityExceptionBuilder()
                        .WithEntityType<Permission>()
                        .WithMessage("Permission already exists")
                        .WithDebugMessage($"Permission with Name = {request.Name} already exists")
                        .Build();

                if (request.LookupCode is not null && await context.Permissions.Where(_ => _.Id != request.Id && _.LookupCode == request.LookupCode).AnyAsync(cancellationToken))
                    throw new DuplicateEntityExceptionBuilder()
                        .WithEntityType<Permission>()
                        .WithMessage("Permission already exists")
                        .WithDebugMessage($"Permission with LookupCode = {request.LookupCode} already exists")
                        .Build();

                permission.From(request);
                context.Permissions.Update(permission, currentFootprint);
            }

            return permission;
        }
    }
}
