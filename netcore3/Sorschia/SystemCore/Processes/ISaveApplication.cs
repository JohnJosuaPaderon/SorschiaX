using Sorschia.Processes;
using Sorschia.SystemCore.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemCore.Processes
{
    public interface ISaveApplication : IAsyncProcess<SaveApplicationResult>
    {
        SaveApplicationModel Model { get; set; }
    }

    public sealed class SaveApplicationModel
    {
        public Application Application { get; set; }
        public IList<Module> Modules { get; set; } = new List<Module>();
        public IList<UserApplication> UserApplications { get; set; } = new List<UserApplication>();
        public IList<DeleteModuleModel> DeletedModules { get; set; } = new List<DeleteModuleModel>();
        public IList<DeleteUserApplicationModel> DeletedUserApplications { get; set; } = new List<DeleteUserApplicationModel>();
    }

    public sealed class SaveApplicationResult
    {
        public Application Application { get; set; }
        public IList<Module> Modules { get; set; } = new List<Module>();
        public IList<UserApplication> UserApplications { get; set; } = new List<UserApplication>();
        public IList<int> DeletedModuleIds { get; set; } = new List<int>();
        public IList<long> DeletedUserApplicationIds { get; set; } = new List<long>();
    }
}
