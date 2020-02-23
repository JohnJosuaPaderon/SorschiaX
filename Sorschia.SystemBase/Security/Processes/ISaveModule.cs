using Sorschia.SystemBase.Security.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemBase.Security.Processes
{
    public interface ISaveModule : IAsyncProcess<SaveModuleResult>
    {
        SaveModuleModel Model { get; set; }
    }

    public sealed class SaveModuleModel
    {
        public SystemModule Module { get; set; }
        public IList<SystemUserModule> UserModuleList { get; set; } = new List<SystemUserModule>();
        public IList<long> DeletedUserModuleIdList { get; set; } = new List<long>();
    }

    public sealed class SaveModuleResult
    {
        public SystemModule Module { get; set; }
        public IList<SystemUserModule> UserModuleList { get; set; } = new List<SystemUserModule>();
        public IList<long> DeletedUserModuleIdList { get; set; } = new List<long>();
    }
}
