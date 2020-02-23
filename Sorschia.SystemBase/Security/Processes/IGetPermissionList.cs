using Sorschia.SystemBase.Security.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemBase.Security.Processes
{
    public interface IGetPermissionList : IAsyncProcess<GetPermissionListResult>
    {
        GetPermissionListModel Model { get; set; }
    }

    public sealed class GetPermissionListModel : PaginatedModel
    {
        public string FilterText { get; set; }
        public IList<int> SkippedIdList { get; set; } = new List<int>();
    }

    public sealed class GetPermissionListResult : PaginatedResult
    {
        public IList<SystemPermission> PermissionList { get; set; } = new List<SystemPermission>();
    }
}
