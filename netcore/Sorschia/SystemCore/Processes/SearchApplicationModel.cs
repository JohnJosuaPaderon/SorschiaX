using Sorschia.Processes;
using System.Collections.Generic;

namespace Sorschia.SystemCore.Processes
{
    public sealed class SearchApplicationModel : PaginationModelInt32
    {
        public string FilterText { get; set; }
        public int? PermissionId { get; set; }
        public IList<int> PermissionIds { get; set; }
        public int? UserId { get; set; }
        public IList<int> UserIds { get; set; }
    }
}
