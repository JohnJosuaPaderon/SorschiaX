using Sorschia.SystemBase.Security.Entities;

namespace Sorschia.SystemBase.Security.Processes
{
    public interface IGetPermission : IAsyncProcess<SystemPermission>
    {
        int Id { get; set; }
    }
}
