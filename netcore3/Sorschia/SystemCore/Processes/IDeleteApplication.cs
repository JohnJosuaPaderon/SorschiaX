using Sorschia.Processes;

namespace Sorschia.SystemCore.Processes
{
    public interface IDeleteApplication : IAsyncProcess<bool>
    {
        DeleteApplicationModel Model { get; set; }
    }

    public sealed class DeleteApplicationModel
    {
        public int Id { get; set; }
        public bool IsCascaded { get; set; }
    }
}
