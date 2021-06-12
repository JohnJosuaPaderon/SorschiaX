using MediatR;
using Sorschia.Identity.Entities;
using Sorschia.Utilities;

namespace Sorschia.Identity.Processing.Requests
{
    internal class InsertRoleRequest : IRequest<Role>, IResourceConsumer
    {
        ResourceConsumerIdentifier IResourceConsumer.Id { get; }
        public string Name { get; set; }
        public string LookupCode { get; set; }
        public string Description { get; set; }

        public Role AsRole() => new()
        {
            Name = Name,
            LookupCode = LookupCode,
            Description = Description
        };
    }
}
