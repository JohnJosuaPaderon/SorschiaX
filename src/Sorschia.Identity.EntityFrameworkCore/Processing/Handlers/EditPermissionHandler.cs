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
    internal sealed class EditPermissionHandler : IRequestHandler<EditPermissionRequest, EditPermissionResponse>
    {
        private readonly IMediator _mediator;
        private readonly IResourceManager _resourceManager;
        private readonly IDbContextFactory<IdentityContext> _contextFactory;
        private readonly ICurrentFootprintProvider _currentFootprintProvider;

        public EditPermissionHandler(IMediator mediator, IResourceManager resourceManager, IDbContextFactory<IdentityContext> contextFactory, ICurrentFootprintProvider currentFootprintProvider)
        {
            _mediator = mediator;
            _resourceManager = resourceManager;
            _contextFactory = contextFactory;
            _currentFootprintProvider = currentFootprintProvider;
        }

        public async Task<EditPermissionResponse> Handle(EditPermissionRequest request, CancellationToken cancellationToken)
        {
            using var context = _contextFactory.CreateDbContext();
            using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);
            var updatePermissionRequest = request.AsUpdatePermissionRequest();
            using var resourceContext = _resourceManager.CreateContext()
                .SetIdentityContext(context)
                .SetCurrentFootprint(_currentFootprintProvider.Current)
                .AttachConsumer(updatePermissionRequest);
            var response = new EditPermissionResponse();
            var permission = await _mediator.Send(updatePermissionRequest, cancellationToken);
            response.From(permission);
            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return response;
        }
    }
}
