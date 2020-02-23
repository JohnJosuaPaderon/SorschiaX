using Sorschia.SystemBase.Security.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemBase.Security.Processes
{
    public interface IGetApplicationList : IAsyncProcess<GetApplicationListResult>
    {
        GetApplicationListModel Model { get; set; }
    }

    public sealed class GetApplicationListModel : PaginatedModel
    {
        public string FilterText { get; set; }
        public bool FilterByPlatform { get; set; }
        public IList<int> PlatformIdList { get; set; } = new List<int>();
        public IList<int> SkippedIdList { get; set; } = new List<int>();
    }

    public sealed class GetApplicationListResult : PaginatedResult
    {
        public IList<SystemApplication> ApplicationList { get; set; } = new List<SystemApplication>();
    }
}
