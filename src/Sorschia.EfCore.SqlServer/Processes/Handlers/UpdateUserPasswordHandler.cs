using MediatR;
using Microsoft.EntityFrameworkCore;
using Sorschia.Data;
using Sorschia.Entities;
using Sorschia.Extensions;
using Sorschia.Security;
using Sorschia.Utilities;
using Sorschia.Utilities.ExceptionBuilders;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Processes.Handlers
{
    internal sealed class UpdateUserPasswordHandler : IRequestHandler<UpdateUserPassword>
    {
        private readonly IDbContextFactory<SorschiaDbContext> _contextFactory;
        private readonly ICurrentFootprintProvider _currentFootprintProvider;
        private readonly IUserPasswordTransformer _userPasswordTransformer;

        public UpdateUserPasswordHandler(IDbContextFactory<SorschiaDbContext> contextFactory, ICurrentFootprintProvider currentFootprintProvider, IUserPasswordTransformer userPasswordTransformer)
        {
            _contextFactory = contextFactory;
            _currentFootprintProvider = currentFootprintProvider;
            _userPasswordTransformer = userPasswordTransformer;
        }

        public async Task<Unit> Handle(UpdateUserPassword request, CancellationToken cancellationToken)
        {
            using var context = _contextFactory.CreateDbContext();
            using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);
            var footprint = _currentFootprintProvider.Current;

            var user = await context.GetUserAsync(request.UserId, cancellationToken: cancellationToken);
            var securePassword = _userPasswordTransformer.ToSecurePassword(request.Password);
            var userEntry = context.Entry(user);
            var securePasswordEntry = userEntry.Property<string>(ShadowProperties.User.SecurePassword);

            if (securePasswordEntry.CurrentValue == securePassword)
                throw new SorschiaEntityFieldAlreadySetExceptionBuilder()
                    .WithEntityType<User>()
                    .AddEntityField("SecurePassword", null)
                    .Build();

            securePasswordEntry.CurrentValue = securePassword;
            userEntry.State = EntityState.Modified;
            userEntry.SetUpdateFootprint(footprint);
            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
