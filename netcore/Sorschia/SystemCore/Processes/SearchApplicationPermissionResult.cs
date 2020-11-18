using Sorschia.Processes;
using Sorschia.SystemCore.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemCore.Processes
{
    public sealed class SearchApplicationPermissionResult : PaginationResultInt64
    {
        public IList<ApplicationPermission> ApplicationPermissions { get; set; }
    }
}
