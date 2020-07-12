using Sorschia.Processes;
using Sorschia.SystemCore.Entities;

namespace Sorschia.SystemCore.Processes
{
    public interface IGetUser : IAsyncProcess<User>
    {
        int Id { get; set; }
    }
}
