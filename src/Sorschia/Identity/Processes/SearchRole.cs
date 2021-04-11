using MediatR;
using Sorschia.Identity.Processes.Results;
using System.Collections.Generic;

namespace Sorschia.Identity.Processes
{
    public class SearchRole : IRequest<SearchRoleResult>
    {
        public string FilterText { get; set; }
        public IEnumerable<int> UserIds { get; set; }
        public IEnumerable<int> SkippedIds { get; set; }
        public int? SkippedCount { get; set; }
        public int? TakenCount { get; set; }
    }
}
