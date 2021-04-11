using MediatR;
using Sorschia.Identity.Processes.Results;
using System.Collections.Generic;

namespace Sorschia.Identity.Processes
{
    public class SearchUser : IRequest<SearchUserResult>
    {
        public string FilterText { get; set; }
        public IEnumerable<int> RoleIds { get; set; }
        public IEnumerable<int> PermissionIds { get; set; }
        public IEnumerable<int> SkippedIds { get; set; }
        public int? SkippedCount { get; set; }
        public int? TakenCount { get; set; }
    }
}
