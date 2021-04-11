using MediatR;
using Microsoft.EntityFrameworkCore;
using Sorschia.Identity.Data;
using Sorschia.Identity.Processes.Results;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Identity.Processes.Handlers
{
    internal sealed class InsertRoleHandler : IRequestHandler<InsertRole, InsertRoleResult>
    {
        private readonly IDbContextFactory<IdentityContext> _contextFactory;
        private readonly IMediator _mediator;

        public InsertRoleHandler(IDbContextFactory<IdentityContext> contextFactory, IMediator mediator)
        {
            _contextFactory = contextFactory;
            _mediator = mediator;
        }

        public async Task<InsertRoleResult> Handle(InsertRole request, CancellationToken cancellationToken)
        {
            using var context = _contextFactory.CreateDbContext();
            using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);
            var result = new InsertRoleResult();
            var role = await _mediator.Send(request.AsDbInsertRole(context), cancellationToken);
            result.Set(role);
            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return result;
        }
    }
}
