using MediatR;
using Microsoft.EntityFrameworkCore;
using Sorschia.Auditing;
using Sorschia.Identity.Data;
using Sorschia.Identity.Processing.Requests;
using Sorschia.Identity.Processing.Responses;
using Sorschia.Utilities;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Identity.Processing.Handlers
{
    internal sealed class AddPermissionHandler : IRequestHandler<AddPermissionRequest, AddPermissionResponse>
    {
        private readonly IMediator _mediator;
        private readonly IResourceManager _resourceManager;
        private readonly IDbContextFactory<IdentityContext> _contextFactory;
        private readonly ICurrentFootprintProvider _currentFootprintProvider;

        public AddPermissionHandler(IMediator mediator, IResourceManager resourceManager, IDbContextFactory<IdentityContext> contextFactory, ICurrentFootprintProvider currentFootprintProvider)
        {
            _mediator = mediator;
            _resourceManager = resourceManager;
            _contextFactory = contextFactory;
            _currentFootprintProvider = currentFootprintProvider;
        }

        public async Task<AddPermissionResponse> Handle(AddPermissionRequest request, CancellationToken cancellationToken)
        {
            using var context = _contextFactory.CreateDbContext();
            using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);
            var insertPermissionRequest = request.AsInsertPermissionRequest();
            using var resourceContext = _resourceManager.CreateContext()
                .SetIdentityContext(context)
                .SetCurrentFootprint(_currentFootprintProvider.Current)
                .AttachConsumer(insertPermissionRequest);
            var response = new AddPermissionResponse();
            var permission = await _mediator.Send(insertPermissionRequest, cancellationToken);
            response.From(permission);
            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return response;
        }
    }
}
