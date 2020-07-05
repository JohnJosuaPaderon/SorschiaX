using Sorschia.Processes;
using Sorschia.SystemCore.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemCore.Processes
{
    public interface ISearchPlatform : IAsyncProcess<SearchPlatformResult>
    {
        SearchPlatformModel Model { get; set; }
    }

    public sealed class SearchPlatformModel : PaginationModel
    {
        public string FilterText { get; set; }
        public IList<int> SkippedIds { get; set; } = new List<int>();
    }

    public sealed class SearchPlatformResult : PaginationResult
    {
        public IList<Platform> Platforms { get; set; } = new List<Platform>();
    }
}
