using MediatR;
using Microsoft.EntityFrameworkCore;
using Sorschia.Core.Data;
using Sorschia.Core.Entities;
using Sorschia.Exceptions.Builders;
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

            if (await context.Domains.AnyAsync(_ => _.Name == request.Name, cancellationToken))
                throw new DuplicateEntityExceptionBuilder()
                    .WithMessage("Domain already exists")
                    .WithDebugMessage($"Domain with name = '{request.Name}' already exists")
                    .WithEntityType<Domain>()
                    .AddField(nameof(Domain.Name), request.Name)
                    .Build();

            AddDomain.Response response = new();
            var domain = await _mediator.Send(request.AsDbInsertDomainRequest(context), cancellationToken);
            response.FromDomain(domain);
            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return response;
        }
    }
}
