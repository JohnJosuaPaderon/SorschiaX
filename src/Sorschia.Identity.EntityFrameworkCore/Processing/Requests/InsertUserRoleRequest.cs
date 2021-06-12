using MediatR;
using Sorschia.Identity.Entities;
using Sorschia.Utilities;

namespace Sorschia.Identity.Processing.Requests
{
    internal class InsertUserRoleRequest : IRequest<UserRole>, IResourceConsumer
    {
        ResourceConsumerIdentifier IResourceConsumer.Id { get; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Role Role { get; set; }
        public int RoleId { get; set; }

        public UserRole AsUserRole() => new()
        {
            UserId = UserId,
            RoleId = RoleId
        };
    }
}
