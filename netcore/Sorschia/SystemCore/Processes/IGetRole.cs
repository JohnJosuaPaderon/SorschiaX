using Sorschia.Processes;
using Sorschia.SystemCore.Entities;

namespace Sorschia.SystemCore.Processes
{
    public interface IGetRole : IAsyncProcess<Role>
    {
        int Id { get; set; }
    }
}
