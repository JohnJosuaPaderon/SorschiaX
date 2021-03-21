using MediatR;
using System.Collections.Generic;

namespace Sorschia.Processes
{
    public class InsertUser : IRequest
    {
        public string FirstName { get; set; } = default!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = default!;
        public string? NameSuffix { get; set; }
        public string FullName { get; set; } = default!;
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string? EmailAddress { get; set; }
        public string? MobileNumber { get; set; }
        public bool IsActive { get; set; }
        public bool IsPasswordChangeRequired { get; set; }
        public bool IsEmailAddressVerified { get; set; }
        public bool IsMobileNumberVerified { get; set; }

        public sealed class ApplicationObj
        {
            public short Id { get; set; }
        }

        public sealed class RoleObj
        {
            public int Id { get; set; }
            public ICollection<int> PermissionIds { get; set; } = new List<int>();
        }
    }
}
