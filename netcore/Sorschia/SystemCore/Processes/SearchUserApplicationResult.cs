using Sorschia.Processes;
using Sorschia.SystemCore.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemCore.Processes
{
    public sealed class SearchUserApplicationResult : PaginationResultInt64
    {
        public IList<UserApplication> UserApplications { get; set; }
    }
}
