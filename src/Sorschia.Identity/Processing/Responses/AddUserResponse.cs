using Sorschia.Identity.Entities;
using System.Collections.Generic;

namespace Sorschia.Identity.Processing.Responses
{
    public class AddUserResponse : UserBase
    {
        public IEnumerable<UserRoleObj> UserRoles { get; set; }
        public IEnumerable<UserPermissionObj> UserPermissions { get; set; }

        public AddUserResponse From(User user)
        {
            if (user is not null)
            {
                Id = user.Id;
                Username = user.Username;
                Status = user.Status;
            }

            return this;
        }

        public class UserRoleObj
        {
            public long Id { get; set; }
            public RoleObj Role { get; set; }

            public static implicit operator UserRoleObj(UserRole source) => new()
            {
                Id = source.Id,
                Role = source.Role
            };
        }

        public class RoleObj
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public static implicit operator RoleObj(Role source) => new()
            {
                Id = source.Id,
                Name = source.Name
            };
        }

        public class UserPermissionObj
        {
            public long Id { get; set; }
            public PermissionObj Permission { get; set; }

            public static implicit operator UserPermissionObj(UserPermission source) => new()
            {
                Id = source.Id,
                Permission = source.Permission
            };
        }

        public class PermissionObj
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public static implicit operator PermissionObj(Permission source) => new()
            {
                Id = source.Id,
                Name = source.Name
            };
        }
    }
}
