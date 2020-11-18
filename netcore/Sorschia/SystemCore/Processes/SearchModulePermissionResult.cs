using Sorschia.Processes;
using Sorschia.SystemCore.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemCore.Processes
{
    public sealed class SearchModulePermissionResult : PaginationResultInt64
    {
        public IList<ModulePermission> ModulePermissions { get; set; }
    }
}
