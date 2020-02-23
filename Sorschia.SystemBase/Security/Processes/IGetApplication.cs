using Sorschia.SystemBase.Security.Entities;

namespace Sorschia.SystemBase.Security.Processes
{
    public interface IGetApplication : IAsyncProcess<SystemApplication>
    {
        int Id { get; set; }
    }
}
