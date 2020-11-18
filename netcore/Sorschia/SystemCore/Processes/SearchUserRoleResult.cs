using Sorschia.Processes;
using Sorschia.SystemCore.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemCore.Processes
{
    public sealed class SearchUserRoleResult : PaginationResultInt64
    {
        public IList<UserRole> UserRoles { get; set; }
    }
}
