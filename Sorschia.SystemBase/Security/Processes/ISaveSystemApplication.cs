using Sorschia.Process;
using Sorschia.SystemBase.Security.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemBase.Security.Processes
{
    public interface ISaveSystemApplication : IAsyncProcess<SaveSystemApplicationResult>
    { 
        SavesystemApplicationModel Model { get; set; }
    }

    public sealed class SavesystemApplicationModel
    {
        public SystemApplication Application { get; set; }
        public bool IsForceDeleteModule { get; set; }
        public IList<SystemUserApplication> UserApplicationList { get; set; } = new List<SystemUserApplication>();
        public IList<SystemModule> ModuleList { get; set; } = new List<SystemModule>();
        public IList<SystemUserApplication> DeletedUserApplicationList { get; set; } = new List<SystemUserApplication>();
        public IList<SystemModule> DeletedModuleList { get; set; } = new List<SystemModule>();
    }

    public sealed class SaveSystemApplicationResult
    {
        public SystemApplication Application { get; set; }
        public IList<SystemUserApplication> UserApplicationList { get; set; } = new List<SystemUserApplication>();
        public IList<SystemModule> ModuleList { get; set; } = new List<SystemModule>();
        public IList<SystemUserApplication> DeletedUserApplicationList { get; set; } = new List<SystemUserApplication>();
        public IList<SystemModule> DeletedModuleList { get; set; } = new List<SystemModule>();
    }
}
