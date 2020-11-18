using Sorschia.Processes;
using System.Collections.Generic;

namespace Sorschia.SystemCore.Processes
{
    public sealed class SearchApplicationPermissionModel : PaginationModelInt64
    {
        public int? ApplicationId { get; set; }
        public IList<int> ApplicationIds { get; set; }
        public int? PermissionId { get; set; }
        public IList<int> PermissionIds { get; set; }
    }
}
