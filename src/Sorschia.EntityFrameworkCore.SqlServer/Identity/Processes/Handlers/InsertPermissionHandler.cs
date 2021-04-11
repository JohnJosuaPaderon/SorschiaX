using MediatR;
using Microsoft.EntityFrameworkCore;
using Sorschia.Identity.Data;
using Sorschia.Identity.Processes.Results;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Identity.Processes.Handlers
{
    internal sealed class InsertPermissionHandler : IRequestHandler<InsertPermission, InsertPermissionResult>
    {
        private readonly IDbContextFactory<IdentityContext> _contextFactory;
        private readonly IMediator _mediator;

        public InsertPermissionHandler(IDbContextFactory<IdentityContext> contextFactory, IMediator mediator)
        {
            _contextFactory = contextFactory;
            _mediator = mediator;
        }

        public async Task<InsertPermissionResult> Handle(InsertPermission request, CancellationToken cancellationToken)
        {
            using var context = _contextFactory.CreateDbContext();
            using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);
            var result = new InsertPermissionResult();
            var permission = await _mediator.Send(request.AsDbInsertPermission(context), cancellationToken);
            result.Set(permission);
            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return result;
        }
    }
}
