using Sorschia.Processes;

namespace Sorschia.SystemCore.Processes
{
    public interface IDeletePlatform : IAsyncProcess<bool>
    {
        DeletePlatformModel Model { get; set; }
    }

    public sealed class DeletePlatformModel
    {
        public int Id { get; set; }
        public bool IsCascaded { get; set; }
    }
}
