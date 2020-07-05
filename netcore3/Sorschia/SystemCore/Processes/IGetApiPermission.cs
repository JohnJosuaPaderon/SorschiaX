using Sorschia.Processes;
using Sorschia.SystemCore.Entities;

namespace Sorschia.SystemCore.Processes
{
    public interface IGetApiPermission : IAsyncProcess<ApiPermission>
    {
        int Id { get; set; }
    }
}
