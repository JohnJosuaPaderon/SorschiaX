using Sorschia.Processes;
using System.Collections.Generic;

namespace Sorschia.SystemCore.Processes
{
    public sealed class SearchUserApplicationModel : PaginationModelInt64
    {
        public int? UserId { get; set; }
        public IList<int> UserIds { get; set; }
        public int? ApplicationId { get; set; }
        public IList<int> ApplicationIds { get; set; }
    }
}
