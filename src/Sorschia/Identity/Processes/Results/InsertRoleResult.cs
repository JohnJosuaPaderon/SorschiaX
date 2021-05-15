using Sorschia.Identity.Entities;
using System.Collections.Generic;

namespace Sorschia.Identity.Processes.Results
{
    public class InsertRoleResult : RoleBase
    {
        public IEnumerable<PermissionObj> Permissions { get; set; }

        public static implicit operator InsertRoleResult(Role source)
        {
            if (source is null)
                return null;

            return new()
            {
                Id = source.Id,
                LookupCode = source.LookupCode,
                Name = source.Name,
                Description = source.Description
            };
        }

        public class PermissionObj
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
