using Sorschia.Utilities;
using System.Collections.Generic;

namespace Sorschia.Entities
{
    public class User : UserBase, IFullName
    {
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
