using Sorschia.Processes;
using System.Collections.Generic;

namespace Sorschia.SystemCore.Processes
{
    public sealed class SearchModulePermissionModel : PaginationModelInt64
    {
        public int? ModuleId { get; set; }
        public IList<int> ModuleIds { get; set; }
        public int? PermissionId { get; set; }
        public IList<int> PermissionIds { get; set; }
    }
}
