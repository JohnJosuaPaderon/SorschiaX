using System.Collections.Generic;

namespace Sorschia.Identity.Entities
{
    public class User : UserBase
    {
        public IEnumerable<UserRole> UserRoles { get; set; }
        public IEnumerable<UserPermission> UserPermissions { get; set; }
    }

    public abstract class UserBase
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public UserStatus Status { get; set; }
    }
}
