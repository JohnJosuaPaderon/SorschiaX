using MediatR;
using Microsoft.EntityFrameworkCore;
using Sorschia.Data;
using Sorschia.Extensions;
using Sorschia.Utilities;
using Sorschia.Utilities.ExceptionBuilders;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Processes.Handlers
{
    internal sealed class ActivateUserHandler : IRequestHandler<ActivateUser>
    {
        private readonly IDbContextFactory<SorschiaDbContext> _contextFactory;
        private readonly ICurrentFootprintProvider _currentFootprintProvider;

        public ActivateUserHandler(IDbContextFactory<SorschiaDbContext> contextFactory, ICurrentFootprintProvider currentFootprintProvider)
        {
            _contextFactory = contextFactory;
            _currentFootprintProvider = currentFootprintProvider;
        }

        public async Task<Unit> Handle(ActivateUser request, CancellationToken cancellationToken)
        {
            using var context = _contextFactory.CreateDbContext();
            using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);
            var footprint = _currentFootprintProvider.Current;
            var user = await context.GetUserAsync(request.UserId, cancellationToken: cancellationToken);

            if (user.IsActive == request.IsActive)
                throw new SorschiaEntityFieldAlreadySetExceptionBuilder()
                    .AddEntityField("IsActive", request.IsActive)
                    .Build();

            user.IsActive = request.IsActive;
            context.Update(user)
                .SetUpdateFootprint(footprint);
            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
