using Sorschia.SystemBase.Security.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemBase.Security.Processes
{
    public interface IGetUserApplicationList : IAsyncProcess<GetUserApplicationListResult>
    {
        GetUserApplicationListModel Model { get; set; }
    }

    public sealed class GetUserApplicationListModel : PaginatedModel
    {
        public bool FilterByApproved { get; set; }
        public bool IsApproved { get; set; }
        public bool FilterByUser { get; set; }
        public IList<int> UserIdList { get; set; } = new List<int>();
        public bool FilterByApplication { get; set; }
        public IList<int> ApplicationIdList { get; set; } = new List<int>();
    }

    public sealed class GetUserApplicationListResult : PaginatedResult
    {
        public IList<SystemUserApplication> UserApplicationList { get; set; } = new List<SystemUserApplication>();
    }
}
