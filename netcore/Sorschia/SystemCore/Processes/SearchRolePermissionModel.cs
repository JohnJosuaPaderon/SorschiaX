using Sorschia.Processes;
using System.Collections.Generic;

namespace Sorschia.SystemCore.Processes
{
    public sealed class SearchRolePermissionModel : PaginationModelInt64
    {
        public int? RoleId { get; set; }
        public IList<int> RoleIds { get; set; }
        public int? PermissionId { get; set; }
        public IList<int> PermissionIds { get; set; }
    }
}
