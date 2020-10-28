using Sorschia.Processes;
using Sorschia.SystemCore.Entities;

namespace Sorschia.SystemCore.Processes
{
    public interface IGetSession : IAsyncProcess<Session>
    {
        long Id { get; set; }
    }
}
