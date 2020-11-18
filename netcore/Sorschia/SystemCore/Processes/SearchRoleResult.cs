using Sorschia.Processes;
using Sorschia.SystemCore.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemCore.Processes
{
    public sealed class SearchRoleResult : PaginationResultInt32
    {
        public IList<Role> Roles { get; set; }
    }
}
