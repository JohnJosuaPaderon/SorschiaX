using MediatR;
using Sorschia.Identity.Entities;
using Sorschia.Utilities;

namespace Sorschia.Identity.Processing.Requests
{
    internal class InsertUserPermissionRequest : IRequest<UserPermission>, IResourceConsumer
    {
        ResourceConsumerIdentifier IResourceConsumer.Id { get; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Permission Permission { get; set; }
        public int PermissionId { get; set; }

        public UserPermission AsUserPermission() => new()
        {
            UserId = UserId,
            PermissionId = PermissionId
        };
    }
}
