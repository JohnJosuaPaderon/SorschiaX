using MediatR;
using Sorschia.Identity.Processes.Results;
using System.Collections.Generic;

namespace Sorschia.Identity.Processes
{
    public class SearchPermission : IRequest<SearchPermissionResult>
    {
        public bool IncludeRole { get; set; }
        public string FilterText { get; set; }
        public IEnumerable<int> RoleIds { get; set; }
        public IEnumerable<int> UserIds { get; set; }
        public IEnumerable<int> SkippedIds { get; set; }
        public int? SkippedCount { get; set; }
        public int? TakenCount { get; set; }
    }
}
