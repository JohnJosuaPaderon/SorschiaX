using Sorschia.Processes;
using System.Collections.Generic;

namespace Sorschia.SystemCore.Processes
{
    public sealed class SearchUserModuleModel : PaginationModelInt64
    {
        public int? UserId { get; set; }
        public IList<int> UserIds { get; set; }
        public int? ModuleId { get; set; }
        public IList<int> ModuleIds { get; set; }
    }
}
