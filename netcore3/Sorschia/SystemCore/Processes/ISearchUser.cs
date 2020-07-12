using Sorschia.Processes;
using Sorschia.SystemCore.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemCore.Processes
{
    public interface ISearchUser : IAsyncProcess<SearchUserResult>
    {
        SearchUserModel Model { get; set; }
    }

    public sealed class SearchUserModel : PaginationModel
    {
        public string FilterText { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsPasswordChangeRequired { get; set; }
        public IList<int> SkippedIds { get; set; } = new List<int>();
    }

    public sealed class SearchUserResult : PaginationResult
    {
        public IList<User> Users { get; set; } = new List<User>();
    }
}
