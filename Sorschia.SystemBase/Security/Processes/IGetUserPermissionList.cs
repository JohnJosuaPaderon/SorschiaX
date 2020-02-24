using Sorschia.SystemBase.Security.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemBase.Security.Processes
{
    public interface IGetUserPermissionList : IAsyncProcess<GetUserPermissionListResult>
    {
        GetUserPermissionListModel Model { get; set; }
    }

    public sealed class GetUserPermissionListModel : PaginatedModel
    {
        public bool FilterByApproved { get; set; }
        public bool IsApproved { get; set; }
        public bool FilterByUser { get; set; }
        public IList<int> UserIdList { get; set; } = new List<int>();
        public bool FilterByPermission { get; set; }
        public IList<int> PermissionIdList { get; set; } = new List<int>();
    }

    public sealed class GetUserPermissionListResult : PaginatedResult
    {
        public IList<SystemUserPermission> UserPermissionList { get; set; } = new List<SystemUserPermission>();
    }
}
