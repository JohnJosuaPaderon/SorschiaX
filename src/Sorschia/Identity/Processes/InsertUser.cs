using MediatR;
using Sorschia.Identity.Entities;
using Sorschia.Identity.Processes.Results;
using System.Collections.Generic;

namespace Sorschia.Identity.Processes
{
    public class InsertUser : IRequest<InsertUserResult>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string NameSuffix { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserStatus Status { get; set; }
        public bool IsPasswordChangeRequired { get; set; }
        public IEnumerable<int> RoleIds { get; set; }
        public IEnumerable<int> PermissionIds { get; set; }
    }
}
