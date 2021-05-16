using MediatR;
using Microsoft.EntityFrameworkCore;
using Sorschia.Core.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Core.Processes.Handlers
{
    internal sealed class AddDomainHandler : IRequestHandler<AddDomain.Request, AddDomain.Response>
    {
        private readonly IDbContextFactory<CoreContext> _contextFactory;
        private readonly IMediator _mediator;

        public AddDomainHandler(IMediator mediator, IDbContextFactory<CoreContext> contextFactory)
        {
            _mediator = mediator;
            _contextFactory = contextFactory;
        }

        public async Task<AddDomain.Response> Handle(AddDomain.Request request, CancellationToken cancellationToken)
        {
            using var context = _contextFactory.CreateDbContext();
            using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);
            var response = new AddDomain.Response();
            var domain = await _mediator.Send(request.ToDbInsertDomainRequest(context), cancellationToken);
            response.FromDomain(domain);
            await transaction.CommitAsync(cancellationToken);
            return response;
        }
    }
}
