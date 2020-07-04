using Sorschia.Processes;

namespace Sorschia.SystemCore.Processes
{
    public interface IDeleteUserApplication : IAsyncProcess<bool>
    {
        DeleteUserApplicationModel Model { get; set; }
    }

    public sealed class DeleteUserApplicationModel
    {
        public long Id { get; set; }
        public bool IsCascaded { get; set; }
    }
}
