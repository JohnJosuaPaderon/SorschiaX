using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Data
{
    public interface IAsyncUpdate<TId, TModel, TResult>
    {
        Task<TResult> ExecuteAsync(TId id, TModel model, CancellationToken cancellationToken = default);
    }
}
