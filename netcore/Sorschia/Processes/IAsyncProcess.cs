using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Processes
{
    public interface IAsyncProcess<TResult> : IDisposable
    {
        Task<TResult> ExecuteAsync(CancellationToken cancellationToken = default);
    }
}
