using Sorschia.Identity.Entities;
using System.Collections.Generic;

namespace Sorschia.Identity.Processes.Results
{
    public class InsertRoleResult : RoleBase
    {
        public IEnumerable<PermissionObj> Permissions { get; set; }

        public class PermissionObj
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
