using MediatR;
using Sorschia.Identity.Entities;
using Sorschia.Utilities;

namespace Sorschia.Identity.Processing.Requests
{
    internal sealed class InsertUserRequest : IRequest<User>, IResourceConsumer
    {
        ResourceConsumerIdentifier IResourceConsumer.Id { get; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserStatus Status { get; set; }

        public User AsUser() => new()
        {
            Username = Username,
            Status = Status
        };
    }
}
