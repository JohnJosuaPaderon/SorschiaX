using MediatR;
using Microsoft.EntityFrameworkCore;
using Sorschia.Core.Entities;
using Sorschia.Exceptions.Builders;
using Sorschia.Extensions;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Core.Processes.Handlers
{
    internal sealed class DbInsertDomainHandler : IRequestHandler<DbInsertDomain.Request, Domain>
    {
        public async Task<Domain> Handle(DbInsertDomain.Request request, CancellationToken cancellationToken)
        {
            var context = request.DbContext;

            if (await context.Domains.AnyAsync(_ => _.Name == request.Name, cancellationToken))
                throw new DuplicateEntityExceptionBuilder()
                    .WithMessage("Domain already exists")
                    .WithDebugMessage($"Domain with name = '{request.Name}' already exists")
                    .WithEntityType<Domain>()
                    .AddField(nameof(Domain.Name), request.Name)
                    .Build();

            var domain = request.ToDomain();
            context.Domains.AddWithFootprint(domain);
            await context.SaveChangesAsync(cancellationToken);
            return domain;
        }
    }
}
