using Sorschia.Processes;
using System.Collections.Generic;

namespace Sorschia.SystemCore.Processes
{
    public sealed class SearchUserRoleModel : PaginationModelInt64
    {
        public int? UserId { get; set; }
        public IList<int> UserIds { get; set; }
        public int? RoleId { get; set; }
        public IList<int> RoleIds { get; set; }
    }
}
