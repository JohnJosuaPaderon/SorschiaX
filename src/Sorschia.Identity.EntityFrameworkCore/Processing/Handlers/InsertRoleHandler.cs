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
    internal sealed class InsertRoleHandler : IRequestHandler<InsertRoleRequest, Role>
    {
        private readonly IResourceManager _resourceManager;

        public InsertRoleHandler(IResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }

        public async Task<Role> Handle(InsertRoleRequest request, CancellationToken cancellationToken)
        {
            var resourceContext = _resourceManager.GetContext(request);
            var context = resourceContext.GetIdentityContext();
            var currentFootprint = resourceContext.GetCurrentFootprint();

            if (await context.Roles.Where(_ => _.Name == request.Name).AnyAsync(cancellationToken))
                throw new DuplicateEntityExceptionBuilder()
                    .WithEntityType<Role>()
                    .WithMessage("Role already exists")
                    .WithDebugMessage($"Role with Name = {request.Name} already exists")
                    .AddField(nameof(Role.Name), request.Name)
                    .Build();

            if (request.LookupCode is not null && await context.Roles.Where(_ => _.LookupCode == request.LookupCode).AnyAsync(cancellationToken))
                throw new DuplicateEntityExceptionBuilder()
                    .WithEntityType<Role>()
                    .WithMessage("Role already exists")
                    .WithDebugMessage($"Role with LookupCode = {request.LookupCode} already exists")
                    .AddField(nameof(Role.LookupCode), request.LookupCode)
                    .Build();

            var role = request.AsRole();
            context.Roles.Add(role, currentFootprint);
            await context.SaveChangesAsync(cancellationToken);
            return role;
        }
    }
}
