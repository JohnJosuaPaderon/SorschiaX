using Sorschia.Processes;
using Sorschia.SystemCore.Entities;

namespace Sorschia.SystemCore.Processes
{
    public interface IGetPlatform : IAsyncProcess<Platform>
    {
        int Id { get; set; }
    }
}
