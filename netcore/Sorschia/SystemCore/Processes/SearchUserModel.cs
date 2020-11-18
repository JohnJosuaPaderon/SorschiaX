using Sorschia.Processes;
using System.Collections.Generic;

namespace Sorschia.SystemCore.Processes
{
    public sealed class SearchUserModel : PaginationModelInt32
    {
        public string FilterText { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsPasswordChangeRequired { get; set; }
        public bool? IsEmailVerified { get; set; }
        public int? ApplicationId { get; set; }
        public IList<int> ApplicationIds { get; set; }
        public int? ModuleId { get; set; }
        public IList<int> ModuleIds { get; set; }
        public int? PermissionId { get; set; }
        public IList<int> PermissionIds { get; set; }
        public int? RoleId { get; set; }
        public IList<int> RoleIds { get; set; }
    }
}
