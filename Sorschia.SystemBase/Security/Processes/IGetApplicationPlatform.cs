using Sorschia.SystemBase.Security.Entities;

namespace Sorschia.SystemBase.Security.Processes
{
    public interface IGetApplicationPlatform : IAsyncProcess<SystemApplicationPlatform>
    {
        int Id { get; set; }
    }
}
