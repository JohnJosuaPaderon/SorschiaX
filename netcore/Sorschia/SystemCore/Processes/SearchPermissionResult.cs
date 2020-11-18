using Sorschia.Processes;
using Sorschia.SystemCore.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemCore.Processes
{
    public sealed class SearchPermissionResult : PaginationModelInt32
    {
        public IList<Permission> Permissions { get; set; }
    }
}
