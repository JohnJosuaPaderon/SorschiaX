using Sorschia.Processes;
using System.Collections.Generic;

namespace Sorschia.SystemCore.Processes
{
    public sealed class SearchPermissionModel : PaginationModelInt32
    {
        public string FilterText { get; set; }
        public bool? IsApiPermission { get; set; }
        public bool? IsDatabasePermission { get; set; }
        public int? ApplicationId { get; set; }
        public IList<int> ApplicationIds { get; set; }
        public int? ModuleId { get; set; }
        public IList<int> ModuleIds { get; set; }
        public int? RoleId { get; set; }
        public IList<int?> RoleIds { get; set; }
        public int? UserId { get; set; }
        public IList<int> UserIds { get; set; }
    }
}
