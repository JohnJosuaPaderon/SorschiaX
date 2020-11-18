using Sorschia.Processes;
using Sorschia.SystemCore.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemCore.Processes
{
    public sealed class SearchApplicationResult : PaginationResultInt32
    {
        public IList<Application> Applications { get; set; }
    }
}
