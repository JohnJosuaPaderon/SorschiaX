using Sorschia.Processes;
using Sorschia.SystemCore.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemCore.Processes
{
    public interface ISearchPermissionType : IAsyncProcess<SearchPermissionTypeResult>
    {
        SearchPermissionTypeModel Model { get; set; }
    }

    public sealed class SearchPermissionTypeModel : PaginationModel
    {
        public string FilterText { get; set; }
        public IList<int> SkippedIds { get; set; } = new List<int>();
    }

    public sealed class SearchPermissionTypeResult : PaginationResult
    {
        public IList<PermissionType> Types { get; set; } = new List<PermissionType>();
    }
}
