using Sorschia.Identity.Entities;
using System.Collections.Generic;

namespace Sorschia.Identity.Processes.Results
{
    public class InsertUserResult : UserBase
    {
        public IEnumerable<UserRoleObj> UserRoles { get; set; }
        public IEnumerable<UserPermissionObj> UserPermissions { get; set; }

        public class RoleObj
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public static implicit operator RoleObj(RoleBase source)
            {
                if (source is null)
                    return null;

                return new RoleObj
                {
                    Id = source.Id,
                    Name = source.Name
                };
            }
        }

        public class UserRoleObj
        {
            public long Id { get; set; }
            public RoleObj Role { get; set; }

            public static implicit operator UserRoleObj(UserRole source)
            {
                if (source is null)
                    return null;

                return new UserRoleObj
                {
                    Id = source.Id,
                    Role = source.Role
                };
            }
        }

        public class PermissionObj
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public static implicit operator PermissionObj(PermissionBase source)
            {
                if (source is null)
                    return null;

                return new PermissionObj
                {
                    Id = source.Id,
                    Name = source.Name
                };
            }
        }

        public class UserPermissionObj
        {
            public long Id { get; set; }
            public PermissionObj Permission { get; set; }

            public static implicit operator UserPermissionObj(UserPermission source)
            {
                if (source is null)
                    return null;

                return new UserPermissionObj
                {
                    Id = source.Id,
                    Permission = source.Permission
                };
            }
        }
    }
}
