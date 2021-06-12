using MediatR;
using Microsoft.EntityFrameworkCore;
using Sorschia.Auditing;
using Sorschia.Extensions;
using Sorschia.Identity.Data;
using Sorschia.Identity.Processing.Requests;
using Sorschia.Identity.Processing.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Identity.Processing.Handlers
{
    internal sealed class DeletePermissionHandler : IRequestHandler<DeletePermissionRequest, DeletePermissionResponse>
    {
        private readonly IDbContextFactory<IdentityContext> _contextFactory;
        private readonly ICurrentFootprintProvider _currentFootprintProvider;

        public DeletePermissionHandler(IDbContextFactory<IdentityContext> contextFactory, ICurrentFootprintProvider currentFootprintProvider)
        {
            _contextFactory = contextFactory;
            _currentFootprintProvider = currentFootprintProvider;
        }

        public async Task<DeletePermissionResponse> Handle(DeletePermissionRequest request, CancellationToken cancellationToken)
        {
            using var context = _contextFactory.CreateDbContext();
            using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);
            var permission = await context.FindPermissionAsync(request.Id, cancellationToken);
            var response = new DeletePermissionResponse();
            context.Permissions.SoftDelete(permission, _currentFootprintProvider.Current);
            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return response;
        }
    }
}
