using Sorschia.SystemBase.Security.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemBase.Security.Processes
{
    public interface IGetUserModuleList : IAsyncProcess<GetUserModuleListResult>
    {
        GetUserModuleListModel Model { get; set; }
    }

    public sealed class GetUserModuleListModel : PaginatedModel
    {
        public bool FilterByApproved { get; set; }
        public bool IsApproved { get; set; }
        public bool FilterByUser { get; set; }
        public IList<int> UserIdList { get; set; } = new List<int>();
        public bool FilterByModule { get; set; }
        public IList<int> ModuleIdList { get; set; } = new List<int>();
    }

    public sealed class GetUserModuleListResult : PaginatedResult
    {
        public IList<SystemUserModule> UserModuleList { get; set; } = new List<SystemUserModule>();
    }
}
