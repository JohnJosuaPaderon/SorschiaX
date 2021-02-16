using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Data
{
    public interface IAsyncInsert<T>
    {
        Task<T> ExecuteAsync(T model, CancellationToken cancellationToken = default);
    }

    public interface IAsyncInsert<TModel, TResult>
    {
        Task<TResult> ExecuteAsync(TModel model, CancellationToken cancellationToken = default);
    }
}
