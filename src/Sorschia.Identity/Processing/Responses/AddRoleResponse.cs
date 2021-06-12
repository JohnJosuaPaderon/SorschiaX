using Sorschia.Identity.Entities;
using System.Collections.Generic;

namespace Sorschia.Identity.Processing.Responses
{
    public class AddRoleResponse : RoleBase
    {
        public IEnumerable<RolePermissionObj> RolePermissions { get; set; }

        public AddRoleResponse From(Role role)
        {
            if (role is not null)
            {
                Id = role.Id;
                Name = role.Name;
                LookupCode = role.LookupCode;
                Description = role.Description;
            }

            return this;
        }

        public class RolePermissionObj
        {
            public long Id { get; set; }
            public PermissionObj Permission { get; set; }

            public static implicit operator RolePermissionObj(RolePermission source) => new()
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
