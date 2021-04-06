using MediatR;
using Microsoft.EntityFrameworkCore;
using Sorschia.Data;
using Sorschia.Processes.Results;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Processes.Handlers
{
    internal sealed class InsertUserHandler : IRequestHandler<InsertUser, InsertUserResult>
    {
        private readonly IDbContextFactory<SorschiaDbContext> _contextFactory;

        public InsertUserHandler(IDbContextFactory<SorschiaDbContext> contextFactory)
        {Authorize
            _contextFactory = contextFactory;
        }

        public async Task<InsertUserResult> Handle(InsertUser request, CancellationToken cancellationToken)
        {
            using var context = _contextFactory.CreateDbContext();
            using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);
        }
    }
}
