using Sorschia.SystemBase.Security.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemBase.Security.Processes
{
    public interface IGetModuleList : IAsyncProcess<GetModuleListResult>
    {
        GetModuleListModel Model { get; set; }
    }

    public sealed class GetModuleListModel : PaginatedModel
    {
        public string FilterText { get; set; }
        public bool FilterByApplication { get; set; }
        public IList<int> ApplicationIdList { get; set; } = new List<int>();
        public IList<int> SkippedIdList { get; set; } = new List<int>();
    }

    public sealed class GetModuleListResult : PaginatedResult
    {
        public IList<SystemModule> ModuleList { get; set; } = new List<SystemModule>();
    }
}
