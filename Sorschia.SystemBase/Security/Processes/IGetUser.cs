using Sorschia.SystemBase.Security.Entities;

namespace Sorschia.SystemBase.Security.Processes
{
    public interface IGetUser : IAsyncProcess<SystemUser>
    {
        int Id { get; set; }
    }
}
