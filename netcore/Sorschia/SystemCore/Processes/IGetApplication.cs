using Sorschia.Processes;
using Sorschia.SystemCore.Entities;

namespace Sorschia.SystemCore.Processes
{
    public interface IGetApplication : IAsyncProcess<Application>
    {
        int Id { get; set; }
    }
}
