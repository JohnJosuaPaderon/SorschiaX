using Sorschia.Processes;
using Sorschia.SystemCore.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemCore.Processes
{
    public interface ISearchModule : IAsyncProcess<SearchModuleResult>
    {
        SearchModuleModel Model { get; set; }
    }

    public sealed class SearchModuleModel : PaginationModel
    {
        public string FilterText { get; set; }
        public bool FilterByApplication { get; set; }
        public IList<int> ApplicationIds { get; set; } = new List<int>();
        public IList<int> SkippedIds { get; set; } = new List<int>();
    }

    public sealed class SearchModuleResult : PaginationResult
    {
        public IList<Module> Modules { get; set; } = new List<Module>();
    }
}
