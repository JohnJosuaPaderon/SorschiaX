using System.Collections.Generic;
using SystemBase.Entities;

namespace Sorschia.Identity.Entities
{
    public class User : UserBase, IFullNameHolder
    {
        public IEnumerable<UserRole> UserRoles { get; set; }
        public IEnumerable<UserPermission> UserPermissions { get; set; }

        public const int FirstNameMaxLength = 100;
        public const int MiddleNameMaxLength = 100;
        public const int LastNameMaxLength = 100;
        public const int NameSuffixMaxLength = 5;
        public const int FullNameMaxLength = 400;
        public const int UsernameMaxLength = 50;
        public const int PasswordMaxLength = 50;
        public const int SecurePasswordMaxLength = 500;
    }
}
