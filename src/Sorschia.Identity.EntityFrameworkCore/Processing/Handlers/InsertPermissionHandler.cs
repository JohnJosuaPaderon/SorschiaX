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
    internal sealed class InsertPermissionHandler : IRequestHandler<InsertPermissionRequest, Permission>
    {
        private readonly IResourceManager _resourceManager;

        public InsertPermissionHandler(IResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }

        public async Task<Permission> Handle(InsertPermissionRequest request, CancellationToken cancellationToken)
        {
            var resourceContext = _resourceManager.GetContext(request);
            var context = resourceContext.GetIdentityContext();
            var currentFootprint = resourceContext.GetCurrentFootprint();
            var permission = request.AsPermission();

            if (await context.Permissions.Where(_ => _.Name == permission.Name).AnyAsync(cancellationToken))
                throw new DuplicateEntityExceptionBuilder()
                    .WithEntityType<Permission>()
                    .WithMessage("Permission already exists")
                    .WithDebugMessage($"Permission with Name = {permission.Name} already exists")
                    .Build();

            if (request.LookupCode is not null && await context.Permissions.Where(_ => _.LookupCode == permission.LookupCode).AnyAsync(cancellationToken))
                throw new DuplicateEntityExceptionBuilder()
                    .WithEntityType<Permission>()
                    .WithMessage("Permission already exists")
                    .WithDebugMessage($"Permission with LookupCode = {permission.LookupCode} already exists")
                    .Build();

            context.Permissions.Add(permission, currentFootprint);
            await context.SaveChangesAsync(cancellationToken);
            return permission;
        }
    }
}
