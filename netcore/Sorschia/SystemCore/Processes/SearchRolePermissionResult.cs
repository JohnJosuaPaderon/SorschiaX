using Sorschia.Processes;
using Sorschia.SystemCore.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemCore.Processes
{
    public sealed class SearchRolePermissionResult : PaginationResultInt64
    {
        public IList<RolePermission> RolePermissions { get; set; }
    }
}
