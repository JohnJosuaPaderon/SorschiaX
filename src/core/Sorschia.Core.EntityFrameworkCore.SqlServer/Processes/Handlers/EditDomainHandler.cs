using MediatR;
using Microsoft.EntityFrameworkCore;
using Sorschia.Core.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Core.Processes.Handlers
{
    internal sealed class EditDomainHandler : IRequestHandler<EditDomain.Request, EditDomain.Response>
    {
        private readonly IMediator _mediator;
        private readonly IDbContextFactory<CoreContext> _contextFactory;

        public EditDomainHandler(IMediator mediator, IDbContextFactory<CoreContext> contextFactory)
        {
            _mediator = mediator;
            _contextFactory = contextFactory;
        }

        public async Task<EditDomain.Response> Handle(EditDomain.Request request, CancellationToken cancellationToken)
        {
            using var context = _contextFactory.CreateDbContext();
            using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);
            var response = new EditDomain.Response();
            var domain = await _mediator.Send(request.ToDbUpdateDomainRequest(context), cancellationToken);
            response.FromDomain(domain);
            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return response;
        }
    }
}
