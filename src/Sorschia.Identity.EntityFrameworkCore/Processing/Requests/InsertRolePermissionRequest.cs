using MediatR;
using Sorschia.Identity.Entities;
using Sorschia.Utilities;

namespace Sorschia.Identity.Processing.Requests
{
    internal class InsertRolePermissionRequest : IRequest<RolePermission>, IResourceConsumer
    {
        ResourceConsumerIdentifier IResourceConsumer.Id { get; }
        public Role Role { get; set; }
        public int RoleId { get; set; }
        public Permission Permission { get; set; }
        public int PermissionId { get; set; }

        public RolePermission AsRolePermission() => new()
        {
            RoleId = RoleId,
            PermissionId = PermissionId
        };
    }
}
