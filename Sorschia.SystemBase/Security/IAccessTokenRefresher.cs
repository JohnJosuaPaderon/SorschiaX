using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemBase.Security
{
    public interface IAccessTokenRefresher
    {
        Task RefreshAsync(CancellationToken cancellationToken = default);
    }
}
