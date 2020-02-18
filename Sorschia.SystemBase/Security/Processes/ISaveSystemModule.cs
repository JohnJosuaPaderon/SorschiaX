using Sorschia.Process;
using Sorschia.SystemBase.Security.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemBase.Security.Processes
{
    public interface ISaveSystemModule : IAsyncProcess<SaveSystemModuleResult>
    {
        SaveSystemModuleModel Model { get; set; }
    }

    public sealed class SaveSystemModuleModel
    {
        public SystemModule Module { get; set; }
        public IList<SystemUserModule> UserModuleList { get; set; } = new List<SystemUserModule>();
        public IList<SystemUserModule> DeletedUserModuleList { get; set; } = new List<SystemUserModule>();
    }

    public sealed class SaveSystemModuleResult
    {
        public SystemModule Module { get; set; }
        public IList<SystemUserModule> UserModuleList { get; set; } = new List<SystemUserModule>();
        public IList<SystemUserModule> DeletedUserModuleList { get; set; } = new List<SystemUserModule>();
    }
}
