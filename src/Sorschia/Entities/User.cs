using Sorschia.Utilities;
using System.Collections.Generic;

namespace Sorschia.Entities
{
    public class User : IFullName
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = default!;
        public string? NameSuffix { get; set; }
        public string FullName { get; set; } = default!;
        public string Username { get; set; } = default!;
        public string? EmailAddress { get; set; }
        public string? MobileNumber { get; set; }
        public bool IsActive { get; set; }
        public bool IsPasswordChangeRequired { get; set; }
        public bool IsEmailAddressVerified { get; set; }
        public bool IsMobileNumberVerified { get; set; }

        public ICollection<UserApplication> UserApplications { get; set; } = new List<UserApplication>();
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public ICollection<UserPermission> UserPermissions { get; set; } = new List<UserPermission>(); 

        public const int FirstNameMaxLength = 100;
        public const int MiddleNameMaxLength = 100;
        public const int LastNameMaxLength = 100;
        public const int NameSuffixMaxLength = 5;
        public const int FullNameMaxLength = 350;
        public const int UsernameMaxLength = 300;
        public const int PasswordMaxLength = 300;
        public const int EmailAddressMaxLength = 300;
        public const int MobileNumberMaxLength = 20;
    }
}
