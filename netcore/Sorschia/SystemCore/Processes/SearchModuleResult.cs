using Sorschia.Processes;
using Sorschia.SystemCore.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemCore.Processes
{
    public sealed class SearchModuleResult : PaginationResultInt32
    {
        public IList<Module> Modules { get; set; }
    }
}
