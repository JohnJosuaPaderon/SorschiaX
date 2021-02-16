using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Data
{
    public interface IAsyncDelete<TId>
    {
        Task ExecuteAsync(TId id, CancellationToken cancellationToken = default);
    }
}
