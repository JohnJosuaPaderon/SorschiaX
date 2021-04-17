using MediatR;
using Microsoft.EntityFrameworkCore;
using Sorschia.Entities;
using Sorschia.Entities.Exceptions.Builders;
using Sorschia.Extensions;
using Sorschia.Identity.Entities;
using Sorschia.Identity.Extensions;
using Sorschia.Identity.Utilities;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Identity.Processes.Handlers
{
    internal sealed class DbInsertUserHandler : IRequestHandler<DbInsertUser, User>
    {
        private readonly IFullNameBuilder _fullNameBuilder;
        private readonly IUserPasswordTransformer _userPasswordTransformer;

        public DbInsertUserHandler(IFullNameBuilder fullNameBuilder, IUserPasswordTransformer userPasswordTransformer)
        {
            _fullNameBuilder = fullNameBuilder;
            _userPasswordTransformer = userPasswordTransformer;
        }

        public async Task<User> Handle(DbInsertUser request, CancellationToken cancellationToken)
        {
            var context = request.TryGetContext();

            if (await context.Users.AnyAsync(_ => _.Username == request.Username, cancellationToken))
                throw new DuplicateEntityFieldExceptionBuilder()
                    .WithEntityType<User>()
                    .WithField(nameof(User.Username), request.Username)
                    .WithMessage($"User with Username '{request.Username}' already exists")
                    .WithUserFriendlyMessage("Username is already used")
                    .Build();

            var user = request.AsUser();
            user.FullName = _fullNameBuilder.Build(user);
            context.Users.AddWithFootprint(user)
                .SetSecurePassword(_userPasswordTransformer.ToSecurePassword(request.Password));
            await context.SaveChangesAsync(cancellationToken);
            return user;
        }
    }
}
