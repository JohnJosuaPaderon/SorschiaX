using Sorschia.Processes;

namespace Sorschia.SystemCore.Processes
{
    public interface IDeleteModule : IAsyncProcess<bool>
    {
        DeleteModuleModel Model { get; set; }
    }

    public sealed class DeleteModuleModel
    {
        public int Id { get; set; }
        public bool IsCascaded { get; set; }
    }
}
