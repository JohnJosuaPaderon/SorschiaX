using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Processes
{
    public interface IAsyncProcess<TInput, TOutput>
    {
        Task<TOutput> ExecuteAsync(TInput input, CancellationToken cancellationToken = default);
    }
}
