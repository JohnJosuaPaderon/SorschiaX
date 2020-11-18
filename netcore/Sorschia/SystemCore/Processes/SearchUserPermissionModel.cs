using Sorschia.Processes;
using System.Collections.Generic;

namespace Sorschia.SystemCore.Processes
{
    public sealed class SearchUserPermissionModel : PaginationModelInt64
    {
        public int? UserId { get; set; }
        public IList<int> UserIds { get; set; }
        public int? PermissionId { get; set; }
        public IList<int> PermissionIds { get; set; }
    }
}
