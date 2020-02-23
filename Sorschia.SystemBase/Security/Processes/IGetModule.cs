using Sorschia.SystemBase.Security.Entities;

namespace Sorschia.SystemBase.Security.Processes
{
    public interface IGetModule : IAsyncProcess<SystemModule>
    {
        int Id { get; set; }
    }
}
