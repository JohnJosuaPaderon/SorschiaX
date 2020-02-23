using Sorschia.SystemBase.Security.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemBase.Security.Processes
{
    public interface IGetApplicationPlatformList : IAsyncProcess<GetApplicationPlatformListResult>
    {
        GetApplicationPlatformListModel Model { get; set; }
    }

    public sealed class GetApplicationPlatformListModel : PaginatedModel
    {
        public string FilterText { get; set; }
        public IList<int> SkippedIdList { get; set; } = new List<int>();
    }

    public sealed class GetApplicationPlatformListResult : PaginatedResult
    {
        public IList<SystemApplicationPlatform> ApplicationPlatformList { get; set; } = new List<SystemApplicationPlatform>();
    }
}
