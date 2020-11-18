using System.Collections.Generic;

namespace Sorschia.Processes
{
    public class QueryModel<TId>
    {
        public IList<TId> SkippedIds { get; set; }
        public IList<string> SubObjects { get; set; }
        public IList<OrdinalRule> OrdinalRules { get; set; }
    }
}
