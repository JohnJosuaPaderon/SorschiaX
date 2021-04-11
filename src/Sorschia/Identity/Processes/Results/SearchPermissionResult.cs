using Sorschia.Identity.Entities;
using System.Collections.Generic;

namespace Sorschia.Identity.Processes.Results
{
    public class SearchPermissionResult
    {
        public IEnumerable<PermissionObj> Permissions { get; set; }
        public int TotalCount { get; set; }

        public class PermissionObj : PermissionBase
        {
            public RoleObj Role { get; set; }
        }

        public class RoleObj
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
