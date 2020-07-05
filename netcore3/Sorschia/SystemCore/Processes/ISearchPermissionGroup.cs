using Sorschia.Processes;
using Sorschia.SystemCore.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemCore.Processes
{
    public interface ISearchPermissionGroup : IAsyncProcess<SearchPermissionGroupResult>
    {
        SearchPermissionGroupModel Model { get; set; }
    }

    public sealed class SearchPermissionGroupModel : PaginationModel
    {
        public string FilterText { get; set; }
        public bool FilterByParent { get; set; }
        public IList<int> ParentIds { get; set; } = new List<int>();
        public IList<int> SkippedIds { get; set; } = new List<int>();
    }

    public sealed class SearchPermissionGroupResult : PaginationResult
    {
        public IList<PermissionGroup> Groups { get; set; } = new List<PermissionGroup>();
    }
}
