using Sorschia.Processes;

namespace Sorschia.SystemCore.Processes
{
    public interface IDeleteUserModule : IAsyncProcess<bool>
    {
        DeleteUserModuleModel Model { get; set; }
    }

    public sealed class DeleteUserModuleModel
    {
        public long Id { get; set; }
        public bool IsCascaded { get; set; }
    }
}
