using MediatR;
using Sorschia.Identity.Entities;
using Sorschia.Identity.Processing.Responses;
using System.Collections.Generic;

namespace Sorschia.Identity.Processing.Requests
{
    public class AddUserRequest : IRequest<AddUserResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public UserStatus Status { get; set; }
        public IEnumerable<int> RoleIds { get; set; }
        public IEnumerable<int> PermissionIds { get; set; }
    }
}
