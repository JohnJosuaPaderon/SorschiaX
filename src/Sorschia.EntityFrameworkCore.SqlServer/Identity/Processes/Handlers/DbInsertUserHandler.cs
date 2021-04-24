using MediatR;
using Microsoft.EntityFrameworkCore;
using Sorschia.Identity.Entities;
using Sorschia.Identity.Extensions;
using Sorschia.Identity.Utilities;
using System.Threading;
using System.Threading.Tasks;
using SystemBase.Entities;
using SystemBase.Entities.Exceptions.Builders;
using SystemBase.Extensions;

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
                throw new DuplicateEntityExceptionBuilder()
                    .WithEntityType<User>()
                    .AddField(nameof(User.Username), request.Username)
                    .WithMessage("Username is already exists")
                    .WithDebugMessage($"User with Username '{request.Username}' already exists")
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
