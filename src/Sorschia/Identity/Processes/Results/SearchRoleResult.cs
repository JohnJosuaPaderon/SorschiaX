using Sorschia.Identity.Entities;
using System.Collections.Generic;

namespace Sorschia.Identity.Processes.Results
{
    public class SearchRoleResult
    {
        public IEnumerable<RoleObj> Roles { get; set; }
        public int TotalCount { get; set; }

        public class RoleObj : RoleBase
        {
        }
    }
}
