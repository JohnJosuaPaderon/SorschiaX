using Sorschia.Processes;
using Sorschia.SystemCore.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemCore.Processes
{
    public sealed class SearchUserPermissionResult : PaginationResultInt64
    {
        public IList<UserPermission> UserPermissions { get; set; }
    }
}
