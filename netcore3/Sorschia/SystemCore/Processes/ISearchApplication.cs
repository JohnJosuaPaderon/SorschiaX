using Sorschia.Processes;
using Sorschia.SystemCore.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemCore.Processes
{
    public interface ISearchApplication : IAsyncProcess<SearchApplicationResult>
    {
        SearchApplicationModel Model { get; set; }
    }

    public sealed class SearchApplicationModel : PaginationModel
    {
        public string FilterText { get; set; }
        public bool FilterByPlatform { get; set; }
        public IList<int> PlatformIds { get; set; } = new List<int>();
        public IList<int> SkippedIds { get; set; } = new List<int>();
    }

    public sealed class SearchApplicationResult : PaginationResult
    {
        public IList<Application> Applications { get; set; } = new List<Application>();
    }
}
