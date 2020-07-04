using Sorschia.Processes;
using Sorschia.SystemCore.Entities;

namespace Sorschia.SystemCore.Processes
{
    public interface IGetModule : IAsyncProcess<Module>
    {
        int Id { get; set; }
    }
}
