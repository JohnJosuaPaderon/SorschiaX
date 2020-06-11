using System;

namespace Sorschia.SystemBase.Security.Processes
{
    public interface IStopSession : IAsyncProcess<bool>
    {
        Guid SessionId { get; set; }
    }
}
