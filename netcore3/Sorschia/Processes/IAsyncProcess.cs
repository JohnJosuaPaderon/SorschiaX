using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Processes
{
    public interface IAsyncProcess : IDisposable
    {
        Task ExecuteAsync(CancellationToken cancellationToken = default);
    }

    public interface IAsyncProcess<T> : IDisposable
    {
        Task<T> ExecuteAsync(CancellationToken cancellationToken = default);
    }
}
