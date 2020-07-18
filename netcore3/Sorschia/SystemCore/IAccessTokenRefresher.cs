using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore
{
    public interface IAccessTokenRefresher
    {
        Task RefreshAsync(CancellationToken cancellationToken = default);
    }
}
