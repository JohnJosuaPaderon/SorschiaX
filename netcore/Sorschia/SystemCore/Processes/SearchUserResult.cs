using Sorschia.Processes;
using Sorschia.SystemCore.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemCore.Processes
{
    public sealed class SearchUserResult : PaginationResultInt32
    {
        public IList<User> Users { get; set; }
    }
}
