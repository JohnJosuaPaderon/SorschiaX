using Sorschia.SystemBase.Security.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemBase.Security.Processes
{
    public interface ISaveApplicationPlatform : IAsyncProcess<SaveApplicationPlatformResult>
    {
        SaveApplicationPlatformModel Model { get; set; }
    }

    public sealed class SaveApplicationPlatformModel
    {
        public SystemApplicationPlatform ApplicationPlatform { get; set; }
        public IList<SystemApplication> ApplicationList { get; set; } = new List<SystemApplication>();
        public IList<int> RemovedApplicationIdList { get; set; } = new List<int>();
    }

    public sealed class SaveApplicationPlatformResult
    {
        public SystemApplicationPlatform ApplicationPlatform { get; set; }
        public IList<SystemApplication> ApplicationList { get; set; } = new List<SystemApplication>();
        public IList<int> RemovedApplicationIdList { get; set; } = new List<int>();
    }
}
