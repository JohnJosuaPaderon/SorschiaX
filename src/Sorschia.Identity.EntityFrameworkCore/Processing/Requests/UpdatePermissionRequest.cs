using MediatR;
using Sorschia.Identity.Entities;
using Sorschia.Utilities;

namespace Sorschia.Identity.Processing.Requests
{
    internal class UpdatePermissionRequest : IRequest<Permission>, IResourceConsumer
    {
        ResourceConsumerIdentifier IResourceConsumer.Id { get; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string LookupCode { get; set; }
        public string Description { get; set; }

        public bool HasChanges(Permission permission) =>
            Name != permission.Name ||
            LookupCode != permission.LookupCode ||
            Description != permission.Description;
    }
}
