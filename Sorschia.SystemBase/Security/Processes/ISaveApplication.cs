using Sorschia.SystemBase.Security.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemBase.Security.Processes
{
    public interface ISaveApplication : IAsyncProcess<SaveApplicationResult>
    { 
        SaveApplicationModel Model { get; set; }
    }

    public sealed class SaveApplicationModel
    {
        public SystemApplication Application { get; set; }
        public bool IsForceDeleteModule { get; set; }
        public IList<SystemUserApplication> UserApplicationList { get; set; } = new List<SystemUserApplication>();
        public IList<SystemModule> ModuleList { get; set; } = new List<SystemModule>();
        public IList<long> DeletedUserApplicationIdList { get; set; } = new List<long>();
        public IList<int> RemovedModuleIdList { get; set; } = new List<int>();
    }

    public sealed class SaveApplicationResult
    {
        public SystemApplication Application { get; set; }
        public IList<SystemUserApplication> UserApplicationList { get; set; } = new List<SystemUserApplication>();
        public IList<SystemModule> ModuleList { get; set; } = new List<SystemModule>();
        public IList<long> DeletedUserApplicationIdList { get; set; } = new List<long>();
        public IList<int> RemovedModuleIdList { get; set; } = new List<int>();
    }
}
