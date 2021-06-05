using MediatR;
using Sorschia.Identity.Entities;
using Sorschia.Utilities;

namespace Sorschia.Identity.Processing.Requests
{
    internal class InsertPermissionRequest : IRequest<Permission>, IResourceConsumer
    {
        public ResourceConsumerIdentifier Id { get; }
        public string Name { get; set; }
        public string LookupCode { get; set; }
        public string Description { get; set; }

        public Permission AsPermission() => new()
        {
            Name = Name,
            LookupCode = LookupCode,
            Description = Description
        };
    }
}
