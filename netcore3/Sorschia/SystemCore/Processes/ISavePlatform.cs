using Sorschia.Processes;
using Sorschia.SystemCore.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemCore.Processes
{
    public interface ISavePlatform : IAsyncProcess<SavePlatformResult>
    {
        SavePlatformModel Model { get; set; }
    }

    public sealed class SavePlatformModel
    {
        public Platform Platform { get; set; }
        public IList<Application> Applications { get; set; } = new List<Application>();
        public IList<DeleteApplicationModel> DeletedApplications { get; set; } = new List<DeleteApplicationModel>();
    }

    public sealed class SavePlatformResult
    {
        public Platform Platform { get; set; }
        public IList<Application> Applications { get; set; } = new List<Application>();
        public IList<int> DeletedApplicationIds { get; set; } = new List<int>();
    }
}
