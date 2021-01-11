using System.Collections.Generic;

namespace Sorschia.Entities
{
    public class User : EntityBase, INameable
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = default!;
        public string? NameExtension { get; set; }
        public string FullName { get; set; } = default!;
        public string Username { get; set; } = default!;
        public string? Password { get; set; }
        public string? CipherPassword { get; set; }
        public string PasswordHash { get; set; } = default!;
        public string? EmailAddress { get; set; }
        public string? MobileNumber { get; set; }
        public bool IsActive { get; set; }
        public bool IsLocked { get; set; }
        public bool IsPasswordChangeRequired { get; set; }
        public bool IsEmailAddressVerified { get; set; }
        public bool IsMobileNumberVerified { get; set; }

        public ICollection<UserPermission> Permissions { get; set; } = new List<UserPermission>();
    }
}
