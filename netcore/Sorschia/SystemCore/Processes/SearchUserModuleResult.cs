using Sorschia.Processes;
using Sorschia.SystemCore.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemCore.Processes
{
    public sealed class SearchUserModuleResult : PaginationResultInt64
    {
        public IList<UserModule> UserModules { get; set; }
    }
}
