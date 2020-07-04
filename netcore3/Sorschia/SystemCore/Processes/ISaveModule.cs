using Sorschia.Processes;
using Sorschia.SystemCore.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemCore.Processes
{
    public interface ISaveModule : IAsyncProcess<SaveModuleResult>
    {
        SaveModuleModel Model { get; set; }
    }

    public sealed class SaveModuleModel
    {
        public Module Module { get; set; }
        public IList<UserModule> UserModules { get; set; } = new List<UserModule>();
        public IList<DeleteUserModuleModel> DeletedUserModules { get; set; } = new List<DeleteUserModuleModel>();
    }

    public sealed class SaveModuleResult
    {
        public Module Module { get; set; }
        public IList<UserModule> UserModules { get; set; } = new List<UserModule>();
        public IList<long> DeletedUserModuleIds { get; set; } = new List<long>();
    }
}
