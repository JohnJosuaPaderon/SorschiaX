using MediatR;
using Microsoft.EntityFrameworkCore;
using Sorschia.Auditing;
using Sorschia.ErrorHandling.Builders;
using Sorschia.Identity.Data;
using Sorschia.Identity.Entities;
using Sorschia.Identity.Extensions;
using Sorschia.Identity.Processing.Requests;
using Sorschia.Identity.Utilities;
using Sorschia.Utilities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Identity.Processing.Handlers
{
    internal sealed class InsertUserHandler : IRequestHandler<InsertUserRequest, User>
    {
        private readonly IResourceManager _resourceManager;
        private readonly IUserPasswordTransformer _passwordTransformer;

        public InsertUserHandler(IResourceManager resourceManager, IUserPasswordTransformer passwordTransformer)
        {
            _resourceManager = resourceManager;
            _passwordTransformer = passwordTransformer;
        }

        public async Task<User> Handle(InsertUserRequest request, CancellationToken cancellationToken)
        {
            var resourceContext = _resourceManager.GetContext(request);
            var context = resourceContext.GetIdentityContext();
            var currentFootprint = resourceContext.GetCurrentFootprint();

            if (await context.Users.Where(_ => _.Username == request.Username).AnyAsync(cancellationToken))
                throw new DuplicateEntityExceptionBuilder()
                    .WithEntityType<User>()
                    .WithMessage("User already exists")
                    .WithDebugMessage($"User with Username = {request.Username} already exists")
                    .AddField(nameof(User.Username), request.Username)
                    .Build();

            var user = request.AsUser();
            context.Users.Add(user)
                .SetSecurePassword(_passwordTransformer.ToSecurePassword(request.Password));
            await context.SaveChangesAsync(cancellationToken);
            return user;
        }
    }
}
