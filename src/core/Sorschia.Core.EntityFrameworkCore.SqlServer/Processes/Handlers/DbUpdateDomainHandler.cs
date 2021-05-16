using MediatR;
using Microsoft.EntityFrameworkCore;
using Sorschia.Core.Entities;
using Sorschia.Exceptions.Builders;
using Sorschia.Extensions;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Core.Processes.Handlers
{
    internal sealed class DbUpdateDomainHandler : IRequestHandler<DbUpdateDomain.Request, Domain>
    {
        public async Task<Domain> Handle(DbUpdateDomain.Request request, CancellationToken cancellationToken)
        {
            var context = request.DbContext;

            if (await context.Domains.AnyAsync(_ => _.Id != request.Id && _.Name == request.Name, cancellationToken))
                throw new DuplicateEntityExceptionBuilder()
                    .WithMessage("Domain already exists")
                    .WithDebugMessage($"Domain with name = '{request.Name}' already exists")
                    .WithEntityType<Domain>()
                    .AddField(nameof(Domain.Name), request.Name)
                    .Build();

            var domain = await context.FindDomainAsync(request.Id, cancellationToken);
            domain.FromDbUpdateDomainRequest(request);
            context.Domains.UpdateWithFootprint(domain);
            return domain;
        }
    }
}
